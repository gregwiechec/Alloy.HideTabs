using System;

namespace Alloy.HideTabs.VisibilityAttributes
{
    /// <summary>
    /// Base class for tab visibility attributes
    /// </summary>
    public abstract class TabVisibilityAttributeBase : Attribute, ILayoutElementVisibilityAttribute
    {
        public string TabName { get; set; }

        public object Value { get; set; }

        protected TabVisibilityAttributeBase(string tabName, object value)
        {
            TabName = tabName;
            Value = value;
        }
    }
}
