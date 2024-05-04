using Microsoft.EntityFrameworkCore;
using SistemaListaAtividade.Domain.Entities;
using SistemaListaAtividade.Persistence.Connections;
using SistemaListaAtividade.Persistence.Repository.Interfaces;

namespace SistemaListaAtividade.Persistence.Repository
{
    public class PracticeRepository : IPracticeRepository
    {
        private readonly DataContext _context;

        public PracticeRepository(DataContext context)
        {
            _context = context;
        }

        public Task<Practice> AddPracticeAsync(Practice practice)
        {
            throw new NotImplementedException();
        }

        public Practice DeletePractice(Practice practiceToDelete)
        {
            var response = _context.Practice.Remove(practiceToDelete);
            return response.Entity;
        }

        public Task<List<Practice>> GetAllPracticesAsync()
        {
            throw new NotImplementedException();
        }

        public Practice UpdatePractice(Practice practice)
        {
            throw new NotImplementedException();
        }

        public async Task<Practice> GetPracticeByIdAsync(int? id)
        {
            return await _context.Practice.FirstOrDefaultAsync(practice => practice.Id == id);
        }
    }
}