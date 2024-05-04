namespace SistemaListaAtividade.Application.Services.General
{
    public interface IUnitOfWorkService
    {
        PersonService PersonService { get; }
        PracticeService PracticeService { get; }
    }
}