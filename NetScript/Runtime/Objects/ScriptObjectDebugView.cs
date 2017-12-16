using System.Collections.Generic;
using JetBrains.Annotations;

namespace NetScript.Runtime.Objects
{
    internal sealed class ScriptObjectDebugView
    {
        private readonly ScriptObject scriptObject;

        public ScriptObjectDebugView(ScriptObject scriptObject)
        {
            this.scriptObject = scriptObject;
        }

        [NotNull]
        public string Type => scriptObject.TypeOf;

        [CanBeNull]
        public ScriptObject Prototype => scriptObject.GetPrototypeOf();

        [NotNull]
        public IReadOnlyList<KeyValuePair<ScriptValue, ScriptValue>> Properties
        {
            get
            {
                var list = new List<KeyValuePair<ScriptValue, ScriptValue>>();
                foreach (var propertyKey in scriptObject.OwnPropertyKeys())
                {
                    var value = scriptObject.Get(propertyKey);
                    list.Add(new KeyValuePair<ScriptValue, ScriptValue>(propertyKey, value));
                }

                return list;
            }
        }
    }
}