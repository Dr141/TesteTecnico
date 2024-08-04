using Microsoft.EntityFrameworkCore;
using Produto.Infraestrutura.Context;
using Produto.Infraestrutura.Interface;

namespace Produto.Infraestrutura.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ProdutoContext ProdutoContext;

        public Repository(ProdutoContext pContext)
        {
            ProdutoContext = pContext;
        }

        public async Task AddAsync(TEntity entity)
        {
            await ProdutoContext.Set<TEntity>().AddAsync(entity);
            await ProdutoContext.SaveChangesAsync();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await ProdutoContext.Set<TEntity>().ToListAsync();
        }

        public async ValueTask<TEntity> GetByIdAsync(int id)
        {
            return await ProdutoContext.Set<TEntity>().FindAsync(id);
        }

        public void Remove(TEntity entity)
        {
            ProdutoContext.Set<TEntity>().Remove(entity);
            ProdutoContext?.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            ProdutoContext.Set<TEntity>().Update(entity);
            ProdutoContext?.SaveChanges();
        }
    }
}
