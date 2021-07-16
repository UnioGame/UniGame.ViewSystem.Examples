using UniModules.UniGame.UISystem.Runtime.Abstract;
using UniRx;

public interface IUiDemoWindowViewModel : IViewModel
{
    public IReadOnlyReactiveProperty<IDemoWindowContentViewModel> Content { get; }
    
 }
