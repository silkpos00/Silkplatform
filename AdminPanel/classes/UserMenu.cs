using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

namespace AdminPanel.classes
{
    public class UserMenu
    {
        public static List<UserMenuItem> BuildMenuTree(List<UserMenuItem> items)
        {
            var lookup = items.ToDictionary(x => x.ID);
            var rootItems = new List<UserMenuItem>();

            foreach (var item in items)
            {
                if (item.ParentID.HasValue && lookup.ContainsKey(item.ParentID.Value))
                {
                    lookup[item.ParentID.Value].Children.Add(item);
                }
                else
                {
                    rootItems.Add(item);
                }
            }

            return rootItems;
        }
        public static string GenerateMenuHtml(List<UserMenuItem> menuItems)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<ul class=\"menu-inner py-1\">");

            foreach (var item in menuItems)
            {
                sb.AppendLine(GenerateMenuItemHtml(item));
            }

            sb.AppendLine("</ul>");
            return sb.ToString();
        }

        private static string GenerateMenuItemHtml(UserMenuItem item)
        {
            StringBuilder sb = new StringBuilder();
            bool hasChildren = item.Children.Any();

            sb.AppendLine("<li class=\"menu-item\">");

            // اگر زیرمنو دارد => menu-toggle، اگر نه فقط menu-link
            var menuLinkClass = hasChildren ? "menu-link menu-toggle" : "menu-link";

            // اگر لینک دارد از آن استفاده کن، در غیر این صورت void
            var href = string.IsNullOrEmpty(item.Url) ? "javascript:void(0);" : item.Url;

            sb.AppendLine($"  <a href=\"{href}\" class=\"{menuLinkClass}\">");
            sb.AppendLine($"    {item.Icon}");
            sb.AppendLine($"    <div data-i18n=\"{item.Title}\">{item.Title}</div>");
            sb.AppendLine("  </a>");

            if (hasChildren)
            {
                sb.AppendLine("  <ul class=\"menu-sub\">"); // دیگه style=display:none نمی‌دیم
                foreach (var child in item.Children)
                {
                    sb.AppendLine(GenerateMenuItemHtml(child));
                }
                sb.AppendLine("  </ul>");
            }

            sb.AppendLine("</li>");

            return sb.ToString();
        }

    }
}