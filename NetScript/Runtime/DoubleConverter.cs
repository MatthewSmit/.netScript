// Copyright 2006-2011, the V8 project authors. All rights reserved.
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions are
// met:
// 
//     * Redistributions of source code must retain the above copyright
//       notice, this list of conditions and the following disclaimer.
//     * Redistributions in binary form must reproduce the above
//       copyright notice, this list of conditions and the following
//       disclaimer in the documentation and/or other materials provided
//       with the distribution.
//     * Neither the name of Google Inc. nor the names of its
//       contributors may be used to endorse or promote products derived
//       from this software without specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
// "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
// LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
// A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT
// OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
// SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
// LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
// DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
// THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
// (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
// OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

using System;
using System.Diagnostics;
using System.Text;
using JetBrains.Annotations;

namespace NetScript.Runtime
{
    internal static unsafe class DoubleConverter
    {
        private const ulong SIGNIFICAND_MASK = 0x000FFFFF_FFFFFFFF;
        private const ulong EXPONENT_MASK = 0x7FF00000_00000000;
        private const ulong HIDDEN_BIT = 0x00100000_00000000;
        private const int PHYSICAL_SIGNIFICAND_SIZE = 52;
        private const int SIGNIFICAND_SIZE = 53;
        private const int EXPONENT_BIAS = 0x3FF + PHYSICAL_SIGNIFICAND_SIZE;
        private const int DENORMAL_EXPONENT = -EXPONENT_BIAS + 1;
        private const int MINIMAL_TARGET_EXPONENT = -60;
        private const int MAXIMAL_TARGET_EXPONENT = -32;
        private const int DIY_FP_SIGNIFICAND_SIZE = 64;
        private const int CACHED_POWERS_OFFSET = 348; // -1 * the first decimal_exponent.
        private const int DECIMAL_EXPONENT_DISTANCE = 8;

