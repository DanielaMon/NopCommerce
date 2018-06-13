using Nop.Web.Framework.Mvc.ModelBinding;
using Nop.Web.Framework.Models;

namespace Nop.Plugin.Widgets.ProductMessage.Models
{
    public class ConfigurationModel : BaseNopModel
    {
        public int ActiveStoreScopeConfiguration { get; set; }
        
        [NopResourceDisplayName("Plugins.Widgets.ProductMessage.MessageText")]
        public string MessageText { get; set; }
        public bool MessageText_OverrideForStore { get; set; }
    }
}