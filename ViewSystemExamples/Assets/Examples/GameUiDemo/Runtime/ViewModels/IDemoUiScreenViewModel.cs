using UniModules.UniGame.Core.Runtime.Interfaces.Rx;
using UniRx;

public interface IDemoUiScreenViewModel
{
    IDemoResourceViewModel NonReactiveResource { get; }
    IReactiveCollection<IDemoResourceViewModel> ReactiveResources { get; }
    IReactiveProperty<IUiDemoWindowViewModel> FirstWindowSource { get; }
    IReactiveProperty<IUiDemoWindowViewModel> SecondWindowSource { get; }
    IReactiveProperty<IUiDemoWindowViewModel> ThirdWindowSource { get; }
}