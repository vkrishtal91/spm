using FluentValidation;
using Spm.Core.Abstraction;

namespace Spm.Core.Validators;

internal class PackageIdValidator : AbstractValidator<PackageId>
{
    public PackageIdValidator()
    {
        RuleFor(id => id.Name)
            .NotEmpty().WithMessage("The package name is missed");

        RuleFor(id => id.Name.Length)
            .GreaterThan(3).WithMessage("Too short package name")
            .LessThan(256).WithMessage("Too long package name");

        RuleFor(id => id.Version)
            .NotNull().WithMessage("The package semantic version is missed");
    }
}