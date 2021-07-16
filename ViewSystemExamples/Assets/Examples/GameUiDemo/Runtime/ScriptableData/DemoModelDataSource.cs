using System;
using Cysharp.Threading.Tasks;
using UniModules.UniCore.Runtime.Rx.Extensions;
using UniModules.UniGame.Core.Runtime.Rx;
using UniModules.UniGame.Core.Runtime.ScriptableObjects;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(menuName = "UniGame/ViewSystem/Examples/DemoModelDataSource",fileName = nameof(DemoModelDataSource))]
public class DemoModelDataSource : LifetimeScriptableObject
{

    public Sprite resourceIcon;
    public Sprite windowIcon;
    
    public int resourceCounter = 0;
    public int windowCounter = 0;

    public int resourcesCount = 3;
    
    public IDemoResourceViewModel CreateResourceViewModel()
    {
        var resourceId = resourceCounter;
        resourceCounter++;
        
        var command = new ReactiveCommand();
            command.Subscribe(x => Debug.Log($"RESOURCE {resourceId} Action"))
                .AddTo(LifeTime);
        
        return new DemoResourceViewModel()
        {
            Icon = new RecycleReactiveProperty<Sprite>(resourceIcon),
            Label =new RecycleReactiveProperty<string>( $"RESOURCE {resourceId}"),
            Value = new RecycleReactiveProperty<int>(Random.Range(1,1000)),
            ResourceAction = command
        };
    }

    public IDemoWindowContentViewModel CreateContentViewModel()
    {
        var windowModel = new DemoWindowContentViewModel();
        windowModel.windowModel.Value = new UiDemoWindowViewModel();
        return windowModel;
    }
    
    public IUiDemoWindowViewModel CreateWindowViewModel()
    {
        var model = new UiDemoWindowViewModel();
        model.content.Value = CreateContentViewModel();
        return model;
    }

    public DemoUiScreenViewModel CreateDemoScreenViModel()
    {
        var resources = new ReactiveCollection<IDemoResourceViewModel>();
        
        var screenModel = new DemoUiScreenViewModel()
        {
            ReactiveResources = resources,
            FirstWindowSource = new ReactiveProperty<IUiDemoWindowViewModel>(CreateWindowViewModel()),
            SecondWindowSource = new ReactiveProperty<IUiDemoWindowViewModel>(CreateWindowViewModel()),
            ThirdWindowSource = new ReactiveProperty<IUiDemoWindowViewModel>(CreateWindowViewModel()),
            NonReactiveResource = CreateResourceViewModel(),
        };
        
        CreateResources(resources).Forget();    
        
        return screenModel;
    }

    private async UniTask CreateResources(ReactiveCollection<IDemoResourceViewModel> resources)
    {
        await UniTask.Delay(500);
        
        for (var i = 0; i < resourcesCount; i++)
        {
            resources.Add(CreateResourceViewModel());
            await UniTask.Delay(1000);
        }
    }
    
}
