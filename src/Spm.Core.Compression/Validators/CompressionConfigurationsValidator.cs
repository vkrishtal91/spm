using FluentValidation;
using Spm.Core.Compression.Configurations;

namespace Spm.Core.Compression.Validators;

internal sealed class CompressionConfigurationsValidator : AbstractValidator<CompressionConfigurations>
{
    public CompressionConfigurationsValidator()
    {
        RuleFor(_ => _.CompressionAlgorithm)
            .IsInEnum().WithMessage("Unknown compression algorithm");

        RuleFor(_ => _.CompressionLevel)
            .IsInEnum().WithMessage("Unknown compression level");

        RuleFor(_ => _.HashAlgorithm)
            .IsInEnum().WithMessage("Unknown hash algorithm");
    }
}