using System.Linq;
using Xamarin.Forms;

namespace TooltipEffect
{
    public class TooltipEff : RoutingEffect
    {
        public TooltipEff() : base($"{nameof(TooltipEffect)}.{nameof(TooltipEff)}")
        {

        }

        public static readonly BindableProperty TextProperty =
          BindableProperty.CreateAttached("Text", typeof(string), typeof(TooltipEff), string.Empty, propertyChanged: OnTextChanged);

        public static readonly BindableProperty PositionProperty =
          BindableProperty.CreateAttached("Position", typeof(TooltipPosition), typeof(TooltipEff), TooltipPosition.Bottom);


        public static string GetText(BindableObject view)
        {
            return (string)view.GetValue(TextProperty);
        }

        public static void SetText(BindableObject view, string value)
        {
            view.SetValue(TextProperty, value);
        }

        public static TooltipPosition GetPosition(BindableObject view)
        {
            return (TooltipPosition)view.GetValue(PositionProperty);
        }

        public static void SetPosition(BindableObject view, TooltipPosition value)
        {
            view.SetValue(PositionProperty, value);
        }

        static void OnTextChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as View;
            if (view == null)
            {
                return;
            }

            string text = (string)newValue;
            if (!string.IsNullOrEmpty(text))
            {
                view.Effects.Add(new TooltipEff());
            }
            else
            {
                var toRemove = view.Effects.FirstOrDefault(e => e is TooltipEff);
                if (toRemove != null)
                {
                    view.Effects.Remove(toRemove);
                }
            }
        }

    }

    public enum TooltipPosition
    {
        Bottom,
        Right,
        Left,
        Top
    }
}