using System.Collections.Generic;
using EPiServer.Core;

namespace Alloy.HideTabs
{
    public interface ILayoutVisibilityResolver
    {
        IEnumerable<string> GetHiddenTabs(IContent content);

        IEnumerable<string> GetHiddenProperties(IContent content);
    }
}
