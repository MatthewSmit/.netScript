namespace NetScript.Runtime.Objects
{
    internal enum FunctionKind
    {
        Normal,
        ClassConstructor,
        NonConstructor,
        Generator,
        Async,
        Arrow,
        Method
    }
}