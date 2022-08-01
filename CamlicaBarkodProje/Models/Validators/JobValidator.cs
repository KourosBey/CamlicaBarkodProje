using EntityLayer.Concrete;
using FluentValidation;

namespace CamlicaBarkodProje.Models.Validators
{
    public class WorkerValidator : AbstractValidator<Worker>
    {
        public WorkerValidator()
        {
            RuleFor(x => x.Email).NotNull().WithMessage("Email Boş gönderilemez");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Uygun bir email giriniz.");
            
        }
    }
}
