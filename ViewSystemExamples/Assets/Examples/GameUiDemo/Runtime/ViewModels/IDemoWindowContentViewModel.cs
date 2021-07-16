using UniModules.UniGame.UISystem.Runtime.Abstract;
using UniRx;
using UnityEngine;

public interface IDemoWindowContentViewModel : IViewModel
{
    public IReadOnlyReactiveProperty<Sprite> Icon { get; }
    
    public IReadOnlyReactiveProperty<string> Description { get; }
    
    public IReadOnlyReactiveProperty<IUiDemoWindowViewModel> WindowModel { get; }
    
}