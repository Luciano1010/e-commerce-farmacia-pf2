using e_commerce_farmacia_pf2.Model;

namespace e_commerce_farmacia_pf2.Service
{
    public interface ICategoriaService
    {
        Task<IEnumerable<Categoria>> GetAll();

        Task<Categoria?> GetById(long id);

        Task<IEnumerable<Categoria>> GetByTipo(string Tipo);

        Task<Categoria?> Create(Categoria Categorias);
        Task<Categoria?> Update(Categoria Categorias);

        Task Delete(Categoria Categorias);

    }
}
