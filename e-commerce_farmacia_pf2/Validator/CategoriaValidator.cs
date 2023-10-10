using e_commerce_farmacia_pf2.Model;
using FluentValidation;

namespace e_commerce_farmacia_pf2.Validator
{
    public class CategoriaValidator : AbstractValidator<Categoria>
    {
        public CategoriaValidator()
        {
            RuleFor(c => c.Tipo)
                    .NotEmpty()
                    .MinimumLength(2)
                    .MaximumLength(100);


        }

    }
}
