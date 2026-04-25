using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Villa.Entity.Entities;


namespace Villa.Business.Validators
{
    public class CounterValidator : AbstractValidator<Counter>
    {
        public CounterValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş geçilemez.");
            RuleFor(x => x.Count).NotEmpty().WithMessage("Sayaç değeri boş geçilemez.");
        }
    }
}
