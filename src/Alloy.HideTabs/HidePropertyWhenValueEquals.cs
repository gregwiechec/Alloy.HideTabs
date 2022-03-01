using System;
using Alloy.HideTabs.VisibilityAttributes;

namespace Alloy.HideTabs
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class HidePropertyWhenValueEquals : PropertyVisibilityAttributeBase
    {
        public HidePropertyWhenValueEquals(string propertyName, object value) : base(propertyName, value)
        {
        }
    }
}
