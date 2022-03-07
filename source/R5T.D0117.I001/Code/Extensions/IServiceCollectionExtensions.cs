using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Lombardy;

using R5T.D0078;
using R5T.D0079;
using R5T.D0083;
using R5T.T0063;


namespace R5T.D0117.I001
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="CompilationUnitContextProvider"/> implementation of <see cref="ICompilationUnitContextProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddCompilationUnitContextProvider(this IServiceCollection services,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction,
            IServiceAction<IVisualStudioProjectFileOperator> visualStudioProjectFileOperatorAction,
            IServiceAction<IVisualStudioProjectFileReferencesProvider> visualStudioProjectFileReferencesProviderAction,
            IServiceAction<IVisualStudioSolutionFileOperator> visualStudioSolutionFileOperatorAction)
        {
            services
                .Run(stringlyTypedPathOperatorAction)
                .Run(visualStudioProjectFileOperatorAction)
                .Run(visualStudioProjectFileReferencesProviderAction)
                .Run(visualStudioSolutionFileOperatorAction)
                .AddSingleton<ICompilationUnitContextProvider, CompilationUnitContextProvider>();

            return services;
        }
    }
}
