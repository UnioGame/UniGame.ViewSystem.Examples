using UniGame.UiSystem.Runtime;
using UniModules.UniGame.Core.Runtime.Interfaces.Rx;
using UniRx;

public class DemoUiScreenViewModel : ViewModelBase, IDemoUiScreenViewModel
{

    //static data model
    public IDemoResourceViewModel NonReactiveResource { get; set; }

    //reactive model
    public IReactiveCollection<IDemoResourceViewModel> ReactiveResources { get; set; }
    
    public IReactiveProperty<IUiDemoWindowViewModel> FirstWindowSource { get; set; }
    
    public IReactiveProperty<IUiDemoWindowViewModel> SecondWindowSource { get; set; }
    
    public IReactiveProperty<IUiDemoWindowViewModel> ThirdWindowSource { get; set; }
    
    
} 
