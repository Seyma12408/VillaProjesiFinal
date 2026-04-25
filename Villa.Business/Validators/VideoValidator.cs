using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Villa.Entity.Entities;

namespace Villa.Business.Validators
{
    public class VideoValidator : AbstractValidator<Video>
    {
        public VideoValidator()
        {
            RuleFor(x => x.VideoUrl).NotEmpty().WithMessage("Video URL'si boş geçilemez.")
                                    .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _))
                                    .WithMessage("Lütfen geçerli bir URL formatı giriniz.");
        }
    }
}
