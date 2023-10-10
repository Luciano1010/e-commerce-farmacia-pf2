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
                           .ToListAsync();

        }

        public async Task<Produto?> GetById(long id)
        {
            try
            {
                var Produto = await _context.Produtos
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
                            
                            .Where(p => p.Nome.Contains(nome))
                            .ToListAsync();

            return Produtos;
        }

        public async Task<Produto?> Create(Produto produto)
        {


            await _context.AddAsync(produto);
            await _context.SaveChangesAsync();

            return produto;


            
        }
        public async Task<Produto?> Update(Produto Produtos)
        {
            var ProdutoUpdate = await _context.Produtos.FindAsync(Produtos.Id);

            if (ProdutoUpdate is null) // verficando se a informação digitida existe
                return null;

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
