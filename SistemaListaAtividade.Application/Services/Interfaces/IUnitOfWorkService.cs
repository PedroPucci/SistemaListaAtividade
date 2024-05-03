namespace SistemaListaAtividade.Application.Services.Interfaces
{
    public interface IUnitOfWorkService
    {
        PersonService PersonService { get; }
        PracticeService PracticeService { get; }
    }
}