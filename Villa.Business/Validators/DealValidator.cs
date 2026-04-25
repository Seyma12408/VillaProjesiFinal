using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Villa.Entity.Entities;

namespace Villa.Business.Validators
{
    
        public class DealValidator : AbstractValidator<Deal>
        {
            public DealValidator()
            {
                RuleFor(x => x.Type).NotEmpty().WithMessage("İlan türü alanı boş geçilemez.");

                RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Resim URL alanı boş geçilemez."); 

                RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık alanı boş geçilemez.");

                RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama alanı boş geçilemez.");

                RuleFor(x => x.Square).NotEmpty().WithMessage("Metrekare alanı boş geçilemez.");

                RuleFor(x => x.Floor).NotEmpty().WithMessage("Kaçıncı kat alanı boş geçilemez."); 

                RuleFor(x => x.RoomCount).NotEmpty().WithMessage("Oda sayısı alanı boş geçilemez."); 

                RuleFor(x => x.PaymentType).NotEmpty().WithMessage("Ödeme türü alanı boş geçilemez.");

                RuleFor(x => x.HasParkingArea).NotNull().WithMessage("Otopark durumu seçilmelidir.");
            }
        }
    }

