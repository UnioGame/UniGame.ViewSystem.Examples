using Cysharp.Threading.Tasks;
using UniGame.UiSystem.Runtime;
using UniModules.UniGame.UiSystem.Runtime.Extensions;
using UniModules.UniGame.UISystem.Runtime.Extensions;
using UnityEngine.UI;

public class NotificationButtonView : UiCanvasGroupView<EmptyViewModel>
{
    public Button openNotifications;
    
    protected override UniTask OnViewInitialize(EmptyViewModel model)
    {
        this.Bind(openNotifications, 
            async x => await this.OpenAsWindowAsync<DemoSuspendingScreenWindowView>(new EmptyViewModel()));

        return UniTask.CompletedTask;
    }
}
