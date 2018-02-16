using System;
using System.Collections.Generic;
using System.Linq;
using Cake.Core;
using Cake.Core.IO;

namespace Cake.Helm
{
    internal static class HelmResolver
    {
        public static FilePath GetHelmPath(IFileSystem fileSystem, ICakeEnvironment environment)
        {
            if (fileSystem == null)
            {
                throw new ArgumentNullException(nameof(fileSystem));
            }

            if (environment == null)
            {
                throw new ArgumentNullException(nameof(environment));
            }

            // Helm already searches the PATH for the executable tool names.
            // Check for other known locations.
            return !environment.Platform.IsUnix()
                ? CheckCommonWindowsPaths(fileSystem, environment)
                : null;
        }

        /// <summary>
        /// Check common helm client locations.
        /// </summary>
        /// <param name="fileSystem"></param>
        /// <param name="environment"></param>
        /// <returns></returns>
        private static FilePath CheckCommonWindowsPaths(IFileSystem fileSystem, ICakeEnvironment environment)
        {
            return GetDefaultWindowsPaths(fileSystem, environment)
                .Select(path => path.CombineWithFilePath("helm.exe"))
                .FirstOrDefault(dockerExecutable => fileSystem.GetFile(dockerExecutable).Exists);
        }

        /// <summary>
        /// Get default paths for common helm client installations.
        /// </summary>
        /// <param name="fileSystem"></param>
        /// <param name="environment"></param>
        /// <returns></returns>
        private static DirectoryPath[] GetDefaultWindowsPaths(IFileSystem fileSystem, ICakeEnvironment environment)
        {
            var paths = new List<DirectoryPath>();

            return paths.ToArray();
        }
    }
}
