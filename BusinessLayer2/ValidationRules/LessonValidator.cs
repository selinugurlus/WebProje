using EntityLayer1.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer2.ValidationRules
{
    public class LessonValidator:AbstractValidator<Lesson>
    {
        public LessonValidator()
        {
            RuleFor(x => x.lesson_name).NotEmpty().WithMessage("Ders adı giriniz.");
            RuleFor(x => x.lesson_status).NotEmpty().WithMessage("Şifrenizi giriniz.");
        }
    }
}
