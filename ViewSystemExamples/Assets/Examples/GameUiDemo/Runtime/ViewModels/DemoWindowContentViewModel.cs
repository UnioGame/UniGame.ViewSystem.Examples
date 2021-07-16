using UniGame.UiSystem.Runtime;
using UniModules.UniCore.Runtime.Rx.Extensions;
using UniModules.UniGame.Core.Runtime.Rx;
using UniRx;
using UnityEngine;

public class DemoWindowContentViewModel : ViewModelBase, IDemoWindowContentViewModel
{
    #region private fields

    public RecycleReactiveProperty<Sprite> icon;
    public RecycleReactiveProperty<string> description;
    public RecycleReactiveProperty<IUiDemoWindowViewModel> windowModel;
    
    #endregion

    public IReadOnlyReactiveProperty<Sprite> Icon => icon;
    public IReadOnlyReactiveProperty<string> Description => description;
    public IReadOnlyReactiveProperty<IUiDemoWindowViewModel> WindowModel => windowModel;
    

    public DemoWindowContentViewModel()
    {

        icon = new RecycleReactiveProperty<Sprite>().AddTo(LifeTime);
        description = new RecycleReactiveProperty<string>().AddTo(LifeTime);
        windowModel = new RecycleReactiveProperty<IUiDemoWindowViewModel>().AddTo(LifeTime);

    }
    
}