using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail Adresi Boş Geçilemez");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Lütfen 50 Karakterden Fazla Değer Girişi Yapmayın");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfen 3 Karakterden Az Değer Girişi Yapmayın");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konuyu Boş Geçilemez");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adı Boş Geçilemez");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Lütfen 3 Karakterden Az Değer Girişi Yapmayın");
        }
    }
}
