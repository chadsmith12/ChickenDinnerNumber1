using System;
using System.Linq;
using ChickenDinnerNumber1.Enums;
using Xamarin.Forms;

namespace ChickenDinnerNumber1.Effects
{
    public static class ReturnKeyEffect
    {
        public static readonly BindableProperty ReturnTypeProperty = BindableProperty.Create("KeyboardType", typeof(string), typeof(ReturnKeyEffect), null, propertyChanged: OnReturnTypeChanged);

        public static void OnReturnTypeChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var view = bindable as View;

            if (view == null)
            {
                return;
            }

            var returnType = (string)newvalue;
            if (returnType != null)
            {
                view.Effects.Add(new EntryReturnKeyEffect(ReturnType.Next));
            }
            else
            {
                var toRemove = view.Effects.FirstOrDefault(x => x is EntryReturnKeyEffect);
                if (toRemove != null)
                {
                    view.Effects.Remove(toRemove);
                }
            }
        }
    }

    public class EntryReturnKeyEffect : RoutingEffect
    {
        public EntryReturnKeyEffect(ReturnType returnType) : base("Twig.ReturnKeyEffect")
        {
            ReturnType = returnType;
        }

        public ReturnType ReturnType { get; set; }
    }
}
