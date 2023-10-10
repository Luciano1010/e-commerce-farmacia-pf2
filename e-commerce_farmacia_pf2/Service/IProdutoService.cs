using e_commerce_farmacia_pf2.Model;

namespace e_commerce_farmacia_pf2.Service
{
    public interface IProdutoService
    {
        Task<IEnumerable<Produto>> GetAll();

        Task<Produto?> GetById(long id);

        Task<IEnumerable<Produto>> GetByNomeMedicamento(string nome);

        Task<Produto?> Create(Produto produto);

        Task<Produto?> Update(Produto produtos);

        Task Delete(Produto produtos);

    }

}
