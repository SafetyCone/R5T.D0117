using System;

using R5T.T0034;
using R5T.T0036;
using R5T.T0040;
using R5T.T0044;
using R5T.T0045;
using R5T.T0098;
using R5T.T0113;


namespace R5T.D0117.X001
{
    public static class Instances
    {
        public static IClassGenerator ClassGenerator { get; } = T0045.ClassGenerator.Instance;
        public static IClassName ClassName { get; } = T0036.ClassName.Instance;
        public static ICompilationUnitOperator CompilationUnitOperator { get; } = T0045.CompilationUnitOperator.Instance;
        public static IFileSystemOperator FileSystemOperator { get; } = T0044.FileSystemOperator.Instance;
        public static IIndentation Indentation { get; } = T0036.Indentation.Instance;
        public static INamespacedTypeName NamespacedTypeName { get; } = T0034.NamespacedTypeName.Instance;
        public static IOperation Operation { get; } = T0098.Operation.Instance;
        public static IProjectPathsOperator ProjectPathsOperator { get; } = T0040.ProjectPathsOperator.Instance;
        public static IPropertyGenerator PropertyGenerator { get; } = T0045.PropertyGenerator.Instance;
        public static ISolutionOperator SolutionOperator { get; } = T0113.SolutionOperator.Instance;
    }
}
