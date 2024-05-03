using Microsoft.EntityFrameworkCore.Storage;
using SistemaListaAtividade.Persistence.Connections;
using SistemaListaAtividade.Persistence.Repository.Interfaces;

namespace SistemaListaAtividade.Persistence.Repository.General
{
    public class RepositoryUoW : IRepositoryUoW
    {
        private readonly DataContext _context;
        private bool _disposed = false;
        private IPersonRepository? _personRepository = null;
        private IPracticeRepository? _practiceRepository = null;

        public RepositoryUoW(DataContext context)
        {
            _context = context;
        }

        public IPersonRepository PersonRepository
        {
            get
            {
                if (_personRepository == null)
                {
                    _personRepository = new PersonRepository(_context);
                }
                return _personRepository;
            }
        }

        public IPracticeRepository PracticeRepository => throw new NotImplementedException();

        //public IPracticeRepository PracticeRepository
        //{
        //    get
        //    {
        //        if (_practiceRepository == null)
        //        {
        //            _practiceRepository = new PracticeRepository(_context);
        //        }
        //        return _practiceRepository;
        //    }
        //}       

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }
    }
}