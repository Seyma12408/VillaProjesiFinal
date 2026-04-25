using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Villa.Entity.Entities;

namespace Villa.Business.Validators
{
    public class SubHeaderValidator : AbstractValidator<SubHeader>
    {
        public SubHeaderValidator()
        {
            // Adres Kontrolü
            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Adres alanı boş bırakılamaz.")
                .MaximumLength(200).WithMessage("Adres alanı en fazla 200 karakter olabilir.");

            // Email Kontrolü
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-posta alanı boş bırakılamaz.")
                .EmailAddress().WithMessage("Lütfen geçerli bir e-posta adresi giriniz.");

            // Sosyal Medya Linkleri (Opsiyonel ama girilirse URL formatı kontrolü)
            // Eğer sosyal medya linklerinin zorunlu olmasını istemiyorsan sadece format kontrolü yeterlidir.

            RuleFor(x => x.Facebook)
                .Must(LinkKontrol).WithMessage("Lütfen geçerli bir Facebook linki giriniz.")
                .When(x => !string.IsNullOrEmpty(x.Facebook));

            RuleFor(x => x.Twitter)
                .Must(LinkKontrol).WithMessage("Lütfen geçerli bir Twitter linki giriniz.")
                .When(x => !string.IsNullOrEmpty(x.Twitter));

            RuleFor(x => x.Linkedin)
                .Must(LinkKontrol).WithMessage("Lütfen geçerli bir Linkedin linki giriniz.")
                .When(x => !string.IsNullOrEmpty(x.Linkedin));

            RuleFor(x => x.Instagram)
                .Must(LinkKontrol).WithMessage("Lütfen geçerli bir Instagram linki giriniz.")
                .When(x => !string.IsNullOrEmpty(x.Instagram));
        }

        // URL formatını doğrulamak için yardımcı metot
        private bool LinkKontrol(string link)
        {
            if (string.IsNullOrEmpty(link)) return true;
            return Uri.TryCreate(link, UriKind.Absolute, out _);
        }
    }
}