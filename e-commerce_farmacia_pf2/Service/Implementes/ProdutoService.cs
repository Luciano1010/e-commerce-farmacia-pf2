using e_commerce_farmacia_pf2.Data;
using e_commerce_farmacia_pf2.Model;
using Microsoft.EntityFrameworkCore;

namespace e_commerce_farmacia_pf2.Service.Implementes
{
    public class ProdutoService : IProdutoService
    {
        private readonly AppDbContext _context;
        public ProdutoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Produto>> GetAll()
        {
            return await _context.Produtos
                 .Include(p => p.Categoria)
                 .ToListAsync();

        }

        public async Task<Produto?> GetById(long id)
        {
            try
            {
                var Produto = await _context.Produtos
                    .Include(p => p.Categoria)
                    .FirstAsync(p => p.Id == id);
                return Produto;

            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<Produto>> GetByNomeMedicamento(string nome)
        {
            var Produtos = await _context.Produtos
                            .Include(p => p.Categoria)
                            .Where(p => p.Nome.Contains(nome))
                            .ToListAsync();

            return Produtos;
        }

        public async Task<Produto?> Create(Produto produto)
        {

            if (produto.Categoria is not null)
            {
                var BuscaCategoria = await _context.Categorias.FindAsync(produto.Categoria.Id);

                if (BuscaCategoria is null)
                    return null;
            }

            produto.Categoria = produto.Categoria is not null ? _context.Categorias.FirstOrDefault(p => p.Id == produto.Categoria.Id) : null;
            await _context.AddAsync(produto);
            await _context.SaveChangesAsync();

            return produto;


            
        }
        public async Task<Produto?> Update(Produto Produtos)
        {
            var ProdutoUpdate = await _context.Produtos.FindAsync(Produtos.Id);

            if (ProdutoUpdate is null)
                return null;

            if (Produtos.Categoria is not null)
            {
                var Buscaproduto = await _context.Produtos.FindAsync(Produtos.Categoria.Id);
                if (Buscaproduto is null)
                    return null;

            }

            Produtos.Categoria = Produtos.Categoria is not null ? _context.Categorias.FirstOrDefault(t => t.Id == Produtos.Categoria.Id) : null;

            _context.Entry(ProdutoUpdate).State = EntityState.Detached;
            _context.Entry(Produtos).State = EntityState.Modified;
           
            
            await _context.SaveChangesAsync();

            return Produtos;
        }
        public async Task Delete(Produto Produtos)
        {
            _context.Remove(Produtos);
            await _context.SaveChangesAsync();
        }
       
    }
}
