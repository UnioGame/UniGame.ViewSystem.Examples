using System;
using UniGame.UiSystem.Runtime;
using UniModules.UniCore.Runtime.Rx.Extensions;
using UniModules.UniGame.Core.Runtime.Rx;
using UniRx;

[Serializable]
public class UiDemoWindowViewModel : ViewModelBase, IUiDemoWindowViewModel
{
    public RecycleReactiveProperty<IDemoWindowContentViewModel> content;

    public IReadOnlyReactiveProperty<IDemoWindowContentViewModel> Content => content;

    public UiDemoWindowViewModel()
    {
        content = new RecycleReactiveProperty<IDemoWindowContentViewModel>().AddTo(LifeTime);
    }
}
