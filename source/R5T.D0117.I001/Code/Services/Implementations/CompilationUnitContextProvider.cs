using System;

using R5T.Lombardy;

using R5T.D0078;
using R5T.D0079;
using R5T.D0083;
using R5T.T0064;


namespace R5T.D0117.I001
{
    [ServiceImplementationMarker]
    public class CompilationUnitContextProvider : ICompilationUnitContextProvider, IServiceImplementation
    {
        public IStringlyTypedPathOperator StringlyTypedPathOperator { get; set; }
        public IVisualStudioProjectFileOperator VisualStudioProjectFileOperator { get; set; }
        public IVisualStudioProjectFileReferencesProvider VisualStudioProjectFileReferencesProvider { get; set; }
        public IVisualStudioSolutionFileOperator VisualStudioSolutionFileOperator { get; set; }


        public CompilationUnitContextProvider(
            IStringlyTypedPathOperator stringlyTypedPathOperator,
            IVisualStudioProjectFileOperator visualStudioProjectFileOperator,
            IVisualStudioProjectFileReferencesProvider visualStudioProjectFileReferencesProvider,
            IVisualStudioSolutionFileOperator visualStudioSolutionFileOperator)
        {
            this.StringlyTypedPathOperator = stringlyTypedPathOperator;
            this.VisualStudioProjectFileOperator = visualStudioProjectFileOperator;
            this.VisualStudioProjectFileReferencesProvider = visualStudioProjectFileReferencesProvider;
            this.VisualStudioSolutionFileOperator = visualStudioSolutionFileOperator;
        }
    }
}
