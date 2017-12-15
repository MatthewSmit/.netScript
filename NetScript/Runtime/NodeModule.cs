using System;
using System.Collections.Generic;
using AcornSharp.Node;
using JetBrains.Annotations;
using NetScript.Walkers;

namespace NetScript.Runtime
{
    internal sealed class NodeModule : IModule
    {
        [NotNull] private readonly ProgramNode node;

        public NodeModule([NotNull] ProgramNode node)
        {
            this.node = node;
        }

        public ScriptValue Evaluate(ExecutionContext context)
        {
            return EvaluateWalker.Walk(node.Body, context).Value;
        }

        public void Initialise()
        {
            var requestedModules = ModuleRequests();
            var importEntries = ImportEntries();
            //Let importedBoundNames be ImportedLocalNames(importEntries).
            //Let indirectExportEntries be a new empty List.
            //Let localExportEntries be a new empty List.
            //Let starExportEntries be a new empty List.
            var exportEntries = ExportEntries();
            //For each ExportEntry Record ee in exportEntries, do
            //
            //    If ee.[[ModuleRequest]] is null, then
            //        If ee.[[LocalName]] is not an element of importedBoundNames, then
            //            Append ee to localExportEntries.
            //        Else,
            //            Let ie be the element of importEntries whose [[LocalName]] is the same as ee.[[LocalName]].
            //            If ie.[[ImportName]] is "*", then
            //                Assert: This is a re-export of an imported module namespace object.
            //                Append ee to localExportEntries.
            //            Else this is a re-export of a single name,
            //                Append the ExportEntry Record {[[ModuleRequest]]: ie.[[ModuleRequest]], [[ImportName]]: ie.[[ImportName]], [[LocalName]]: null, [[ExportName]]: ee.[[ExportName]] } to indirectExportEntries.
            //    Else if ee.[[ImportName]] is "*", then
            //        Append ee to starExportEntries.
            //    Else,
            //        Append ee to indirectExportEntries.
            //
            //[[Status]]: "uninstantiated", [[RequestedModules]]: requestedModules, [[ImportEntries]]: importEntries, [[LocalExportEntries]]: localExportEntries, [[IndirectExportEntries]]: indirectExportEntries, [[StarExportEntries]]: starExportEntries
//            throw new NotImplementedException();
        }

        private object ModuleRequests()
        {
            foreach (var baseNode in node.Body)
            {
                switch (baseNode)
                {
                    case ImportDeclarationNode _:
                    case ImportDefaultSpecifierNode _:
                    case ImportNamespaceSpecifierNode _:
                    case ImportSpecifierNode _:
                    case ExportAllDeclarationNode _:
                    case ExportDefaultDeclarationNode _:
                    case ExportNamedDeclarationNode _:
                    case ExportSpecifierNode _:
                        throw new NotImplementedException();
                }
            }

            return null;
        }

        private object ImportEntries()
        {
            foreach (var baseNode in node.Body)
            {
                switch (baseNode)
                {
                    case ImportDeclarationNode _:
                    case ImportDefaultSpecifierNode _:
                    case ImportNamespaceSpecifierNode _:
                    case ImportSpecifierNode _:
                    case ExportAllDeclarationNode _:
                    case ExportDefaultDeclarationNode _:
                    case ExportNamedDeclarationNode _:
                    case ExportSpecifierNode _:
                        throw new NotImplementedException();
                }
            }

            return null;
        }

        private object ExportEntries()
        {
            foreach (var baseNode in node.Body)
            {
                switch (baseNode)
                {
                    case ImportDeclarationNode _:
                    case ImportDefaultSpecifierNode _:
                    case ImportNamespaceSpecifierNode _:
                    case ImportSpecifierNode _:
                    case ExportAllDeclarationNode _:
                    case ExportDefaultDeclarationNode _:
                    case ExportNamedDeclarationNode _:
                    case ExportSpecifierNode _:
                        throw new NotImplementedException();
                }
            }

            return null;
        }

        public void HandleEarlyErrors(Agent agent, bool strictEval)
        {
            EarlyErrorWalker.Walk(agent, node, Strict);
        }

        public void HandleEvalEarlyErrors(Agent agent, bool inFunction, bool inMethod, bool inDerivedConstructor)
        {
            throw new NotImplementedException();
        }

        public bool Strict => node.Body.Count > 0 &&
                              node.Body[0] is ExpressionStatementNode expression &&
                              expression.Expression is LiteralNode literal &&
                              literal.Value.IsString &&
                              literal.Value.AsString == "use strict";

        public IList<string> LexicallyDeclaredNames
        {
            get
            {
                var list = new List<string>();
                LexicallyDeclaredNamesWalker.Walk(node, list);
                return list;
            }
        }

        public IList<IDeclaration> LexicallyScopedDeclarations
        {
            get
            {
                var list = new List<IDeclaration>();
                LexicallyScopedDeclarationsWalker.Walk(node, list);
                return list;
            }
        }

        public IList<string> VarDeclaredNames
        {
            get
            {
                var list = new List<string>();
                VarDeclaredNamesWalker.Walk(node, list);
                return list;
            }
        }

        public IList<IDeclaration> VarScopedDeclarations
        {
            get
            {
                var list = new List<IDeclaration>();
                VarScopedDeclarationsWalker.Walk(node, list);
                return list;
            }
        }
    }
}