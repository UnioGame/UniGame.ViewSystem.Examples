using Cysharp.Threading.Tasks;
using TMPro;
using UniGame.UiSystem.Runtime;
using UniModules.UniGame.UiSystem.Runtime.Extensions;
using UniModules.UniGame.UISystem.Runtime.Extensions;
using UniRx;
using UnityEngine.UI;

public class DemoWindowContentView : UiCanvasGroupView<IDemoWindowContentViewModel>
{
    #region inspector
    
    public Image icon;

    public TextMeshProUGUI description;

    public Button actionButton;

    public TextMeshProUGUI buttonLabel;

    public SkinId windowSkin;
    
    #endregion


    protected override UniTask OnViewInitialize(IDemoWindowContentViewModel model)
    {
        actionButton.interactable = model.WindowModel.HasValue;

        var newWindowData =
            model.WindowModel.CombineLatest(actionButton.OnClickAsObservable(), (windowModel, _) => windowModel);
        
        this.Bind(newWindowData, async x => await this.OpenAsWindowAsync<DemoWindowView>(x, windowSkin))
            .Bind(model.WindowModel,x => actionButton.interactable = x != null)
            .Bind(model.Description,description)
            .Bind(model.Icon,icon);

        return UniTask.CompletedTask;
    }
}
