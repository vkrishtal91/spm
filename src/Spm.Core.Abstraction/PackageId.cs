namespace Spm.Core.Abstraction;

/// <summary>
/// Represents identifier for package.
/// </summary>
/// <remarks>
///     The package can be identified by two parameters - name and version.
///     It means that pair name + version can be  used like business ID instead classic UUID or integer that is generating by database.
///     Using Business Domain Level ID instead DataAccess level ID is more flexible approach because allows you to use different databases and hide what exactly database used right now.
/// </remarks>
/// <param name="Name">The package name.</param>
/// <param name="Version">The project version.</param>
public sealed record PackageId(string Name, Version Version)
{
    /// <summary>Returns a string that represents the current object.</summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString() => $"{Name}-{Version}";
}
