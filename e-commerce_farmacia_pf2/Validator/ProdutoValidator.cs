using e_commerce_farmacia_pf2.Model;
using FluentValidation;

namespace e_commerce_farmacia_pf2.Validator
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {
        public ProdutoValidator()
        {
            RuleFor(p => p.Nome)
                    .NotEmpty()
                    .MinimumLength(2)
                    .MaximumLength(255);


            RuleFor(p => p.Descricao)
                    .NotEmpty()
                    .MinimumLength(5)
                    .MaximumLength(500);

            RuleFor(p => p.Preco)
                .NotNull()
                .GreaterThan(0)
                .PrecisionScale(20, 2, false);

            RuleFor(p => p.Foto)
                    .NotEmpty()
                    .MinimumLength(2)
                    .MaximumLength(5000);

            RuleFor(p => p.Quantidade)
                    .MinimumLength(2)
                    .MaximumLength(5000);

            RuleFor(p => p.Data)
                    .NotEmpty();

        }
    }

}