        private static readonly (ulong Significand, short BinaryExponent, short DecimalExponent)[] cachedPowers =
        {
            (0xFA8FD5A0_081C0288, -1220, -348),
            (0xBAAEE17F_A23EBF76, -1193, -340),
            (0x8B16FB20_3055AC76, -1166, -332),
            (0xCF42894A_5DCE35EA, -1140, -324),
            (0x9A6BB0AA_55653B2D, -1113, -316),
            (0xE61ACF03_3D1A45DF, -1087, -308),
            (0xAB70FE17_C79AC6CA, -1060, -300),
            (0xFF77B1FC_BEBCDC4F, -1034, -292),
            (0xBE5691EF_416BD60C, -1007, -284),
            (0x8DD01FAD_907FFC3C, -980, -276),
            (0xD3515C28_31559A83, -954, -268),
            (0x9D71AC8F_ADA6C9B5, -927, -260),
            (0xEA9C2277_23EE8BCB, -901, -252),
            (0xAECC4991_4078536D, -874, -244),
            (0x823C1279_5DB6CE57, -847, -236),
            (0xC2109436_4DFB5637, -821, -228),
            (0x9096EA6F_3848984F, -794, -220),
            (0xD77485CB_25823AC7, -768, -212),
            (0xA086CFCD_97BF97F4, -741, -204),
            (0xEF340A98_172AACE5, -715, -196),
            (0xB23867FB_2A35B28E, -688, -188),
            (0x84C8D4DF_D2C63F3B, -661, -180),
            (0xC5DD4427_1AD3CDBA, -635, -172),
            (0x936B9FCE_BB25C996, -608, -164),
            (0xDBAC6C24_7D62A584, -582, -156),
            (0xA3AB6658_0D5FDAF6, -555, -148),
            (0xF3E2F893_DEC3F126, -529, -140),
            (0xB5B5ADA8_AAFF80B8, -502, -132),
            (0x87625F05_6C7C4A8B, -475, -124),
            (0xC9BCFF60_34C13053, -449, -116),
            (0x964E858C_91BA2655, -422, -108),
            (0xDFF97724_70297EBD, -396, -100),
            (0xA6DFBD9F_B8E5B88F, -369, -92),
            (0xF8A95FCF_88747D94, -343, -84),
            (0xB9447093_8FA89BCF, -316, -76),
            (0x8A08F0F8_BF0F156B, -289, -68),
            (0xCDB02555_653131B6, -263, -60),
            (0x993FE2C6_D07B7FAC, -236, -52),
            (0xE45C10C4_2A2B3B06, -210, -44),
            (0xAA242499_697392D3, -183, -36),
            (0xFD87B5F2_8300CA0E, -157, -28),
            (0xBCE50864_92111AEB, -130, -20),
            (0x8CBCCC09_6F5088CC, -103, -12),
            (0xD1B71758_E219652C, -77, -4),
            (0x9C400000_00000000, -50, 4),
            (0xE8D4A510_00000000, -24, 12),
            (0xAD78EBC5_AC620000, 3, 20),
            (0x813F3978_F8940984, 30, 28),
            (0xC097CE7B_C90715B3, 56, 36),
            (0x8F7E32CE_7BEA5C70, 83, 44),
            (0xD5D238A4_ABE98068, 109, 52),
            (0x9F4F2726_179A2245, 136, 60),
            (0xED63A231_D4C4FB27, 162, 68),
            (0xB0DE6538_8CC8ADA8, 189, 76),
            (0x83C7088E_1AAB65DB, 216, 84),
            (0xC45D1DF9_42711D9A, 242, 92),
            (0x924D692C_A61BE758, 269, 100),
            (0xDA01EE64_1A708DEA, 295, 108),
            (0xA26DA399_9AEF774A, 322, 116),
            (0xF209787B_B47D6B85, 348, 124),
            (0xB454E4A1_79DD1877, 375, 132),
            (0x865B8692_5B9BC5C2, 402, 140),
            (0xC83553C5_C8965D3D, 428, 148),
            (0x952AB45C_FA97A0B3, 455, 156),
            (0xDE469FBD_99A05FE3, 481, 164),
            (0xA59BC234_DB398C25, 508, 172),
            (0xF6C69A72_A3989F5C, 534, 180),
            (0xB7DCBF53_54E9BECE, 561, 188),
            (0x88FCF317_F22241E2, 588, 196),
            (0xCC20CE9B_D35C78A5, 614, 204),
            (0x98165AF3_7B2153DF, 641, 212),
            (0xE2A0B5DC_971F303A, 667, 220),
            (0xA8D9D153_5CE3B396, 694, 228),
            (0xFB9B7CD9_A4A7443C, 720, 236),
            (0xBB764C4C_A7A44410, 747, 244),
            (0x8BAB8EEF_B6409C1A, 774, 252),
            (0xD01FEF10_A657842C, 800, 260),
            (0x9B10A4E5_E9913129, 827, 268),
            (0xE7109BFB_A19C0C9D, 853, 276),
            (0xAC2820D9_623BF429, 880, 284),
            (0x80444B5E_7AA7CF85, 907, 292),
            (0xBF21E440_03ACDD2D, 933, 300),
            (0x8E679C2F_5E44FF8F, 960, 308),
            (0xD433179D_9C8CB841, 986, 316),
            (0x9E19DB92_B4E31BA9, 1013, 324),
            (0xEB96BF6E_BADF77D9, 1039, 332),
            (0xAF87023B_9BF0EE6B, 1066, 340)
        };

        [NotNull]
        public static string DoubleToString(double value)
        {
            var buffer = stackalloc byte[100];
            DoubleToAscii(value, buffer, out var sign, out var length, out var decimalPoint);

            var builder = new StringBuilder();
            if (sign)
            {
                builder.Append('-');
            }

            if (length <= decimalPoint && decimalPoint <= 21)
            {
                // ECMA-262 section 9.8.1 step 6.
                AddString(builder, buffer, length);
                AddPadding(builder, '0', decimalPoint - length);

            }
            else if (0 < decimalPoint && decimalPoint <= 21)
            {
                // ECMA-262 section 9.8.1 step 7.
                AddString(builder, buffer, decimalPoint);
                builder.Append('.');
                AddString(builder, buffer + decimalPoint, length - decimalPoint);

            }
            else if (decimalPoint <= 0 && decimalPoint > -6)
            {
                // ECMA-262 section 9.8.1 step 8.
                builder.Append("0.");
                AddPadding(builder, '0', -decimalPoint);
                AddString(builder, buffer, length);

            }
            else
            {
                // ECMA-262 section 9.8.1 step 9 and 10 combined.
                builder.Append((char)buffer[0]);
                if (length != 1)
                {
                    builder.Append('.');
                    AddString(builder, buffer + 1, length - 1);
                }

                builder.Append('e');
                builder.Append(decimalPoint >= 0 ? '+' : '-');
                var exponent = decimalPoint - 1;
                if (exponent < 0) exponent = -exponent;
                builder.Append(exponent);
            }

            return builder.ToString();
        }

