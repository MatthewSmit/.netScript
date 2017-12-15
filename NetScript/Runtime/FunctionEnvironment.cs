﻿using System.Diagnostics;
{
    internal sealed class FunctionEnvironment : DeclarativeEnvironment
    {
        private ThisBindingStatus thisBindingStatus;
        private readonly ScriptObject homeObject;
            //https://tc39.github.io/ecma262/#sec-bindthisvalue
            Debug.Assert(thisBindingStatus != ThisBindingStatus.Lexical);
            //https://tc39.github.io/ecma262/#sec-function-environment-records-getthisbinding
            Debug.Assert(thisBindingStatus != ThisBindingStatus.Lexical);
}