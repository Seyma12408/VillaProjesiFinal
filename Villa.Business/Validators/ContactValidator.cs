using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Villa.Entity.Entities;

namespace Villa.Business.Validators
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.MapUrl).NotEmpty().WithMessage("Harita URL'si zorunludur.");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon numarası zorunludur.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email alanı boş geçilemez.")
                                 .EmailAddress().WithMessage("Geçerli bir email adresi giriniz.");
        }
    }
}