        private static void AddString(StringBuilder builder, byte* buffer, int length)
        {
            for (var i = 0; i < length; i++)
            {
                builder.Append((char)buffer[i]);
            }
        }

        private static void AddPadding(StringBuilder builder, char c, int length)
        {
            for (var i = 0; i < length; i++)
            {
                builder.Append(c);
            }
        }

        private static void DoubleToAscii(double value, byte* buffer, out bool sign, out int length, out int point)
        {
            if (value < 0)
            {
                sign = true;
                value = -value;
            }
            else
            {
                sign = false;
            }
            var fastWorked = FastDtoa(value, buffer, out length, out point);

            if (fastWorked)
            {
                return;
            }

            if (!fastWorked)
            {
                throw new NotImplementedException();
            }
        }

        private static bool FastDtoa(double value, byte* buffer, out int length, out int decimalPoint)
        {
            var result = Grisu3(value, buffer, out length, out var decimalExponent);

            if (result)
            {
                decimalPoint = length + decimalExponent;
            }
            else
            {
                decimalPoint = 0;
            }

            return result;
        }

        private static bool Grisu3(double value, byte* buffer, out int length, out int decimalExponent)
        {
            var w = AsNormalisedDiyFp(value);

            // boundary_minus and boundary_plus are the boundaries between v and its
            // closest floating-point neighbors. Any number strictly between
            // boundary_minus and boundary_plus will round to v when convert to a double.
            // Grisu3 will never output representations that lie exactly on a boundary.
            NormalisedBoundaries(value, out var boundaryMinus, out var boundaryPlus);

            Debug.Assert(boundaryPlus.Exponent == w.Exponent);

            var tenMkMinimalBinaryExponent = MINIMAL_TARGET_EXPONENT - (w.Exponent + DIY_FP_SIGNIFICAND_SIZE);
            var tenMkMaximalBinaryExponent = MAXIMAL_TARGET_EXPONENT - (w.Exponent + DIY_FP_SIGNIFICAND_SIZE);
            GetCachedPowerForBinaryExponentRange(tenMkMinimalBinaryExponent, tenMkMaximalBinaryExponent, out var tenMk, out var mk);
            Debug.Assert(MINIMAL_TARGET_EXPONENT <= w.Exponent + tenMk.Exponent + DIY_FP_SIGNIFICAND_SIZE &&
                         MAXIMAL_TARGET_EXPONENT >= w.Exponent + tenMk.Exponent + DIY_FP_SIGNIFICAND_SIZE);
            // Note that ten_mk is only an approximation of 10^-k. A DiyFp only contains a
            // 64 bit significand and ten_mk is thus only precise up to 64 bits.

            // The DiyFp::Times procedure rounds its result, and ten_mk is approximated
            // too. The variable scaled_w (as well as scaled_boundary_minus/plus) are now
            // off by a small amount.
            // In fact: scaled_w - w*10^k < 1ulp (unit in the last place) of scaled_w.
            // In other words: let f = scaled_w.f() and e = scaled_w.e(), then
            //           (f-1) * 2^e < w*10^k < (f+1) * 2^e
            var scaledW = Times(w, tenMk);
            Debug.Assert(scaledW.Exponent == boundaryPlus.Exponent + tenMk.Exponent + DIY_FP_SIGNIFICAND_SIZE);
            // In theory it would be possible to avoid some recomputations by computing
            // the difference between w and boundary_minus/plus (a power of 2) and to
            // compute scaled_boundary_minus/plus by subtracting/adding from
            // scaled_w. However the code becomes much less readable and the speed
            // enhancements are not terriffic.
            var scaledBoundaryMinus = Times(boundaryMinus, tenMk);
            var scaledBoundaryPlus = Times(boundaryPlus, tenMk);

            // DigitGen will generate the digits of scaled_w. Therefore we have
            // v == (double) (scaled_w * 10^-mk).
            // Set decimal_exponent == -mk and pass it to DigitGen. If scaled_w is not an
            // integer than it will be updated. For instance if scaled_w == 1.23 then
            // the buffer will be filled with "123" und the decimal_exponent will be
            // decreased by 2.

            var result = DigitGen(scaledBoundaryMinus, scaledW, scaledBoundaryPlus, buffer, out length, out var kappa);
            decimalExponent = -mk + kappa;
            return result;
        }

