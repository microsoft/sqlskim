// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.IO;

using Microsoft.CodeAnalysis.Sarif.Driver.Sdk;
using Microsoft.CodeAnalysis.Sarif.Sdk;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Microsoft.CodeAnalysis.Sql
{
    public class VisitCommand : DriverCommand<VisitOptions>
    {
        public override int Run(VisitOptions options)
        {
            int result = FAILURE;

            try
            {
                TSqlFragment tsqlFragment;

                var parser = new TSql120Parser(initialQuotedIdentifiers: false);

                IList<ParseError> errors;
                using (StringReader reader = new StringReader(File.ReadAllText(options.FilePath)))
                {
                    tsqlFragment = parser.Parse(reader, out errors);
                }

                if (errors.Count > 0)
                {
                    WriteErrorsToConsole(errors, options.FilePath);
                    return result;
                }

                var visitor = new DumpStructureVisitor();
                tsqlFragment.Accept(visitor);

                result = SUCCESS;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return result;
        }

        private void WriteErrorsToConsole(IList<ParseError> errors, string filePath)
        {
            SqlFileContext context = new SqlFileContext()
            {
                TargetUri = new Uri(filePath, UriKind.Absolute),
                Rule = ErrorDescriptors.ParseError
            };

            foreach (ParseError parseError in errors)
            {
                var region = new Region();

                region.StartLine = parseError.Line;
                region.StartColumn = parseError.Column;

                string message = ConsoleLogger.GetMessageText(context, parseError.Message, ResultKind.Error, region);
                Console.WriteLine(message);
            }
        }
        private class DumpStructureVisitor : TSqlFragmentVisitor
        {
            int indent;

            private const int INDENT_SIZE = 3;

            public override void ExplicitVisit(CreateEventSessionStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(EventDeclaration node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(EventDeclarationSetParameter node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SourceDeclaration node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(EventDeclarationCompareFunctionParameter node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(TargetDeclaration node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SessionOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(EventRetentionSessionOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(MemoryPartitionSessionOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(LiteralSessionOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(MaxDispatchLatencySessionOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(OnOffSessionOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterEventSessionStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropEventSessionStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterResourceGovernorStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CreateSpatialIndexStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SpatialIndexOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SpatialIndexRegularOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(BoundingBoxSpatialIndexOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(BoundingBoxParameter node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(GridsSpatialIndexOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(GridParameter node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CellsPerObjectSpatialIndexOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterServerConfigurationStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ProcessAffinityRange node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterServerConfigurationSetBufferPoolExtensionStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterServerConfigurationBufferPoolExtensionOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterServerConfigurationBufferPoolExtensionContainerOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterServerConfigurationBufferPoolExtensionSizeOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterServerConfigurationSetDiagnosticsLogStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterServerConfigurationDiagnosticsLogOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterServerConfigurationDiagnosticsLogMaxSizeOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterServerConfigurationSetFailoverClusterPropertyStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterServerConfigurationFailoverClusterPropertyOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterServerConfigurationSetHadrClusterStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterServerConfigurationHadrClusterOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AvailabilityGroupStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CreateAvailabilityGroupStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterAvailabilityGroupStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AvailabilityReplica node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AvailabilityReplicaOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(LiteralReplicaOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AvailabilityModeReplicaOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(FailoverModeReplicaOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(PrimaryRoleReplicaOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SecondaryRoleReplicaOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AvailabilityGroupOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(LiteralAvailabilityGroupOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterAvailabilityGroupAction node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterAvailabilityGroupFailoverAction node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterAvailabilityGroupFailoverOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropAvailabilityGroupStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CreateFederationStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterFederationStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropFederationStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(UseFederationStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DiskStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DiskStatementOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CreateColumnStoreIndexStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(WindowFrameClause node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(WindowDelimiter node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(WithinGroupClause node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SelectiveXmlIndexPromotedPath node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(MergeActionClause node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(MergeAction node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(UpdateMergeAction node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DeleteMergeAction node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(InsertMergeAction node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CreateTypeTableStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AuditSpecificationStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AuditSpecificationPart node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AuditSpecificationDetail node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AuditActionSpecification node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DatabaseAuditAction node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AuditActionGroupReference node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CreateDatabaseAuditSpecificationStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterDatabaseAuditSpecificationStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropDatabaseAuditSpecificationStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CreateServerAuditSpecificationStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterServerAuditSpecificationStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropServerAuditSpecificationStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ServerAuditStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CreateServerAuditStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterServerAuditStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropServerAuditStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AuditTarget node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AuditOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(QueueDelayAuditOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AuditGuidAuditOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(OnFailureAuditOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(StateAuditOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AuditTargetOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(MaxSizeAuditTargetOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(MaxRolloverFilesAuditTargetOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(LiteralAuditTargetOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(OnOffAuditTargetOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DatabaseEncryptionKeyStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CreateDatabaseEncryptionKeyStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterDatabaseEncryptionKeyStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropDatabaseEncryptionKeyStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ResourcePoolStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ResourcePoolParameter node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ResourcePoolAffinitySpecification node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CreateResourcePoolStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterResourcePoolStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropResourcePoolStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(WorkloadGroupStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(WorkloadGroupResourceParameter node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(WorkloadGroupImportanceParameter node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(WorkloadGroupParameter node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CreateWorkloadGroupStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterWorkloadGroupStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropWorkloadGroupStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(BrokerPriorityStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(BrokerPriorityParameter node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CreateBrokerPriorityStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterBrokerPriorityStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropBrokerPriorityStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CreateFullTextStopListStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterFullTextStopListStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(FullTextStopListAction node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropFullTextStopListStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CreateCryptographicProviderStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterCryptographicProviderStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropCryptographicProviderStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(EventSessionObjectName node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(EventSessionStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropSearchPropertyListStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CreateLoginStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CreateLoginSource node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(PasswordCreateLoginSource node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(PrincipalOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(OnOffPrincipalOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(LiteralPrincipalOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(IdentifierPrincipalOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(WindowsCreateLoginSource node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CertificateCreateLoginSource node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AsymmetricKeyCreateLoginSource node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(PasswordAlterPrincipalOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterLoginStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterLoginOptionsStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterLoginEnableDisableStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterLoginAddDropCredentialStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(RevertStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropContractStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropEndpointStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropMessageTypeStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropQueueStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropRemoteServiceBindingStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropRouteStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropServiceStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SignatureStatementBase node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AddSignatureStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropSignatureStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropEventNotificationStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ExecuteAsStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(EndConversationStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(MoveConversationStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(GetConversationGroupStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ReceiveStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SendStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(WaitForSupportedStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterSchemaStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterAsymmetricKeyStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterServiceMasterKeyStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(BeginConversationTimerStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(BeginDialogStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DialogOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ScalarExpressionDialogOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(OnOffDialogOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(BackupCertificateStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(BackupRestoreMasterKeyStatementBase node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(BackupServiceMasterKeyStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(RestoreServiceMasterKeyStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(BackupMasterKeyStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(RestoreMasterKeyStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ScalarExpressionSnippet node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(BooleanExpressionSnippet node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(StatementListSnippet node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SelectStatementSnippet node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SchemaObjectNameSnippet node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(TSqlFragmentSnippet node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(TSqlStatementSnippet node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(IdentifierSnippet node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(TSqlScript node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(TSqlBatch node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(TSqlStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DataModificationStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DataModificationSpecification node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(MergeStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(MergeSpecification node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(GrandTotalGroupingSpecification node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(GroupingSetsGroupingSpecification node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(OutputClause node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(OutputIntoClause node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(HavingClause node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(IdentityFunctionCall node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(JoinParenthesisTableReference node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(OrderByClause node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(JoinTableReference node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(QualifiedJoin node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(OdbcQualifiedJoinTableReference node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(QueryExpression node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(QueryParenthesisExpression node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(QuerySpecification node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(FromClause node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SelectElement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SelectScalarExpression node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SelectStarExpression node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SelectSetVariable node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(TableReference node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(TableReferenceWithAlias node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(TableReferenceWithAliasAndColumns node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DataModificationTableReference node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ChangeTableChangesTableReference node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ChangeTableVersionTableReference node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(BooleanTernaryExpression node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(TopRowFilter node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(OffsetClause node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(UnaryExpression node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(BinaryQueryExpression node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(VariableTableReference node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(VariableMethodCallTableReference node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropPartitionFunctionStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropPartitionSchemeStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropSynonymStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropAggregateStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropAssemblyStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropApplicationRoleStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropFullTextCatalogStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropFullTextIndexStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropLoginStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropRoleStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropTypeStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropUserStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropMasterKeyStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropSymmetricKeyStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropAsymmetricKeyStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropCertificateStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropCredentialStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterPartitionFunctionStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterPartitionSchemeStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterFullTextIndexStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterFullTextIndexAction node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SimpleAlterFullTextIndexAction node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SetStopListAlterFullTextIndexAction node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SetSearchPropertyListAlterFullTextIndexAction node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropAlterFullTextIndexAction node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AddAlterFullTextIndexAction node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterColumnAlterFullTextIndexAction node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CreateSearchPropertyListStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterSearchPropertyListStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SearchPropertyListAction node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AddSearchPropertyListAction node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropSearchPropertyListAction node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CreateAggregateStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CreateEndpointStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterEndpointStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterCreateEndpointStatementBase node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(EndpointAffinity node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(EndpointProtocolOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(LiteralEndpointProtocolOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AuthenticationEndpointProtocolOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(PortsEndpointProtocolOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CompressionEndpointProtocolOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ListenerIPEndpointProtocolOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(IPv4 node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SoapMethod node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(PayloadOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(EnabledDisabledPayloadOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(WsdlPayloadOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(LoginTypePayloadOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(LiteralPayloadOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SessionTimeoutPayloadOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SchemaPayloadOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CharacterSetPayloadOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(RolePayloadOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AuthenticationPayloadOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(EncryptionPayloadOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SymmetricKeyStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CreateSymmetricKeyStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(KeyOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(KeySourceKeyOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlgorithmKeyOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(IdentityValueKeyOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ProviderKeyNameKeyOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CreationDispositionKeyOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterSymmetricKeyStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(FullTextCatalogStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(FullTextCatalogOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(OnOffFullTextCatalogOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CreateFullTextCatalogStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterFullTextCatalogStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterCreateServiceStatementBase node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CreateServiceStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterServiceStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ServiceContract node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(BinaryExpression node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(BuiltInFunctionTableReference node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ComputeClause node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ComputeFunction node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(PivotedTableReference node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(UnpivotedTableReference node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(UnqualifiedJoin node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(TableSampleClause node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ScalarExpression node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(BooleanExpression node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(BooleanNotExpression node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(BooleanParenthesisExpression node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(BooleanComparisonExpression node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(BooleanBinaryExpression node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(BooleanIsNullExpression node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ExpressionWithSortOrder node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(GroupByClause node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(GroupingSpecification node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ExpressionGroupingSpecification node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CompositeGroupingSpecification node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CubeGroupingSpecification node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(RollupGroupingSpecification node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(IdentityOptions node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ColumnStorageOptions node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ConstraintDefinition node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CreateTableStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(FederationScheme node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(TableDataCompressionOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DataCompressionOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CompressionPartitionRange node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CheckConstraintDefinition node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DefaultConstraintDefinition node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ForeignKeyConstraintDefinition node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(NullableConstraintDefinition node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(UniqueConstraintDefinition node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(BackupStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(BackupDatabaseStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(BackupTransactionLogStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(RestoreStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(RestoreOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ScalarExpressionRestoreOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(MoveRestoreOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(StopRestoreOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(FileStreamRestoreOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(BackupOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(BackupEncryptionOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DeviceInfo node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(MirrorToClause node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(BackupRestoreFileInfo node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(BulkInsertBase node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(BulkInsertStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(InsertBulkStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(BulkInsertOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(LiteralBulkInsertOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(OrderBulkInsertOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ColumnDefinitionBase node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(InsertBulkColumnDefinition node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DbccStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DbccOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DbccNamedLiteral node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CreateAsymmetricKeyStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CreatePartitionFunctionStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(PartitionParameterType node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CreatePartitionSchemeStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(RemoteServiceBindingStatementBase node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(RemoteServiceBindingOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(OnOffRemoteServiceBindingOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(UserRemoteServiceBindingOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CreateRemoteServiceBindingStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterRemoteServiceBindingStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(EncryptionSource node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AssemblyEncryptionSource node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(FileEncryptionSource node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ProviderEncryptionSource node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CertificateStatementBase node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterCertificateStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CreateCertificateStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CertificateOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CreateContractStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ContractMessage node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CredentialStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CreateCredentialStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterCredentialStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(MessageTypeStatementBase node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CreateMessageTypeStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterMessageTypeStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(KillStatsJobStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CheckpointStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ReconfigureStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ShutdownStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SetUserStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(TruncateTableStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SetOnOffStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(PredicateSetStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SetStatisticsStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SetRowCountStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SetOffsetsStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SetCommand node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(GeneralSetCommand node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SetFipsFlaggerCommand node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SetCommandStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SetTransactionIsolationLevelStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SetTextSizeStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SetIdentityInsertStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SetErrorLevelStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CreateDatabaseStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(FileDeclaration node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(FileDeclarationOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(NameFileDeclarationOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(FileNameFileDeclarationOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SizeFileDeclarationOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(MaxSizeFileDeclarationOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(FileGrowthFileDeclarationOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(FileGroupDefinition node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterDatabaseStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterDatabaseCollateStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterDatabaseRebuildLogStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterDatabaseAddFileStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterDatabaseAddFileGroupStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterDatabaseRemoveFileGroupStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterDatabaseRemoveFileStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterDatabaseModifyNameStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterDatabaseModifyFileStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterDatabaseModifyFileGroupStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterDatabaseTermination node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterDatabaseSetStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DatabaseOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(OnOffDatabaseOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AutoCreateStatisticsDatabaseOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ContainmentDatabaseOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(HadrDatabaseOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(HadrAvailabilityGroupDatabaseOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DelayedDurabilityDatabaseOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CursorDefaultDatabaseOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(RecoveryDatabaseOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(TargetRecoveryTimeDatabaseOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(PageVerifyDatabaseOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(PartnerDatabaseOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(WitnessDatabaseOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ParameterizationDatabaseOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(LiteralDatabaseOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(IdentifierDatabaseOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ChangeTrackingDatabaseOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ChangeTrackingOptionDetail node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AutoCleanupChangeTrackingOptionDetail node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ChangeRetentionChangeTrackingOptionDetail node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(FileStreamDatabaseOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(MaxSizeDatabaseOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterTableAlterColumnStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ColumnDefinition node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(RoleStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CreateRoleStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterRoleStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterRoleAction node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(RenameAlterRoleAction node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AddMemberAlterRoleAction node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropMemberAlterRoleAction node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CreateServerRoleStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterServerRoleStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropServerRoleStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(UserLoginOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(UserStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CreateUserStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterUserStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(StatisticsOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ResampleStatisticsOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(StatisticsPartitionRange node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(OnOffStatisticsOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(LiteralStatisticsOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CreateStatisticsStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(UpdateStatisticsStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ReturnStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DeclareCursorStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CursorDefinition node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CursorOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SetVariableStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CursorId node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CursorStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(OpenCursorStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CloseCursorStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CryptoMechanism node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(OpenSymmetricKeyStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CloseSymmetricKeyStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(OpenMasterKeyStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CloseMasterKeyStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DeallocateCursorStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(FetchType node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(FetchCursorStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(WhereClause node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropUnownedObjectStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropObjectsStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropDatabaseStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropChildObjectsStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropIndexStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropIndexClauseBase node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(BackwardsCompatibleDropIndexClause node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropIndexClause node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(MoveToDropIndexOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(FileStreamOnDropIndexOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropStatisticsStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropTableStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropProcedureStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropFunctionStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropViewStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropDefaultStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropRuleStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropTriggerStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropSchemaStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(RaiseErrorLegacyStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(RaiseErrorStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ThrowStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(UseStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(KillStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(KillQueryNotificationSubscriptionStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(TableSwitchOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(LowPriorityLockWaitTableSwitchOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropClusteredConstraintOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropClusteredConstraintStateOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropClusteredConstraintValueOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropClusteredConstraintMoveOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterTableDropTableElement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterTableDropTableElementStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterTableTriggerModificationStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(EnableDisableTriggerStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(TryCatchStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CreateTypeStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CreateTypeUdtStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CreateTypeUddtStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CreateSynonymStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ExecuteAsClause node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(QueueOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(QueueStateOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(QueueProcedureOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(QueueValueOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(QueueExecuteAsOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(RouteOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(RouteStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterRouteStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CreateRouteStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(QueueStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterQueueStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CreateQueueStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(IndexDefinition node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(IndexStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(IndexType node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(PartitionSpecifier node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterIndexStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CreateXmlIndexStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CreateSelectiveXmlIndexStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(FileGroupOrPartitionScheme node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CreateIndexStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(IndexOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(IndexStateOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(IndexExpressionOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(OnlineIndexOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(OnlineIndexLowPriorityLockWaitOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(LowPriorityLockWaitOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(LowPriorityLockWaitMaxDurationOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(LowPriorityLockWaitAbortAfterWaitOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(FullTextIndexColumn node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CreateFullTextIndexStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(FullTextIndexOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ChangeTrackingFullTextIndexOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(StopListFullTextIndexOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SearchPropertyListFullTextIndexOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(FullTextCatalogAndFileGroup node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(EventTypeGroupContainer node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(EventTypeContainer node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(EventGroupContainer node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CreateEventNotificationStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(EventNotificationObjectScope node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(MasterKeyStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CreateMasterKeyStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterMasterKeyStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ApplicationRoleOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ApplicationRoleStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CreateApplicationRoleStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterApplicationRoleStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ExecuteInsertSource node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(RowValue node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(PrintStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(UpdateCall node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(TSEqualCall node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(PrimaryExpression node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(Literal node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(IntegerLiteral node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(NumericLiteral node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(RealLiteral node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(MoneyLiteral node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(BinaryLiteral node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(StringLiteral node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(NullLiteral node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(IdentifierLiteral node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DefaultLiteral node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(MaxLiteral node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(OdbcLiteral node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(LiteralRange node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ValueExpression node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(VariableReference node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(OptionValue node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(OnOffOptionValue node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(LiteralOptionValue node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(GlobalVariableExpression node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(IdentifierOrValueExpression node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SchemaObjectNameOrValueExpression node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ParenthesisExpression node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ColumnReferenceExpression node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(NextValueForExpression node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SequenceStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SequenceOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DataTypeSequenceOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ScalarExpressionSequenceOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CreateSequenceStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterSequenceStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropSequenceStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AssemblyStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CreateAssemblyStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterAssemblyStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AssemblyOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(OnOffAssemblyOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(PermissionSetAssemblyOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AddFileSpec node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CreateXmlSchemaCollectionStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterXmlSchemaCollectionStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DropXmlSchemaCollectionStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AssemblyName node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterTableStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterTableRebuildStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterTableChangeTrackingModificationStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterTableFileTableNamespaceStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterTableSetStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(TableOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(LockEscalationTableOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(FileStreamOnTableOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(FileTableDirectoryTableOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(FileTableCollateFileNameTableOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(FileTableConstraintNameTableOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(MemoryOptimizedTableOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DurabilityTableOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterTableAddTableElementStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterTableConstraintModificationStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterTableSwitchStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AtomicBlockOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(LiteralAtomicBlockOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(IdentifierAtomicBlockOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(OnOffAtomicBlockOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(BeginTransactionStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(BreakStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ColumnWithSortOrder node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CommitTransactionStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(RollbackTransactionStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SaveTransactionStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ContinueStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CreateDefaultStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CreateFunctionStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CreateRuleStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DeclareVariableElement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DeclareVariableStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(GoToStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(IfStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(LabelStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(MultiPartIdentifier node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SchemaObjectName node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ChildObjectName node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ProcedureParameter node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(TransactionStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(WhileStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DeleteStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(UpdateDeleteSpecificationBase node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DeleteSpecification node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(InsertStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(InsertSpecification node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(UpdateStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(UpdateSpecification node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CreateSchemaStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(WaitForStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ReadTextStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(UpdateTextStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(WriteTextStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(TextModificationStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(LineNoStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SecurityStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(GrantStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DenyStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(RevokeStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterAuthorizationStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(Permission node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SecurityTargetObject node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SecurityTargetObjectName node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SecurityPrincipal node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SecurityStatementBody80 node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(GrantStatement80 node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DenyStatement80 node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(RevokeStatement80 node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SecurityElement80 node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CommandSecurityElement80 node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(PrivilegeSecurityElement80 node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(Privilege80 node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SecurityUserClause80 node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SqlCommandIdentifier node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SetClause node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AssignmentSetClause node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(FunctionCallSetClause node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(InsertSource node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ValuesInsertSource node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SelectInsertSource node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(LiteralTableHint node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(QueryDerivedTable node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(InlineDerivedTable node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SubqueryComparisonPredicate node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ExistsPredicate node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(LikePredicate node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(InPredicate node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(FullTextPredicate node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(UserDefinedTypePropertyAccess node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(StatementWithCtesAndXmlNamespaces node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SelectStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ForClause node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(BrowseForClause node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ReadOnlyForClause node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(XmlForClause node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(XmlForClauseOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(UpdateForClause node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(OptimizerHint node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(LiteralOptimizerHint node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(TableHintsOptimizerHint node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ForceSeekTableHint node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(OptimizeForOptimizerHint node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(VariableValuePair node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(WhenClause node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SimpleWhenClause node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SearchedWhenClause node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CaseExpression node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SimpleCaseExpression node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SearchedCaseExpression node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(NullIfExpression node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CoalesceExpression node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(IIfCall node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(FullTextTableReference node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SemanticTableReference node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(OpenXmlTableReference node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(OpenRowsetTableReference node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(InternalOpenRowset node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(BulkOpenRowset node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(OpenQueryTableReference node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AdHocTableReference node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SchemaDeclarationItem node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ConvertCall node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(TryConvertCall node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ParseCall node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(TryParseCall node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CastCall node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(TryCastCall node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(FunctionCall node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CallTarget node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ExpressionCallTarget node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(MultiPartIdentifierCallTarget node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(UserDefinedTypeCallTarget node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(LeftFunctionCall node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(RightFunctionCall node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(PartitionFunctionCall node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(OverClause node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ParameterlessCall node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ScalarSubquery node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(OdbcFunctionCall node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ExtractFromExpression node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(OdbcConvertSpecification node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterFunctionStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(BeginEndBlockStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(BeginEndAtomicBlockStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(StatementList node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ExecuteStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ExecuteOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ResultSetsExecuteOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ResultSetDefinition node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(InlineResultSetDefinition node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ResultColumnDefinition node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SchemaObjectResultSetDefinition node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ExecuteSpecification node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ExecuteContext node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ExecuteParameter node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ExecutableEntity node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ProcedureReferenceName node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ExecutableProcedureReference node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ExecutableStringList node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AdHocDataSource node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ViewOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterViewStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CreateViewStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ViewStatementBody node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(TriggerObject node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(TriggerOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ExecuteAsTriggerOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(TriggerAction node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterTriggerStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CreateTriggerStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(TriggerStatementBody node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(Identifier node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(AlterProcedureStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CreateProcedureStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ProcedureReference node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(MethodSpecifier node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ProcedureStatementBody node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ProcedureStatementBodyBase node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(FunctionStatementBody node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ProcedureOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ExecuteAsProcedureOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(FunctionOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ExecuteAsFunctionOption node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(XmlNamespaces node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(XmlNamespacesElement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(XmlNamespacesDefaultElement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(XmlNamespacesAliasElement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(CommonTableExpression node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(WithCtesAndXmlNamespaces node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(FunctionReturnType node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(TableValuedFunctionReturnType node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DataTypeReference node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ParameterizedDataTypeReference node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SqlDataTypeReference node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(UserDataTypeReference node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(XmlDataTypeReference node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(ScalarFunctionReturnType node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SelectFunctionReturnType node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(TableDefinition node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DeclareTableVariableBody node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(DeclareTableVariableStatement node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(NamedTableReference node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(SchemaObjectFunctionTableReference node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(TableHint node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }

            public override void ExplicitVisit(IndexTableHint node)
            {
                indent++;
                Console.WriteLine(new string(' ', indent * INDENT_SIZE) + node.GetType().Name);
                base.ExplicitVisit(node);
                indent--;
            }
        }
    }
}