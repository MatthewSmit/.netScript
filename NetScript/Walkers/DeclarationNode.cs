using System;
using System.Collections.Generic;
using AcornSharp;
using AcornSharp.Node;
using JetBrains.Annotations;
using NetScript.Runtime;
using NetScript.Runtime.Objects;

namespace NetScript.Walkers
{
    internal sealed class DeclarationNode : IDeclaration
    {
        private readonly BaseNode node;

        public DeclarationNode(BaseNode node)
        {
            this.node = node;
        }

        [NotNull]
        public ScriptFunctionObject InstantiateFunctionObject(Agent agent, LexicalEnvironment scope)
        {
            if (!IsFunction)
            {
                throw new InvalidOperationException();
            }

            var functionNode = (FunctionDeclarationNode)node;

            if (functionNode.Async)
            {
                throw new NotImplementedException();
            }

            if (functionNode.Generator)
            {
                throw new NotImplementedException();
            }

            if (functionNode.Id == null)
            {
                throw new NotImplementedException();
            }

            var strict = agent.RunningExecutionContext.Strict ||
                         functionNode.Body is BlockStatementNode block &&
                         block.Body.Count > 0 &&
                         block.Body[0] is ExpressionStatementNode expression &&
                         expression.Expression is LiteralNode literal &&
                         literal.Value.IsString &&
                         literal.Value.AsString == "use strict";

            var name = functionNode.Id.Name;
            var function = agent.FunctionCreate(FunctionKind.Normal, functionNode.Parameters, functionNode.Body, scope, strict);

            agent.MakeConstructor(function);
            agent.SetFunctionName(function, name);

            return function;
        }

        public IEnumerable<string> BoundNames => BoundNamesWalker.Walk(node);

        public bool IsFunction => node is FunctionDeclarationNode;
        public bool IsVariable => node is VariableDeclaratorNode variableDeclaratorNode && variableDeclaratorNode.Kind == VariableKind.Var;
        public bool IsConstant => node is VariableDeclaratorNode variableDeclaratorNode && variableDeclaratorNode.Kind == VariableKind.Const;
    }
}