        // Generates the digits of input number w.
        // w is a floating-point number (DiyFp), consisting of a significand and an
        // exponent. Its exponent is bounded by kMinimalTargetExponent and
        // kMaximalTargetExponent.
        //       Hence -60 <= w.e() <= -32.
        //
        // Returns false if it fails, in which case the generated digits in the buffer
        // should not be used.
        // Preconditions:
        //  * low, w and high are correct up to 1 ulp (unit in the last place). That
        //    is, their error must be less than a unit of their last digits.
        //  * low.e() == w.e() == high.e()
        //  * low < w < high, and taking into account their error: low~ <= high~
        //  * kMinimalTargetExponent <= w.e() <= kMaximalTargetExponent
        // Postconditions: returns false if procedure fails.
        //   otherwise:
        //     * buffer is not null-terminated, but len contains the number of digits.
        //     * buffer contains the shortest possible decimal digit-sequence
        //       such that LOW < buffer * 10^kappa < HIGH, where LOW and HIGH are the
        //       correct values of low and high (without their error).
        //     * if more than one decimal representation gives the minimal number of
        //       decimal digits then the one closest to W (where W is the correct value
        //       of w) is chosen.
        // Remark: this procedure takes into account the imprecision of its input
        //   numbers. If the precision is not enough to guarantee all the postconditions
        //   then false is returned. This usually happens rarely (~0.5%).
        //
        // Say, for the sake of example, that
        //   w.e() == -48, and w.f() == 0x1234567890ABCDEF
        // w's value can be computed by w.f() * 2^w.e()
        // We can obtain w's integral digits by simply shifting w.f() by -w.e().
        //  -> w's integral part is 0x1234
        //  w's fractional part is therefore 0x567890ABCDEF.
        // Printing w's integral part is easy (simply print 0x1234 in decimal).
        // In order to print its fraction we repeatedly multiply the fraction by 10 and
        // get each digit. Example the first digit after the point would be computed by
        //   (0x567890ABCDEF * 10) >> 48. -> 3
        // The whole thing becomes slightly more complicated because we want to stop
        // once we have enough digits. That is, once the digits inside the buffer
        // represent 'w' we can stop. Everything inside the interval low - high
        // represents w. However we have to pay attention to low, high and w's
        // imprecision.
        private static bool DigitGen((ulong Significand, int Exponent) low, (ulong Significand, int Exponent) w, (ulong Significand, int Exponent) high, byte* buffer, out int length, out int kappa)
        {
            Debug.Assert(low.Exponent == w.Exponent && w.Exponent == high.Exponent);
            Debug.Assert(low.Significand + 1 <= high.Significand - 1);
            Debug.Assert(MINIMAL_TARGET_EXPONENT <= w.Exponent && w.Exponent <= MAXIMAL_TARGET_EXPONENT);
            // low, w and high are imprecise, but by less than one ulp (unit in the last
            // place).
            // If we remove (resp. add) 1 ulp from low (resp. high) we are certain that
            // the new numbers are outside of the interval we want the final
            // representation to lie in.
            // Inversely adding (resp. removing) 1 ulp from low (resp. high) would yield
            // numbers that are certain to lie in the interval. We will use this fact
            // later on.
            // We will now start by generating the digits within the uncertain
            // interval. Later we will weed out representations that lie outside the safe
            // interval and thus _might_ lie outside the correct interval.
            ulong unit = 1;
            var tooLow = (Significand: low.Significand - unit, low.Exponent);
            var tooHigh = (Significand: high.Significand + unit, high.Exponent);
            // too_low and too_high are guaranteed to lie outside the interval we want the
            // generated number in.
            var unsafeInterval = Minus(tooHigh, tooLow);
            // We now cut the input number into two parts: the integral digits and the
            // fractionals. We will not write any decimal separator though, but adapt
            // kappa instead.
            // Reminder: we are currently computing the digits (stored inside the buffer)
            // such that:   too_low < buffer * 10^kappa < too_high
            // We use too_high for the digit_generation and stop as soon as possible.
            // If we stop early we effectively round down.
            var one = (Significand: 1UL << -w.Exponent, w.Exponent);
            // Division by one is a shift.
            var integrals = (uint)(tooHigh.Significand >> -one.Exponent);
            // Modulo by one is an and.
            var fractionals = tooHigh.Significand & (one.Significand - 1);
            BiggestPowerTen(integrals, DIY_FP_SIGNIFICAND_SIZE + one.Exponent, out var divisor, out var divisorExponent);
            kappa = divisorExponent + 1;
            length = 0;
            // Loop invariant: buffer = too_high / 10^kappa  (integer division)
            // The invariant holds for the first iteration: kappa has been initialized
            // with the divisor exponent + 1. And the divisor is the biggest power of ten
            // that is smaller than integrals.
            while (kappa > 0)
            {
                var digit = integrals / divisor;
                buffer[length] = (byte)('0' + digit);
                length++;
                integrals %= divisor;
                kappa--;
                // Note that kappa now equals the exponent of the divisor and that the
                // invariant thus holds again.
                var rest = ((ulong)integrals << -one.Exponent) + fractionals;
                // Invariant: too_high = buffer * 10^kappa + DiyFp(rest, one.e())
                // Reminder: unsafe_interval.e() == one.e()
                if (rest < unsafeInterval.Significand)
                {
                    // Rounding down (by not emitting the remaining digits) yields a number
                    // that lies within the unsafe interval.
                    return RoundWeed(buffer, length, Minus(tooHigh, w).Significand, unsafeInterval.Significand, rest, (ulong)divisor << -one.Exponent, unit);
                }

                divisor /= 10;
            }

            // The integrals have been generated. We are at the point of the decimal
            // separator. In the following loop we simply multiply the remaining digits by
            // 10 and divide by one. We just need to pay attention to multiply associated
            // data (like the interval or 'unit'), too.
            // Note that the multiplication by 10 does not overflow, because w.e >= -60
            // and thus one.e >= -60.
            Debug.Assert(one.Exponent >= -60);
            Debug.Assert(fractionals < one.Significand);
            Debug.Assert(0xFFFFFFFF_FFFFFFFF / 10 >= one.Significand);
            while (true)
            {
                fractionals *= 10;
                unit *= 10;
                unsafeInterval.Significand *= 10;
                // Integer division by one.
                var digit = (int)(fractionals >> -one.Exponent);
                buffer[length] = (byte)('0' + digit);
                length++;
                fractionals &= one.Significand - 1; // Modulo by one.
                kappa--;
                if (fractionals < unsafeInterval.Significand)
                {
                    return RoundWeed(buffer, length, Minus(tooHigh, w).Significand * unit, unsafeInterval.Significand, fractionals, one.Significand, unit);
                }
            }
        }

