using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugin.Widgets.ProductMessage.Models;
using Nop.Services.Configuration;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Widgets.ProductMessage.Components
{
    [ViewComponent(Name = "WidgetsProductMessage")]
    public class WidgetsProductMessageViewComponent : NopViewComponent
    {
        private readonly IStoreContext _storeContext;
        private readonly ISettingService _settingService;

        public WidgetsProductMessageViewComponent(IStoreContext storeContext,
            ISettingService settingService)
        {
            this._storeContext = storeContext;
            this._settingService = settingService;
        }

        public IViewComponentResult Invoke(string widgetZone, object additionalData)
        {
            var productMessageSettings = _settingService.LoadSetting<ProductMessageSettings>(_storeContext.CurrentStore.Id);

            var model = new PublicInfoModel
            {
                MessageText = productMessageSettings.MessageText,
            };

            if (string.IsNullOrEmpty(model.MessageText))
                //no product message inserted
                return Content("");

            return View("~/Plugins/Widgets.ProductMessage/Views/PublicInfo.cshtml", model);
        }
    }
}





