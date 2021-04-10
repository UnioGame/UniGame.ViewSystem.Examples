using Cysharp.Threading.Tasks;
using TMPro;
using UniGame.UiSystem.Runtime;
using UniModules.UniGame.UiSystem.Runtime.Extensions;
using UnityEngine.Localization;

namespace Examples.LocalizationDemo.Scripts
{
    public class LocalizedView : UiCanvasGroupView<LicalizedViewModel>
    {
        public TextMeshProUGUI _label1;
        public TextMeshProUGUI _label2;
        public TextMeshProUGUI _label3;
        public TextMeshProUGUI _label4;

        public LocalizedString _label1String;
        public LocalizedString _label2String;
        public LocalizedString _label3String;
        public LocalizedString _label4String;
        
        protected override UniTask OnViewInitialize(LicalizedViewModel model)
        {
            this.BindTo(_label1String,x => _label1.text = x);
            this.BindTo(_label2String,x => _label2.text = x);
            this.BindTo(_label3String,x => _label3.text = x);
            this.BindTo(_label4String,x => _label4.text = x);
            
            return base.OnViewInitialize(model);
        }
    }
}