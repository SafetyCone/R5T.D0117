using System;
using System.Threading.Tasks;

using R5T.D0117;
using R5T.T0127;

using Instances = R5T.D0117.X001.Instances;


namespace System
{
    public static class IProjectFileContextProviderExtensions
    {
        public static async Task<IProjectFileContext> GetProjectFileContext(this IProjectFileContextProvider projectFileContextProvider,
            string projectFilePath,
            bool verifyProjectFileExists = false)
        {
            if (verifyProjectFileExists)
            {
                Instances.FileSystemOperator.VerifyFileExists(projectFilePath);
            }

            var solutionFilePaths = await Instances.SolutionOperator.GetSolutionFilePathsContainingProject(
               projectFilePath,
               projectFileContextProvider.StringlyTypedPathOperator,
               projectFileContextProvider.VisualStudioSolutionFileOperator);

            var output = new ProjectFileContext
            {
                ProjectFilePath = projectFilePath,
                SolutionFilePaths = solutionFilePaths,
                VisualStudioProjectFileOperator = projectFileContextProvider.VisualStudioProjectFileOperator,
                VisualStudioProjectFileReferencesProvider = projectFileContextProvider.VisualStudioProjectFileReferencesProvider,
                VisualStudioSolutionFileOperator = projectFileContextProvider.VisualStudioSolutionFileOperator
            };

            return output;
        }
    }
}