        // Adjusts the last digit of the generated number, and screens out generated
        // solutions that may be inaccurate. A solution may be inaccurate if it is
        // outside the safe interval, or if we ctannot prove that it is closer to the
        // input than a neighboring representation of the same length.
        //
        // Input: * buffer containing the digits of too_high / 10^kappa
        //        * the buffer's length
        //        * distance_too_high_w == (too_high - w).f() * unit
        //        * unsafe_interval == (too_high - too_low).f() * unit
        //        * rest = (too_high - buffer * 10^kappa).f() * unit
        //        * ten_kappa = 10^kappa * unit
        //        * unit = the common multiplier
        // Output: returns true if the buffer is guaranteed to contain the closest
        //    representable number to the input.
        //  Modifies the generated digits in the buffer to approach (round towards) w.
        private static bool RoundWeed(byte* buffer, int length, ulong distanceTooHighW, ulong unsafeInterval, ulong rest, ulong tenKappa, ulong unit)
        {
            var smallDistance = distanceTooHighW - unit;
            var bigDistance = distanceTooHighW + unit;
            // Let w_low  = too_high - big_distance, and
            //     w_high = too_high - small_distance.
            // Note: w_low < w < w_high
            //
            // The real w (* unit) must lie somewhere inside the interval
            // ]w_low; w_high[ (often written as "(w_low; w_high)")

            // Basically the buffer currently contains a number in the unsafe interval
            // ]too_low; too_high[ with too_low < w < too_high
            //
            //  too_high - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
            //                     ^v 1 unit            ^      ^                 ^      ^
            //  boundary_high ---------------------     .      .                 .      .
            //                     ^v 1 unit            .      .                 .      .
            //   - - - - - - - - - - - - - - - - - - -  +  - - + - - - - - -     .      .
            //                                          .      .         ^       .      .
            //                                          .  big_distance  .       .      .
            //                                          .      .         .       .    rest
            //                              small_distance     .         .       .      .
            //                                          v      .         .       .      .
            //  w_high - - - - - - - - - - - - - - - - - -     .         .       .      .
            //                     ^v 1 unit                   .         .       .      .
            //  w ----------------------------------------     .         .       .      .
            //                     ^v 1 unit                   v         .       .      .
            //  w_low  - - - - - - - - - - - - - - - - - - - - -         .       .      .
            //                                                           .       .      v
            //  buffer --------------------------------------------------+-------+--------
            //                                                           .       .
            //                                                  safe_interval    .
            //                                                           v       .
            //   - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -     .
            //                     ^v 1 unit                                     .
            //  boundary_low -------------------------                     unsafe_interval
            //                     ^v 1 unit                                     v
            //  too_low  - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
            //
            //
            // Note that the value of buffer could lie anywhere inside the range too_low
            // to too_high.
            //
            // boundary_low, boundary_high and w are approximations of the real boundaries
            // and v (the input number). They are guaranteed to be precise up to one unit.
            // In fact the error is guaranteed to be strictly less than one unit.
            //
            // Anything that lies outside the unsafe interval is guaranteed not to round
            // to v when read again.
            // Anything that lies inside the safe interval is guaranteed to round to v
            // when read again.
            // If the number inside the buffer lies inside the unsafe interval but not
            // inside the safe interval then we simply do not know and bail out (returning
            // false).
            //
            // Similarly we have to take into account the imprecision of 'w' when finding
            // the closest representation of 'w'. If we have two potential
            // representations, and one is closer to both w_low and w_high, then we know
            // it is closer to the actual value v.
            //
            // By generating the digits of too_high we got the largest (closest to
            // too_high) buffer that is still in the unsafe interval. In the case where
            // w_high < buffer < too_high we try to decrement the buffer.
            // This way the buffer approaches (rounds towards) w.
            // There are 3 conditions that stop the decrementation process:
            //   1) the buffer is already below w_high
            //   2) decrementing the buffer would make it leave the unsafe interval
            //   3) decrementing the buffer would yield a number below w_high and farther
            //      away than the current number. In other words:
            //              (buffer{-1} < w_high) && w_high - buffer{-1} > buffer - w_high
            // Instead of using the buffer directly we use its distance to too_high.
            // Conceptually rest ~= too_high - buffer
            // We need to do the following tests in this order to avoid over- and
            // underflows.
            Debug.Assert(rest <= unsafeInterval);
            while (rest < smallDistance && // Negated condition 1
                   unsafeInterval - rest >= tenKappa && // Negated condition 2
                   (rest + tenKappa < smallDistance || // buffer{-1} > w_high
                    smallDistance - rest >= rest + tenKappa - smallDistance))
            {
                buffer[length - 1]--;
                rest += tenKappa;
            }

            // We have approached w+ as much as possible. We now test if approaching w-
            // would require changing the buffer. If yes, then we have two possible
            // representations close to w, but we cannot decide which one is closer.
            if (rest < bigDistance &&
                unsafeInterval - rest >= tenKappa &&
                (rest + tenKappa < bigDistance ||
                 bigDistance - rest > rest + tenKappa - bigDistance))
            {
                return false;
            }

            // Weeding test.
            //   The safe interval is [too_low + 2 ulp; too_high - 2 ulp]
            //   Since too_low = too_high - unsafe_interval this is equivalent to
            //      [too_high - unsafe_interval + 4 ulp; too_high - 2 ulp]
            //   Conceptually we have: rest ~= too_high - buffer
            return 2 * unit <= rest && rest <= unsafeInterval - 4 * unit;
        }

