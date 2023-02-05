namespace EksamenFinish.Services
{
    public interface IMapViewModelToModel<TModel, TViewModel>
        where TModel : class
        where TViewModel : class
    {
        TModel MapToModel(TViewModel viewModel);
    }
}