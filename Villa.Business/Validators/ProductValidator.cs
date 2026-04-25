using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Villa.Entity.Entities;

namespace Villa.Business.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Görsel URL'si gereklidir.");

            RuleFor(x => x.Title).NotEmpty().WithMessage("İlan başlığı zorunludur.")
                                 .MinimumLength(5).WithMessage("Başlık en az 5 karakter olmalıdır.");

            // View tarafında <option value=""> kullandığın için NotEmpty yeterlidir
            RuleFor(x => x.Category).NotEmpty().WithMessage("Lütfen bir kategori seçiniz.");

            RuleFor(x => x.Price).NotEmpty().WithMessage("Fiyat bilgisi girilmelidir.");

            RuleFor(x => x.Area).NotEmpty().WithMessage("Alan (m²) bilgisi boş geçilemez.");

            // EKSİK OLANLAR:
            RuleFor(x => x.BedroomCount).NotEmpty().WithMessage("Oda sayısı boş geçilemez.");

            RuleFor(x => x.BathroomCount).NotEmpty().WithMessage("Banyo sayısı boş geçilemez.");

            RuleFor(x => x.Floor).NotEmpty().WithMessage("Kat bilgisi boş geçilemez.");

            RuleFor(x => x.ParkingCount).NotEmpty().WithMessage("Park alanı sayısı boş geçilemez.");
        }
    }
}