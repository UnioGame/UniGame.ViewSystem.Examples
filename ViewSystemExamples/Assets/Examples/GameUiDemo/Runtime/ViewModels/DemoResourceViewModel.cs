using System;
using UniGame.UiSystem.Runtime;
using UniRx;
using UnityEngine;

[Serializable]
public class DemoResourceViewModel : ViewModelBase, IDemoResourceViewModel
{
    public IReactiveProperty<string> Label { get; set; }
    public IReactiveProperty<int> Value { get;set; }
    public IReactiveProperty<Sprite> Icon { get;set; }
    public IReactiveCommand<Unit> ResourceAction { get; set; }
    
}
