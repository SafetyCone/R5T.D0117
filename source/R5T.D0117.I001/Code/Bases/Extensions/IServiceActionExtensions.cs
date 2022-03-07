using System;

using R5T.Lombardy;

using R5T.D0078;
using R5T.D0079;
using R5T.D0083;
using R5T.T0062;
using R5T.T0063;


namespace R5T.D0117.I001
{
    public static class IServiceActionExtensions
    {
        /// <summary>
        /// Adds the <see cref="CompilationUnitContextProvider"/> implementation of <see cref="ICompilationUnitContextProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<ICompilationUnitContextProvider> AddCompilationUnitContextProviderAction(this IServiceAction _,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction,
            IServiceAction<IVisualStudioProjectFileOperator> visualStudioProjectFileOperatorAction,
            IServiceAction<IVisualStudioProjectFileReferencesProvider> visualStudioProjectFileReferencesProviderAction,
            IServiceAction<IVisualStudioSolutionFileOperator> visualStudioSolutionFileOperatorAction)
        {
            var serviceAction = _.New<ICompilationUnitContextProvider>(services => services.AddCompilationUnitContextProvider(
                stringlyTypedPathOperatorAction,
                visualStudioProjectFileOperatorAction,
                visualStudioProjectFileReferencesProviderAction,
                visualStudioSolutionFileOperatorAction));

            return serviceAction;
        }
    }
}
