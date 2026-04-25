using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Villa.Entity.Entities;

namespace Villa.Business.Validators
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad-Soyad alanı zorunludur.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu alanı boş bırakılamaz.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("E-posta adresi gereklidir.")
                                 .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesaj içeriği boş olamaz.")
                                          .MinimumLength(20).WithMessage("Mesaj en az 20 karakter olmalıdır.");
        }
    }
}
