using System.Collections.Generic;

namespace EksamenFinish.Services
{
    public interface IMapModelToViewModel<TModel, TViewModel>
        where TModel : class
        where TViewModel : class
    {
        TViewModel MapToViewModel(TModel model);

        List<TViewModel> MapToViewModelList(List<TModel> models);
    }
}