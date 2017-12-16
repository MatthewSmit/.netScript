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
            var strict = agent.RunningExecutionContext.Strict ||
                         functionNode.Id == null ||
                         functionNode.Body is BlockStatementNode block &&
                         block.Body.Count > 0 &&
                         block.Body[0] is ExpressionStatementNode expression &&
                         expression.Expression is LiteralNode literal &&
                         literal.Value.IsString &&
                         literal.Value.AsString == "use strict";

            ScriptFunctionObject function;
            if (functionNode.Async)
            {
                //https://tc39.github.io/ecma262/#sec-async-function-definitions-InstantiateFunctionObject
                throw new NotImplementedException();
            }
            else if (functionNode.Generator)
            {
                //https://tc39.github.io/ecma262/#sec-generator-function-definitions-runtime-semantics-instantiatefunctionobject
                if (functionNode.Id == null)
                {
                    throw new NotImplementedException();
                }

                function = agent.GeneratorFunctionCreate(FunctionKind.Normal, functionNode.Parameters, functionNode.Body, scope, strict);
                var prototype = agent.ObjectCreate(agent.Realm.GeneratorPrototype);
                agent.DefinePropertyOrThrow(function, "prototype", new PropertyDescriptor(prototype, true, false, false));
            }
            else
            {
                //https://tc39.github.io/ecma262/#sec-function-definitions-runtime-semantics-instantiatefunctionobject
                function = agent.FunctionCreate(FunctionKind.Normal, functionNode.Parameters, functionNode.Body, scope, strict);
                agent.MakeConstructor(function);
            }

            agent.SetFunctionName(function, functionNode.Id?.Name ?? "default");
            return function;
        }

        public IEnumerable<string> BoundNames => BoundNamesWalker.Walk(node);

        public bool IsFunction => node is FunctionDeclarationNode;
        public bool IsVariable => node is VariableDeclaratorNode variableDeclaratorNode && variableDeclaratorNode.Kind == VariableKind.Var;
        public bool IsConstant => node is VariableDeclaratorNode variableDeclaratorNode && variableDeclaratorNode.Kind == VariableKind.Const;
    }
}