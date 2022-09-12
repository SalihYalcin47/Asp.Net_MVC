using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLayer.ValidationRules
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CatagoryName).NotEmpty().WithMessage("Kataegori Ismi Boş Geçilemez");
            RuleFor(x => x.CatagoryName).MaximumLength(20).WithMessage("Lütfen 20 Karakterden Fazla Değer Girişi Yapmayın");
            RuleFor(x => x.CatagoryName).MinimumLength(5).WithMessage("Lütfen 5 Karakterden Az Değer Girişi Yapmayın");
            RuleFor(x => x.CatagoryDescription).MinimumLength(30).WithMessage("lütfen 30 karakterden az değer girişi yapmayın");
            RuleFor(x => x.CatagoryDescription).NotEmpty().WithMessage("Açıklama Kısmı Boş Geçilemez");
        }
    }
}
