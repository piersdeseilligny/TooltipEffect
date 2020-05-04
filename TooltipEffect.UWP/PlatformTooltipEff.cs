using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ResolutionGroupName(nameof(TooltipEffect))]
[assembly: ExportEffect(typeof(TooltipEffect.UWP.PlatformTooltipEff), nameof(TooltipEffect.TooltipEff))]
namespace TooltipEffect.UWP
{
    public class PlatformTooltipEff : PlatformEffect
    {

        protected override void OnAttached()
        {
            var control = Control ?? Container;
            if (control is DependencyObject)
            {
                ToolTip toolTip = new ToolTip();
                toolTip.Content = TooltipEff.GetText(Element);
                switch (TooltipEff.GetPosition(Element))
                {
                    case TooltipPosition.Bottom:
                        toolTip.Placement = Windows.UI.Xaml.Controls.Primitives.PlacementMode.Bottom;
                        break;
                    case TooltipPosition.Top:
                        toolTip.Placement = Windows.UI.Xaml.Controls.Primitives.PlacementMode.Top;
                        break;
                    case TooltipPosition.Left:
                        toolTip.Placement = Windows.UI.Xaml.Controls.Primitives.PlacementMode.Left;
                        break;
                    case TooltipPosition.Right:
                        toolTip.Placement = Windows.UI.Xaml.Controls.Primitives.PlacementMode.Right;
                        break;
                    default:
                        return;
                }
                ToolTipService.SetToolTip(control, toolTip);
            }
        }

        protected override void OnDetached()
        {

        }
    }
}