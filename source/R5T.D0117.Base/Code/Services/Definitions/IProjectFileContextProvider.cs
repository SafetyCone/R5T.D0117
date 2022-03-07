using System;

using R5T.Lombardy;

using R5T.D0078;
using R5T.D0079;
using R5T.D0083;
using R5T.T0064;


namespace R5T.D0117
{
    [ServiceDefinitionMarker]
    public interface IProjectFileContextProvider : IServiceDefinition
    {
        IStringlyTypedPathOperator StringlyTypedPathOperator { get; }
        IVisualStudioProjectFileOperator VisualStudioProjectFileOperator { get; }
        IVisualStudioProjectFileReferencesProvider VisualStudioProjectFileReferencesProvider { get; }
        IVisualStudioSolutionFileOperator VisualStudioSolutionFileOperator { get; }
    }
}