        private static (ulong Significand, int Exponent) AsDiyFp(double value)
        {
            var bits = (ulong)BitConverter.DoubleToInt64Bits(value);
            var significand = bits & SIGNIFICAND_MASK;
            int exponent;

            // Is denormal
            if ((bits & EXPONENT_MASK) != 0)
            {
                significand += HIDDEN_BIT;
                exponent = (int)((bits & EXPONENT_MASK) >> PHYSICAL_SIGNIFICAND_SIZE) - EXPONENT_BIAS;
            }
            else
            {
                exponent = DENORMAL_EXPONENT;
            }

            return (significand, exponent);
        }

        private static (ulong Significand, int Exponent) AsNormalisedDiyFp(double value)
        {
            var (significand, exponent) = AsDiyFp(value);

            // The current double could be a denormal.
            while ((significand & HIDDEN_BIT) == 0)
            {
                significand <<= 1;
                exponent--;
            }

            significand <<= DIY_FP_SIGNIFICAND_SIZE - SIGNIFICAND_SIZE;
            exponent -= DIY_FP_SIGNIFICAND_SIZE - SIGNIFICAND_SIZE;

            return (significand, exponent);
        }

        // Returns the two boundaries of this.
        // The bigger boundary (m_plus) is normalized. The lower boundary has the same
        // exponent as m_plus.
        // Precondition: the value encoded by this Double must be greater than 0.
        private static void NormalisedBoundaries(double value, out (ulong Significand, int Exponent) minus, out (ulong Significand, int Exponent) plus)
        {
            var v = AsDiyFp(value);
            var significandZero = v.Significand == HIDDEN_BIT;
            plus = DiyFpNormalise(((v.Significand << 1) + 1, v.Exponent - 1));

            if (significandZero && v.Exponent != DENORMAL_EXPONENT)
            {
                // The boundary is closer. Think of v = 1000e10 and v- = 9999e9.
                // Then the boundary (== (v - v-)/2) is not just at a distance of 1e9 but
                // at a distance of 1e8.
                // The only exception is for the smallest normal: the largest denormal is
                // at the same distance as its successor.
                // Note: denormals have the same exponent as the smallest normals.
                minus = ((v.Significand << 2) - 1, v.Exponent - 2);
            }
            else
            {
                minus = ((v.Significand << 1) - 1, v.Exponent - 1);
            }

            minus.Significand = minus.Significand << (minus.Exponent - plus.Exponent);
            minus.Exponent = plus.Exponent;
        }

