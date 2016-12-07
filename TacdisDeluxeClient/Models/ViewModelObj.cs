using System.Collections.Generic;

namespace TacdisDeluxeClient.Models
{
    public class ViewModelObj
    {
        public string Id { get; set; }
        public List<MenuHeadLine> MenyData { get; set; }
    }

    public class MenuHeadLine
    {
        public string MenuHeadLineTitel { get; set; }
        public List<MenuSubLine> MenuSubLine { get; set; }
    }

    public class MenuSubLine
    {
        public string MenuSubLineTitel { get; set; }
        public string Controller { get; set; }
        public string ViewUrl { get; set; }
    }
}