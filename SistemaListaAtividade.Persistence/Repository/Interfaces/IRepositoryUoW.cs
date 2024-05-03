using Microsoft.EntityFrameworkCore.Storage;

namespace SistemaListaAtividade.Persistence.Repository.Interfaces
{
    public interface IRepositoryUoW
    {
        IPersonRepository PersonRepository { get; }
        IPracticeRepository PracticeRepository { get; }

        Task SaveAsync();
        void Commit();
        IDbContextTransaction BeginTransaction();
    }
}