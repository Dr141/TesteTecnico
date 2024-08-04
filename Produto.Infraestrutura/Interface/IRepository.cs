
namespace Produto.Infraestrutura.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        public ValueTask<TEntity> GetByIdAsync(int id);

        public Task<List<TEntity>> GetAllAsync();

        public Task AddAsync(TEntity entity);

        public void Remove(TEntity entity);

        public void Update(TEntity entity);
    }
}
