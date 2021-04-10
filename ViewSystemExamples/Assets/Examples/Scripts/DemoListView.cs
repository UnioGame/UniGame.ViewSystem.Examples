using UnityEngine;

namespace UniGame.UiSystem.Examples.ListViews.Views
{
    using System.Collections.Generic;
    using Cysharp.Threading.Tasks;
    using Runtime;
    using UniModules.UniGame.UISystem.Runtime.Abstract;
    using UniRx;
    
    using UnityEngine.UI;
    using ViewModels;

    public class DemoListView : WindowView<DemoListViewModel>
    {
        public RectTransform itemsParent;

        public Button addItem;

        public int skinsCount = 0;
        
        public List<DemoItemView> itemViews = new List<DemoItemView>();

        private int currentSkin = 0;
        
        protected override async UniTask OnViewInitialize(DemoListViewModel model)
        {
            await base.OnViewInitialize(model);
            
            var items = model.ListItems;

            BindTo(items.ObserveAdd(),async x => await CreateItem(x.Value));
            BindTo(items.ObserveRemove(), x => RemoveItem(x.Index));
            BindTo(addItem.onClick.AsObservable(),x => model.Add.Execute());
        }

        private async UniTask<DemoItemView> CreateItem(DemoItemViewModel itemModel)
        {
            DemoItemView view = null;
            
            if (skinsCount <= 0)
            {
                view = await Layout.Create<DemoItemView>(itemModel);
            }
            else
            {
                var skin = $"Skin {currentSkin % skinsCount}";
                currentSkin++;
                view = await Layout.Create<DemoItemView>(itemModel,skin);
            }

            view.transform.SetParent(itemsParent);
            itemViews.Add(view);
            LayoutRebuilder.MarkLayoutForRebuild(itemsParent);
            return view;
        }

        private void RemoveItem(int index)
        {
            var item = itemViews[index]; 
            itemViews.RemoveAt(index);
            item.Close();
        }
        
        
    }
}
