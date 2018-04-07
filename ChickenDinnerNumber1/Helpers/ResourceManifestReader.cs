using System;
using System.Reflection;

namespace ChickenDinnerNumber1.Helpers
{
    public static class ResourceManifestReader
    {
        /// <summary>
        /// Helper method to read in the text of a resource manifest file included in the assembly.
        /// </summary>
        /// <param name="resourceFile">The resouce file (canse sensitive)</param>
        /// <returns>The text of the resource read.</returns>
        public static string ReadText(string resourceFile)
        {
            var assembly = typeof(ResourceManifestReader).GetTypeInfo().Assembly;
            var assemblyName = assembly.GetName().Name;
            var resources = assembly.GetManifestResourceNames();
            var stream = assembly.GetManifestResourceStream($"{assemblyName}.{resourceFile}");

            using (var reader = new System.IO.StreamReader(stream))
            {
                var text = reader.ReadToEnd();

                return text;
            }
        }
    }
}