        private static (ulong Significand, int Exponent) DiyFpNormalise((ulong Significand, int Exponent) value)
        {
            // This method is mainly called for normalizing boundaries. In general
            // boundaries need to be shifted by 10 bits. We thus optimize for this case.
            while ((value.Significand & 0xFFC0_0000_0000_0000UL) == 0)
            {
                value.Significand <<= 10;
                value.Exponent -= 10;
            }

            while ((value.Significand & 0x8000_0000_0000_0000UL) == 0)
            {
                value.Significand <<= 1;
                value.Exponent--;
            }

            return value;
        }

        private static void GetCachedPowerForBinaryExponentRange(int minExponent, int maxExponent, out (ulong Significand, int Exponent) power, out int decimalExponent)
        {
            const double D_1_LOG2_10 = 0.30102999566398114; //  1 / lg(10)
            const int K_Q = DIY_FP_SIGNIFICAND_SIZE;
            // Some platforms return incorrect sign on 0 result. We can ignore that here,
            // which means we can avoid depending on platform.h.
            var k = Math.Ceiling((minExponent + K_Q - 1) * D_1_LOG2_10);
            var index = (CACHED_POWERS_OFFSET + (int)k - 1) / DECIMAL_EXPONENT_DISTANCE + 1;
            Debug.Assert(index >= 0 && index < cachedPowers.Length);
            ref var cachedPower = ref cachedPowers[index];
            Debug.Assert(minExponent <= cachedPower.BinaryExponent);
            Debug.Assert(cachedPower.BinaryExponent <= maxExponent);
            decimalExponent = cachedPower.DecimalExponent;
            power = (cachedPower.Significand, cachedPower.BinaryExponent);
        }

