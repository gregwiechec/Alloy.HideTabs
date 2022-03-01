using System;

namespace Alloy.HideTabs.VisibilityAttributes
{
    /// <summary>
    /// Use this attribute to force tab visibility refresh
    /// when property value changed
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class RequiresLayoutRefreshAttribute : Attribute
    {
    }
}
