using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Villa.Entity.Entities;


namespace Villa.Business.Validators
{
    public class FeatureValidator : AbstractValidator<Feature>
    {
        public FeatureValidator()
        {
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Resim URL'si boş geçilemez.");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık alanı zorunludur.");
            RuleFor(x => x.SubTitle).NotEmpty().WithMessage("Alt başlık alanı zorunludur.");
            RuleFor(x => x.Square).NotEmpty().WithMessage("Metrekare bilgisi girilmelidir.");
            RuleFor(x => x.Contract).NotEmpty().WithMessage("Kontrat türü belirtilmelidir.");
            RuleFor(x => x.Safety).NotEmpty().WithMessage("Güvenlik türü belirtilmelidir.");

        }
    }
}
