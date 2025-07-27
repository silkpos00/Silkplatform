using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminPanel.classes
{
    public class UserMenuItem
    {
        public int ID { get; set; }
        public int? ParentID { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }

        public List<UserMenuItem> Children { get; set; } = new List<UserMenuItem>();
    }
}