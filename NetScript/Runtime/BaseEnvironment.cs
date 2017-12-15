namespace NetScript.Runtime
{
    internal abstract class BaseEnvironment
    {
        public abstract bool HasBinding(ScriptValue name);
        public abstract void CreateMutableBinding(ScriptValue name, bool deletable);
        public abstract void CreateImmutableBinding(ScriptValue name, bool strict);
        public abstract void InitialiseBinding(ScriptValue name, ScriptValue value);
        public abstract void SetMutableBinding(ScriptValue name, ScriptValue value, bool strict);
        public abstract ScriptValue GetBindingValue(ScriptValue name, bool strict);
        public abstract bool DeleteBinding(ScriptValue name);
        public abstract bool HasThisBinding();
        public abstract bool HasSuperBinding();
        public abstract ScriptValue WithBaseObject();
        public abstract ScriptValue GetThisBinding();
        public abstract ScriptValue GetSuperBase();
    }
}