using System.Collections.Generic;
using Nop.Core;
using Nop.Core.Plugins;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Web.Framework.Infrastructure;

namespace Nop.Plugin.Widgets.ProductMessage
{
    /// <summary>
    /// Product message plugin
    /// </summary>
    public class ProductMessagePlugin : BasePlugin, IWidgetPlugin
    {
        #region Fields

        private readonly IWebHelper _webHelper;
        private readonly ISettingService _settingService;

        #endregion

        #region Ctor

        public ProductMessagePlugin(IWebHelper webHelper, ISettingService settingService,
            ProductMessageSettings productMessageSettings)
        {
            this._webHelper = webHelper;
            this._settingService = settingService;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets widget zones where this widget should be rendered
        /// </summary>
        /// <returns>Widget zones</returns>
        public IList<string> GetWidgetZones()
        {
            return new List<string> { PublicWidgetZones.ProductDetailsOverviewBottom };
        }

        /// <summary>
        /// Gets a configuration page URL
        /// </summary>
        public override string GetConfigurationPageUrl()
        {
            return _webHelper.GetStoreLocation() + "Admin/WidgetsProductMessage/Configure";
        }

        /// <summary>
        /// Gets a name of a view component for displaying widget
        /// </summary>
        /// <param name="widgetZone">Name of the widget zone</param>
        /// <returns>View component name</returns>
        public string GetWidgetViewComponentName(string widgetZone)
        {
            return "WidgetsProductMessage";
        }

        /// <summary>
        /// Install plugin
        /// </summary>
        public override void Install()
        {
            //settings
            var settings = new ProductMessageSettings
            {
                MessageText = ""
            };
            _settingService.SaveSetting(settings);

            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ProductMessage.MessageText", "Product message");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ProductMessage.MessageText.Hint", "Enter product message (e.g. 50% discount in December or Free shipping this weekend)");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ProductMessage.Instructions", "This plugin displays a message at the bottom of all the product detail pages in your store.</p>");

            base.Install();
        }

        /// <summary>
        /// Uninstall plugin
        /// </summary>
        public override void Uninstall()
        {
            //settings
            _settingService.DeleteSetting<ProductMessageSettings>();

            //locales
            this.DeletePluginLocaleResource("Plugins.Widgets.ProductMessage.MessageText");
            this.DeletePluginLocaleResource("Plugins.Widgets.ProductMessage.MessageText.Hint");
            this.DeletePluginLocaleResource("Plugins.Widgets.ProductMessage.Instructions");

            base.Uninstall();
        }

        #endregion
    }
}