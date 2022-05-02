using FluentValidation;
using Spm.Core.Abstraction;

namespace Spm.Core.Validators;

internal class PackageInfoValidator : AbstractValidator<PackageInfo>, IPackageInfoValidator
{
    /// <summary>
    /// Creates a new instance of <see cref="PackageInfoValidator"/> class.
    /// </summary>
    public PackageInfoValidator(IValidator<PackageId> idValidator)
    {
        // Mandatory fields

        RuleFor(info => info.Id)
            .NotNull().WithMessage("Package ID is missed")
            .SetValidator(idValidator);

        RuleFor(info => info.Description)
            .MaximumLength(512)
            .WithMessage("Too long package description");

        RuleFor(info => info.Hash)
            .NotEmpty().WithMessage("The package hash is missed")
            .MaximumLength(128).WithMessage("Too long package hash");

        // Optional fields

        When(info => info.Labels != null && info.Labels.Any(), () =>
        {
            RuleForEach(info => info.Labels)
                .NotEmpty().WithMessage("Empty label")
                .MaximumLength(32).WithMessage("Too long label");
        });

        When(info => info.Tags != null && info.Tags.Any(), () =>
        {
            TransformForEach(info => info.Tags, property => property.Key)
                .NotEmpty().WithMessage("The tag key is missed")
                .MaximumLength(64).WithMessage("Too long tag key");

            TransformForEach(info => info.Tags, property => property.Value)
                .MaximumLength(256).WithMessage("Too long tag value");
        });
    }

    public async Task Validate(PackageInfo package, CancellationToken cancellationToken = default)
    {
        EnsureInstanceNotNull(package);
        await this.ValidateAndThrowAsync(package, cancellationToken);
    }
}