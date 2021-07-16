using Cysharp.Threading.Tasks;
using UniGame.UiSystem.Runtime;
using UniModules.UniGame.UiSystem.Runtime.Extensions;
using UnityEngine.UI;

public class DemoSuspendingScreenWindowView : 
    UiCanvasGroupView<EmptyViewModel>,
    IScreenSuspendingWindow
{
    public Button close;

    protected override UniTask OnViewInitialize(EmptyViewModel model)
    {
        this.Bind(close, x => Close());
        
        return UniTask.CompletedTask;
    }
}


