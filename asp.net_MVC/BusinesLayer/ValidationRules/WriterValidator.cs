using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLayer.ValidationRules
{
    public class WriterValidator: AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Ismi Boş Geçilemez");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Yazar Başlığı Boş Geçilemez");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar Soyadı Boş Geçilemez");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkımda Kısmı Boş Geçilemez");
            RuleFor(x => x.WriterName).MaximumLength(30).WithMessage("Lütfen 30 Karakterden Fazla Değer Girişi Yapmayın");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lütfen 2 Karakterden Az Değer Girişi Yapmayın");
            RuleFor(x => x.WriterSurname).MaximumLength(20).WithMessage("Lütfen 20 Karakterden Fazla Değer Girişi Yapmayın");
            RuleFor(x => x.WriterTitle).MaximumLength(20).WithMessage("Lütfen 30 Karakterden Fazla Değer Girişi Yapmayın");
            RuleFor(x => x.WriterSurname).MinimumLength(2).WithMessage("Lütfen 2 Karakterden Az Değer Girişi Yapmayın");
            RuleFor(x => x.WriterTitle).MinimumLength(5).WithMessage("Lütfen 5 Karakterden Az Değer Girişi Yapmayın");
        }
    }
}
