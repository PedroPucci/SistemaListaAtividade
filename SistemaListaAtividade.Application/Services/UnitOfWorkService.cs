using SistemaListaAtividade.Application.Services.Interfaces;

namespace SistemaListaAtividade.Application.Services
{
    public class UnitOfWorkService : IUnitOfWorkService
    {
        private readonly IRepositoryUoW _repositoryUoW;
        private PersonService personService;
        private PracticeService practiceService;

        public UnitOfWorkService(IRepositoryUoW repositoryUoW)
        {
            _repositoryUoW = repositoryUoW;
        }

        public PersonService PersonService
        {
            get
            {
                if (personService == null)
                {
                    personService = new PersonService(_repositoryUoW);
                }
                return personService;
            }
        }

        public PracticeService PracticeService
        {
            get
            {
                if (practiceService == null)
                {
                    practiceService = new PracticeService(_repositoryUoW);
                }
                return practiceService;
            }
        }        
    }
}