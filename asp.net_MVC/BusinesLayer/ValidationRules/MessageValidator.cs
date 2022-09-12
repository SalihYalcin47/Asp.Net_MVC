using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {

        public MessageValidator() 
        {
        RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı Adresi Boş Geçilemez");
        RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesajı Boş Geçilemez");
        RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Lütfen 50 Karakterden Fazla Değer Girişi Yapmayın");
        RuleFor(x => x.Subject).MinimumLength(10).WithMessage("Lütfen 20 Karakterden Az Değer Girişi Yapmayın");
        RuleFor(x => x.Subject).NotEmpty().WithMessage("Konuyu Boş Geçilemez");
        }
    }
}
