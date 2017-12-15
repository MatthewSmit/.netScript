using JetBrains.Annotations;

namespace NetScript.Runtime
{
    /// <summary>
    /// Options used to customise script compilation and excecution.
    /// </summary>
    public struct ScriptOptions
    {
        /// <summary>
        /// The user friendly name for the script, used in stack calls and error messages.
        /// </summary>
        [CanBeNull] public string ScriptName;

        public ScriptType Type;

        public bool ForceStrict;
    }
}