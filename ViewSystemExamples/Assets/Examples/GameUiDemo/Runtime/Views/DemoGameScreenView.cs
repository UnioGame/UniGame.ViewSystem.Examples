using Cysharp.Threading.Tasks;
using UniGame.UiSystem.Runtime;
using UniModules.UniCore.Runtime.Extension;
using UniModules.UniGame.UiSystem.Runtime.Extensions;
using UniModules.UniGame.UISystem.Runtime.Extensions;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class DemoGameScreenView : UiCanvasGroupView<DemoUiScreenViewModel>
{
    #region inspector

    public DemoResourceView prefabResourceView;

    public Button showWindow1;
    public Button showWindow2;
    public Button showWindow3;

    public SkinId secondWindowSkinId;
    public SkinId thirdWindowSkinId;
    
    public Transform resourcesViewsParent;
    
    #endregion

    protected override async UniTask OnViewInitialize(DemoUiScreenViewModel model)
    {
        
        var showWindowObserver = showWindow1
            .OnClickAsObservable()
            .CombineLatest(model.FirstWindowSource, (x, windowModel) => windowModel);
        
        var showSecondWindowObserver = showWindow2
            .OnClickAsObservable()
            .CombineLatest(model.SecondWindowSource, (x, windowModel) => windowModel);

        var thirdWindowModel = await model.ThirdWindowSource.AwaitFirstAsync(ModelLifeTime);
        
        //flow bind syntax
        this.Bind(showWindowObserver, async x => await this.OpenAsWindowAsync<DemoWindowView>(x, secondWindowSkinId))
            .Bind(showSecondWindowObserver, async x => await this.OpenAsWindowAsync<DemoWindowView>(x))
            .Bind(model.ReactiveResources.ObserveAdd(), async x => await OnScreenResourceAdded(x.Value));
        
        BindNested(prefabResourceView,model.NonReactiveResource);
        prefabResourceView.Show();
        
        //another form of binding
        BindTo(showWindow3.OnClickAsObservable(), async x => await this.OpenAsWindowAsync<DemoWindowView>(thirdWindowModel,thirdWindowSkinId));
        
    }

    private async UniTask OnScreenResourceAdded(IDemoResourceViewModel resourceViewModel)
    {
        await this.ShowNestedViewAsync<DemoResourceView>(resourceViewModel, resourcesViewsParent);
    }
}
