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

        public async Task<Practice> AddPracticeAsync(Practice practice)
        {
            var result = await _context.Practice.AddAsync(practice);
            return result.Entity;
        }

        public Practice DeletePractice(Practice practiceToDelete)
        {
            var response = _context.Practice.Remove(practiceToDelete);
            return response.Entity;
        }

        public Practice UpdatePractice(Practice practice)
        {
            var response = _context.Practice.Update(practice);
            return response.Entity;
        }

        public async Task<List<Practice>> GetAllPracticesAsync()
        {
            return await _context.Practice
                .OrderBy(practice => practice.Name)
                .Select(practice => new Practice
                {
                    Name = practice.Name,
                    Description = practice.Description
                }).ToListAsync();
        }

        public async Task<Practice> GetPracticeByIdAsync(int? id)
        {
            return await _context.Practice.FirstOrDefaultAsync(practice => practice.Id == id);
        }
        public async Task<Practice> GetPracticeByNameAsync(string? name)
        {
            return await _context.Practice.FirstOrDefaultAsync(practice => practice.Name == name);
        }
    }
}