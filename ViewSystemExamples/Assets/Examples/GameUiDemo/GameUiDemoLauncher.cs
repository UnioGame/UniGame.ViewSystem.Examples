using Cysharp.Threading.Tasks;
using UniGame.UiSystem.Runtime;
using UniModules.UniGame.UISystem.Runtime.Abstract;
using UnityEngine;

public class GameUiDemoLauncher : MonoBehaviour
{
    
    public GameViewSystemAsset gameViewSystemPrefab;

    public DemoModelDataSource modelSource;
    
    private IGameViewSystem _viewSystem;
    
    private async void Start()
    {
        _viewSystem = Instantiate(gameViewSystemPrefab.gameObject).GetComponent<GameViewSystemAsset>();

        await CreateGameViews();
    }


    private async UniTask CreateGameViews()
    {
        await _viewSystem.OpenScreen<DemoGameScreenView>(modelSource.CreateDemoScreenViModel());
        await _viewSystem.OpenOverlay<NotificationButtonView>(new EmptyViewModel());
    }

}
