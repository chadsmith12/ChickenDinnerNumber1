using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;

namespace ChickenDinnerNumber1.Controls
{
    public class EnumPicker<T> : Picker where T : struct
    {
        public EnumPicker()
        {
            SelectedIndexChanged += OnSelectedIndexChanged;
            // Fill the Items from the enum
            foreach (var value in Enum.GetValues(typeof(T)))
            {
                Items.Add(GetEnumDescription(value));
            }
        }

        /// <summary>
        /// The bindable SelectedItem. 
        /// The item that got selected.
        /// </summary>
        public new static BindableProperty SelectedItemProperty = BindableProperty.Create(nameof(SelectedItem), typeof(T), typeof(EnumPicker<T>), default(T), propertyChanged: OnSelectedItemChanged, defaultBindingMode: BindingMode.TwoWay);

        /// <summary>
        /// The item that got selected.
        /// </summary>
        public new T SelectedItem
        {
            get => (T) GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
        }

        /// <summary>
        /// Event callback for when we change the index we have selected in the picker.
        /// Sets the SelectedItem to this index.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void OnSelectedIndexChanged(object sender, EventArgs eventArgs)
        {
            if (SelectedIndex < 0 || SelectedIndex > Items.Count - 1)
            {
                SelectedItem = default(T);
            }
            else
            {
                //try parsing, if using description this will fail
                if (!Enum.TryParse<T>(Items[SelectedIndex], out T match))
                {
                    //find enum by Description
                    match = GetEnumByDescription(Items[SelectedIndex]);
                }
                SelectedItem = (T)Enum.Parse(typeof(T), match.ToString());
            }
        }

        /// <summary>
        /// Event callback for when we change the item that is selected.
        /// </summary>
        /// <param name="bindable">The bindable object.</param>
        /// <param name="oldvalue">The value the item used to be.</param>
        /// <param name="newvalue">The new value this item is.</param>
        private static void OnSelectedItemChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var picker = bindable as EnumPicker<T>;
            if (newvalue != null && picker != null)
            {
                picker.SelectedIndex = picker.Items.IndexOf(GetEnumDescription(newvalue));
            }
        }

        private static string GetEnumDescription(object value)
        {
            var result = value.ToString();
            var attribute = typeof(T).GetRuntimeField(value.ToString()).GetCustomAttributes<DisplayAttribute>(false).SingleOrDefault();

            if (attribute != null)
                result = attribute.Description;

            return result;
        }

        private static T GetEnumByDescription(string description)
        {
            return Enum.GetValues(typeof(T)).Cast<T>().FirstOrDefault(x => string.Equals(GetEnumDescription(x), description));
        }
    }
}
