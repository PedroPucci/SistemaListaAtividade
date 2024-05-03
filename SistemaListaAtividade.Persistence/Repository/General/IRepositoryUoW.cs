using Microsoft.EntityFrameworkCore.Storage;
using SistemaListaAtividade.Persistence.Repository.Interfaces;

namespace SistemaListaAtividade.Persistence.Repository.General
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