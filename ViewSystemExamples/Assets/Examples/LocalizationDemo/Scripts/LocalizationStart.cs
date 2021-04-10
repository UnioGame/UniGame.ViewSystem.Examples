using Examples.LocalizationDemo.Scripts;
using UnityEngine;

namespace UniGame.UiSystem.Examples.ListViews
{
    using BaseUiManager.Scripts;
    using Runtime;
    using UniCore.Runtime.ProfilerTools;
    using UniModules.UniGame.UiSystem.Runtime.Extensions;
    using UniModules.UniGame.UISystem.Runtime.Abstract;
    using UniRx;
    using ViewModels;
    using Views;

    public class LocalizationStart : MonoBehaviour
    {
        public GameViewSystemAsset viewSystem;

        public DemoListViewModel listModel = new DemoListViewModel();

        public DemoResourceUiViewModel resourceModel = new DemoResourceUiViewModel();
        
        // Start is called before the first frame update
        private async void Start()
        {
            var view = await viewSystem.OpenScreen<LocalizedView>(new LicalizedViewModel());

            listModel.AddTo(this);
            resourceModel.AddTo(this);
            view.Show();
            
        }

    }
}
