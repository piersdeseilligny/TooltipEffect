using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using AView = Android.Views.View;

[assembly: ResolutionGroupName(nameof(TooltipEffect))]
[assembly: ExportEffect(typeof(TooltipEffect.Android.PlatformTooltipEff), nameof(TooltipEffect.TooltipEff))]
namespace TooltipEffect.Android
{
    public class PlatformTooltipEff : PlatformEffect
    {
        private AView View => Control ?? Container;
        protected override void OnAttached()
        {
            if(View == null)
            {
                return;
            }
            View.TooltipText = TooltipEff.GetText(Element);
        }

        protected override void OnDetached()
        {

        }
    }
}