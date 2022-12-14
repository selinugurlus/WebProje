using EntityLayer1.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer2.ValidationRules
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.user_name).NotEmpty().WithMessage("Adınızı giriniz.");
            RuleFor(x => x.user_surname).NotEmpty().WithMessage("Soyadınızı giriniz.");
            RuleFor(x => x.user_mail).NotEmpty().WithMessage("Mail adresinizi giriniz.");
            RuleFor(x => x.user_password).NotEmpty().WithMessage("Şifrenizi giriniz.");
        }
    }
}
