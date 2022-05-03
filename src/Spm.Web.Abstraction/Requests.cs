using Spm.Core.Abstraction;

namespace Spm.Web.Abstraction;

public sealed record PullPackageRequest(PackageId Id, string SaveTo);

public sealed record PushPackageRequest(string package);
