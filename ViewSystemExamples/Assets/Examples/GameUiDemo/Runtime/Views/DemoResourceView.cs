using Cysharp.Threading.Tasks;
using TMPro;
using UniGame.UiSystem.Runtime;
using UniModules.UniGame.UiSystem.Runtime.Extensions;
using UniRx;
using UnityEngine.UI;

public class DemoResourceView : UiCanvasGroupView<IDemoResourceViewModel>
{
    #region inspector

    public Button button;
    public Image icon;
    public TextMeshProUGUI label;
    public TextMeshProUGUI value;

    #endregion


    protected override UniTask OnViewInitialize(IDemoResourceViewModel model)
    {
        this.Bind(model.Icon,icon)
            .Bind(model.Value,value)
            .Bind(model.Label,label)
            .Bind(button.OnClickAsObservable(),model.ResourceAction);
        
        return UniTask.CompletedTask;
    }
}
