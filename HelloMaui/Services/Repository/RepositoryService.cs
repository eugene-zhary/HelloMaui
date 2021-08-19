using HelloMaui.Models;
using SQLite;
using System.Linq.Expressions;

namespace HelloMaui.Services.Repository
{
    public class RepositoryService : IRepositoryService
    {
        private readonly SQLiteAsyncConnection _sqlConnection;

        public RepositoryService()
        {
            string localDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string databasePath = Path.Combine(localDocumentsPath, Constants.DATABASE_PATH);

            _sqlConnection = new SQLiteAsyncConnection(databasePath);
        }

        #region -- IRepositoryService implementation --

        public async Task AddAsync<T>(T entity) where T : IEntityBase, new()
        {
            await _sqlConnection.CreateTableAsync<T>();

            await _sqlConnection.InsertAsync(entity);
        }

        public async Task RemoveAsync<T>(T entity) where T : IEntityBase, new()
        {
            await _sqlConnection.CreateTableAsync<T>();

            await _sqlConnection.DeleteAsync(entity);
        }

        public async Task UpdateAsync<T>(T entity) where T : IEntityBase, new()
        {
            await _sqlConnection.CreateTableAsync<T>();

            await _sqlConnection.UpdateAsync(entity);
        }

        public async Task<IEnumerable<T>> GetAsync<T>(Expression<Func<T, bool>> pred = null) where T : IEntityBase, new()
        {
            await _sqlConnection.CreateTableAsync<T>();

            return pred != null
                ? await _sqlConnection.Table<T>().Where(pred).ToListAsync()
                : await _sqlConnection.Table<T>().ToListAsync();
        }

        public async Task<T> FirstOrDefaultAsync<T>(Expression<Func<T, bool>> pred = null) where T : IEntityBase, new()
        {
            await _sqlConnection.CreateTableAsync<T>();

            return pred != null
                ? await _sqlConnection.Table<T>().FirstOrDefaultAsync(pred)
                : await _sqlConnection.Table<T>().FirstOrDefaultAsync();
        }

        #endregion
    }
}