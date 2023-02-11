using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.D0116;
using R5T.D0117;
using R5T.X0003;

using Instances = R5T.D0117.X001.Instances;


namespace System
{
    public static partial class ICompilationUnitContextProviderExtensions
    {
        public static async Task AddExtensionMethodBasesToProjectInstances(this ICompilationUnitContextProvider compilationUnitContextProvider,
            string projectFilePath,
            string namespaceName,
            IEnumerable<string> extensionMethodBaseInterfaceNamespacedTypeNames,
            IUsingDirectivesFormatter usingDirectivesFormatter)
        {
            var instancesProjectDirectoryRelativeCodeFilePath = Instances.ProjectPathsOperator.GetInstancesCodeFileRelativePath();

            await compilationUnitContextProvider.InAcquiredCompilationUnitContext(
                projectFilePath,
                instancesProjectDirectoryRelativeCodeFilePath,
                async (compilationUnitContext, compilationUnit) =>
                {
                    var outputCompilationUnit = await compilationUnitContext.InAcquiredNamespaceContext(
                        compilationUnit,
                        namespaceName,
                        async (namespaceCompilationUnit, namespaceContext) =>
                        {
                            //var outputNamespaceCompilationUnit = namespaceCompilationUnit;

                            var outputNamespaceCompilationUnit = await namespaceContext.InAcquiredClassContext(
                                namespaceCompilationUnit,
                                Instances.ClassName.Instances(),
                                async (classCompilationUnit, classContext) =>
                                {
                                    var outputClassCompilationUnit = classCompilationUnit;

                                    // Add usings.
                                    var requiredNamespaces = extensionMethodBaseInterfaceNamespacedTypeNames
                                        .Select(x => Instances.NamespacedTypeName.GetNamespaceName(x))
                                        ;

                                    // Add and format all usings.
                                    outputClassCompilationUnit = await usingDirectivesFormatter.AddAndFormatNamespaceNames(
                                        outputClassCompilationUnit,
                                        requiredNamespaces,
                                        namespaceName);

                                    // Now add instances.
                                    var instanceTuples = Instances.Operation.GetInstanceTuples(
                                        extensionMethodBaseInterfaceNamespacedTypeNames,
                                        namespaceName);

                                    var instanceProperties = Instances.PropertyGenerator.GetInstancesInstanceProperties(
                                        instanceTuples)
                                        // Indent.
                                        .Select(xProperty => xProperty.IndentBlock_Old(
                                            Instances.Indentation.Property()))
                                        .Now();

                                    outputClassCompilationUnit = classContext.ClassAnnotation.ModifySynchronous(outputClassCompilationUnit,
                                        @class =>
                                        {
                                            // Determine new properties.
                                            var existingProperties = @class.GetProperties();

                                            var newProperties = instanceProperties.Except(existingProperties, InstancePropertyEqualityComparer.Instance);

                                            // Add new properties.
                                            var outputClass = @class.AddProperties(newProperties);

                                            // Ensure all properties have the desired indentation.
                                            outputClass = outputClass.WithProperties(outputClass.GetProperties()
                                                .Select(xProperty => xProperty.SetIndentation_Best(
                                                    Instances.Indentation.Property())));

                                            // Order properties by type name.
                                            outputClass = outputClass.OrderPropertiesBy(xProperty =>
                                            {
                                                var typeName = xProperty.GetTypeExpressionText();
                                                return typeName;
                                            });

                                            // Set the open and close brace trivia. This must be done after ordering since trivia is always leading trivia, so the first property needs to have been already decided.
                                            outputClass = outputClass.EnsureBraceSpacing();

                                            return outputClass;
                                        });

                                    return outputClassCompilationUnit;
                                },
                                () =>
                                {
                                    // Create an empty instances class.
                                    var outputInstancesClass = Instances.ClassGenerator.GetPublicStaticClass2(Instances.ClassName.Instances())
                                        .IndentBlock(Instances.Indentation.Class())
                                        ;

                                    return outputInstancesClass;
                                });

                            return outputNamespaceCompilationUnit;
                        });

                    return outputCompilationUnit;
                },
                (compilationUnitContext, compilationUnit) =>
                {
                    var outputCompilationUnit = compilationUnit;

                    // Do nothing with the compilation unit.

                    return Task.FromResult(outputCompilationUnit);
                });
        }
    }
}
