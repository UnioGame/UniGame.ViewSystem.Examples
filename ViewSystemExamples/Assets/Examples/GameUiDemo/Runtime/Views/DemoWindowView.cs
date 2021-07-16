using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UniGame.UiSystem.Runtime;
using UniModules.UniGame.UISystem.Runtime.Abstract;
using UniModules.UniGame.UiSystem.Runtime.Extensions;
using UniModules.UniGame.UISystem.Runtime.Extensions;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class DemoWindowView : UiCanvasGroupView<IUiDemoWindowViewModel>
{
    #region inspector

    public Transform windowContentParent;

    public Button closeContent;
    
    public Button closeWindow;
    
    public bool recreateViews = false;

    public List<SkinId> contentSkins = new List<SkinId>();
    
    #endregion

    private DemoWindowContentView _contentView;
    private int _activeIndex = 0;
    
    protected override UniTask OnViewInitialize(IUiDemoWindowViewModel model)
    {
        this.Bind(model.Content,async x =>await CreateWindowContent(x))
            .Bind(closeContent.OnClickAsObservable(),x => CloseContent())
            .Bind(closeWindow.OnClickAsObservable(),x => Close());

        //bind action to model lifetime
        ModelLifeTime.AddCleanUpAction(CloseContent);
        
        return UniTask.CompletedTask;
    }

    private void CloseContent()
    {
        _contentView?.Close();
        _contentView = null;
    }

    private async UniTask<IView> CreateWindowContent(IDemoWindowContentViewModel contentViewModel)
    {
        var view = recreateViews || _contentView == null
            ? await CreateContent(contentViewModel)
            : await _contentView.Initialize(contentViewModel);
        
        return view;
    }


    private async UniTask<DemoWindowContentView> CreateContent(IDemoWindowContentViewModel contentViewModel)
    {
        CloseContent();
        
        var useSkins = recreateViews == true && contentSkins.Count > 0;
        _activeIndex %= ( contentSkins.Count == 0 ? 1 :  contentSkins.Count);
        var targetSkin = useSkins ? (string)contentSkins[_activeIndex] : string.Empty;
           
        var contentView = await this.ShowViewAsync<DemoWindowContentView>(contentViewModel, windowContentParent,targetSkin);
        _activeIndex++;

        return contentView;
    }
    
}
