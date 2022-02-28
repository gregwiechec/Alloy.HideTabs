using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Alloy.HideTabs.VisibilityAttributes;
using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;

namespace Alloy.HideTabs.LayoutVisibilityResolver
{
    [ServiceConfiguration(typeof(ILayoutVisibilityResolver))]
    public class AttributeBasedLayoutVisibilityResolver : ILayoutVisibilityResolver
    {
        public IEnumerable<string> GetHiddenTabs(IContent content)
        {
            var result = new List<string>();

            var modelType = content.GetOriginalType();
            foreach (var property in modelType.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                var attributes = property.GetCustomAttributes();
                foreach (var attribute in attributes.OfType<TabVisibilityAttributeBase>())
                {
                    if (attribute is ShowTabWhenPropertyEqualsAttribute showAttr)
                    {
                        if (showAttr.Value.Equals(content.Property[property.Name].Value) == false)
                        {
                            result.Add(showAttr.TabName);
                        }
                        continue;
                    }
                    if (attribute is HideTabWhenPropertyEqualsAttribute hideAttr)
                    {
                        if (hideAttr.Value.Equals(content.Property[property.Name].Value) == true)
                        {
                            result.Add(hideAttr.TabName);
                        }
                    }
                }
            }

            return result.GroupBy(x => x).Select(x => x.FirstOrDefault());
        }

        public IEnumerable<string> GetHiddenProperties(IContent content)
        {
            var result = new List<string>();

            var modelType = content.GetOriginalType();
            foreach (var property in modelType.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                var attributes = property.GetCustomAttributes();
                foreach (var attribute in attributes.OfType<PropertyVisibilityAttributeBase>())
                {
                    if (attribute is ShowPropertyWhenValueEqualsAttribute showAttr)
                    {
                        if (showAttr.Value.Equals(content.Property[property.Name].Value) == false)
                        {
                            result.Add(showAttr.PropertyName);
                        }
                        continue;
                    }
                    if (attribute is HidePropertyWhenValueEquals hideAttr)
                    {
                        if (hideAttr.Value.Equals(content.Property[property.Name].Value) == true)
                        {
                            result.Add(hideAttr.PropertyName);
                        }
                    }
                }
            }

            return result.GroupBy(x => x).Select(x => x.FirstOrDefault());
        }
    }
}