        // Returns the biggest power of ten that is less than or equal than the given
        // number. We furthermore receive the maximum number of bits 'number' has.
        // If number_bits == 0 then 0^-1 is returned
        // The number of bits must be <= 32.
        // Precondition: number < (1 << (number_bits + 1)).
        private static void BiggestPowerTen(uint number, int numberBits, out uint power, out int exponent)
        {
            switch (numberBits)
            {
                case 32:
                case 31:
                case 30:
                    if (1000000000 <= number)
                    {
                        power = 1000000000;
                        exponent = 9;
                        break;
                    }

                    goto case 29;
                case 29:
                case 28:
                case 27:
                    if (100000000 <= number)
                    {
                        power = 100000000;
                        exponent = 8;
                        break;
                    }

                    goto case 27;
                case 26:
                case 25:
                case 24:
                    if (10000000 <= number)
                    {
                        power = 10000000;
                        exponent = 7;
                        break;
                    }

                    goto case 23;
                case 23:
                case 22:
                case 21:
                case 20:
                    if (1000000 <= number)
                    {
                        power = 1000000;
                        exponent = 6;
                        break;
                    }

                    goto case 19;
                case 19:
                case 18:
                case 17:
                    if (100000 <= number)
                    {
                        power = 100000;
                        exponent = 5;
                        break;
                    }

                    goto case 16;
                case 16:
                case 15:
                case 14:
                    if (10000 <= number)
                    {
                        power = 10000;
                        exponent = 4;
                        break;
                    }

                    goto case 13;
                case 13:
                case 12:
                case 11:
                case 10:
                    if (1000 <= number)
                    {
                        power = 1000;
                        exponent = 3;
                        break;
                    }

                    goto case 9;
                case 9:
                case 8:
                case 7:
                    if (100 <= number)
                    {
                        power = 100;
                        exponent = 2;
                        break;
                    }

                    goto case 6;
                case 6:
                case 5:
                case 4:
                    if (10 <= number)
                    {
                        power = 10;
                        exponent = 1;
                        break;
                    }

                    goto case 3;
                case 3:
                case 2:
                case 1:
                    if (1 <= number)
                    {
                        power = 1;
                        exponent = 0;
                        break;
                    }

                    goto case 0;
                case 0:
                    power = 0;
                    exponent = -1;
                    break;

                default:
                    throw new InvalidOperationException();
            }
        }

        private static (ulong Significand, int Exponent) Minus((ulong Significand, int Exponent) lhs, (ulong Significand, int Exponent) rhs)
        {
            Debug.Assert(lhs.Exponent == rhs.Exponent);
            Debug.Assert(lhs.Significand >= rhs.Significand);
            return (lhs.Significand - rhs.Significand, lhs.Exponent);
        }

        private static (ulong Significand, int Exponent) Times((ulong Significand, int Exponent) lhs, (ulong Significand, int Exponent) rhs)
        {
            // Simply "emulates" a 128 bit multiplication.
            // However: the resulting number only contains 64 bits. The least
            // significant 64 bits are only used for rounding the most significant 64
            // bits.
            const ulong M32 = 0xFFFFFFFF;
            var a = lhs.Significand >> 32;
            var b = lhs.Significand & M32;
            var c = rhs.Significand >> 32;
            var d = rhs.Significand & M32;
            var ac = a * c;
            var bc = b * c;
            var ad = a * d;
            var bd = b * d;
            var tmp = (bd >> 32) + (ad & M32) + (bc & M32);
            // By adding 1U << 31 to tmp we round the final result.
            // Halfway cases will be round up.
            tmp += 1U << 31;
            var resultSignificand = ac + (ad >> 32) + (bc >> 32) + (tmp >> 32);
            return (resultSignificand, lhs.Exponent + rhs.Exponent + 64);
        }
    }
}