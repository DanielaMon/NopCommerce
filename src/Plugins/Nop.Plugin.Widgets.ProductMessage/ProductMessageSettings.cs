using Nop.Core.Configuration;

namespace Nop.Plugin.Widgets.ProductMessage
{
    public class ProductMessageSettings : ISettings
    {
        public string MessageText { get; set; }
        public string WidgetZone { get; set; }
    }
}