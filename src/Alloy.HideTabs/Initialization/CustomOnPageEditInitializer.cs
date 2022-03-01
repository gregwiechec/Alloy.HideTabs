﻿using EPiServer.Cms.Shell.UI.UIDescriptors.ViewConfigurations.Internal;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using Microsoft.Extensions.DependencyInjection;

namespace Alloy.HideTabs.Initialization
{
    /// <summary>
    /// Module that overrides default form editing view
    /// </summary>
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class CustomOnPageEditInitializer : IConfigurableModule
    {
        public void ConfigureContainer(ServiceConfigurationContext context)
        {
            context.Services.Intercept<EPiServer.Shell.ViewConfiguration>(
                (locator, defaultView) => defaultView is FormEditing ? new CustomFormEditing() : defaultView);
        }
        public void Initialize(InitializationEngine context) { }
        public void Uninitialize(InitializationEngine context) { }
    }

    public class CustomFormEditing : FormEditing
    {
        public CustomFormEditing()
        {
            ViewType = "alloy-hideTabs/FormEditing";
        }
    }

    /* [ServiceConfiguration(typeof(ViewConfiguration))]
     public class CustomFormEditing : OnPageEditing
     {
         public CustomFormEditing()
         {
             this.ViewType = "Alloy-HideTabs/OnPageEdititing";
             this.SortOrder = 10;
         }
     }*/
}
