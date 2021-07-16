using UniModules.UniGame.UISystem.Runtime.Abstract;
using UniRx;
using UnityEngine;

public interface IDemoResourceViewModel : IViewModel
{

    IReactiveProperty<string> Label { get; }
    IReactiveProperty<int> Value { get; }
    IReactiveProperty<Sprite> Icon { get; }
    IReactiveCommand<Unit> ResourceAction { get; }
    
}


