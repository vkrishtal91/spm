namespace Spm.Core.Abstraction;

public interface IPackageInfoValidator
{
    Task Validate(PackageInfo package, CancellationToken cancellationToken = default);
}