using System.Reflection;
using System.Runtime.Loader;

namespace ContextCompiler.Modules.Loader;

public sealed class ModuleLoadContext(string moduleMainAssemblyPath, string? installRoot = null) : AssemblyLoadContext(isCollectible: false)
{
    private readonly AssemblyDependencyResolver _resolver = new(moduleMainAssemblyPath);
    private readonly string _moduleDirectory = Path.GetDirectoryName(moduleMainAssemblyPath) ?? throw new ArgumentException("Invalid assembly path", nameof(moduleMainAssemblyPath));

    protected override Assembly? Load(AssemblyName assemblyName)
    {
        Assembly? alreadyLoaded = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(x => x.FullName == assemblyName.FullName);
        if (alreadyLoaded != null)
        {
            return alreadyLoaded;
        }


        // First, try the standard resolver (uses .deps.json)
        string? path = _resolver.ResolveAssemblyToPath(assemblyName);
        if (path != null)
        {
            return LoadFromAssemblyPath(path);
        }

        // If not found, try to find it in the module directory
        path = TryFindInModuleDirectory(assemblyName);
        if (path != null)
        {
            return LoadFromAssemblyPath(path);
        }

        // If still not found and we have an install root, search in the dependencies structure
        if (installRoot != null)
        {
            path = TryFindInInstallRoot(assemblyName);
            if (path != null)
            {
                return LoadFromAssemblyPath(path);
            }
        }

        // Let the default context handle it
        return null;
    }

    private string? TryFindInModuleDirectory(AssemblyName assemblyName)
    {
        // Try lib/net* folders
        string libPath = Path.Combine(_moduleDirectory, "lib");
        if (Directory.Exists(libPath))
        {
            string[] frameworkDirs = Directory.GetDirectories(libPath, "net*", SearchOption.TopDirectoryOnly);
            foreach (string frameworkDir in frameworkDirs.OrderByDescending(d => Path.GetFileName(d)))
            {
                string candidate = Path.Combine(frameworkDir, $"{assemblyName.Name}.dll");
                if (File.Exists(candidate))
                {
                    return candidate;
                }
            }
        }

        // Try root directory
        string rootCandidate = Path.Combine(_moduleDirectory, $"{assemblyName.Name}.dll");
        return File.Exists(rootCandidate) ? rootCandidate : null;
    }

    private string? TryFindInInstallRoot(AssemblyName assemblyName)
    {
        if (string.IsNullOrEmpty(assemblyName.Name))
        {
            return null;
        }

        if (string.IsNullOrEmpty(installRoot))
        {
            return null;
        }

        string packageDir = Path.Combine(installRoot, assemblyName.Name);
        bool isFound = false;

        //Certain package comme Microsoft.ML.OnnxRuntime non pas de dll mais on un "redirection" vers Microsoft.ML.OnnxRuntime.Managed via une dépendence dans le .deps.json.
        //On vérifie donc la présence de la dll dans le dossier du package avant de se lancer dans une recherche plus large.

        if (Directory.Exists(packageDir))
        {
            isFound = Directory.GetFiles(packageDir, $"{assemblyName.Name}.dll", SearchOption.AllDirectories).FirstOrDefault() != null;
        }

        if (!isFound)
        {
            string? found = Directory.GetFiles(installRoot, $"{assemblyName.Name}.dll", SearchOption.AllDirectories).FirstOrDefault();
            if (string.IsNullOrEmpty(found))
            {
                return null;
            }
            packageDir = GetModuleRoot(installRoot, found);
        }

        // Navigate through version/checksum/lib/net* structure
        foreach (string versionDir in Directory.GetDirectories(packageDir))
        {
            foreach (string checksumDir in Directory.GetDirectories(versionDir))
            {
                string libPath = Path.Combine(checksumDir, "lib");
                if (Directory.Exists(libPath))
                {
                    string[] frameworkDirs = Directory.GetDirectories(libPath, "net*", SearchOption.TopDirectoryOnly);
                    foreach (string frameworkDir in frameworkDirs.OrderByDescending(d => Path.GetFileName(d)))
                    {
                        string candidate = Path.Combine(frameworkDir, $"{assemblyName.Name}.dll");
                        if (File.Exists(candidate))
                        {
                            // Optionally verify version matches
                            return candidate;
                        }
                    }
                }
            }
        }

        return null;
    }

    protected override IntPtr LoadUnmanagedDll(string unmanagedDllName)
    {
        string? path = _resolver.ResolveUnmanagedDllToPath(unmanagedDllName);
        return path != null ? LoadUnmanagedDllFromPath(path) : IntPtr.Zero;
    }

    private static string GetModuleRoot(string installRoot, string foundPath)
    {
        string relative = Path.GetRelativePath(installRoot, foundPath);

        ReadOnlySpan<char> span = relative.AsSpan();
        int sep = span.IndexOfAny(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);

        string moduleName = sep >= 0
            ? span[..sep].ToString()
            : relative;

        return Path.Combine(installRoot, moduleName);
    }
}
