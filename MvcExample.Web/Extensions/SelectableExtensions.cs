using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcExample.Web.Infrastructure;

namespace MvcExample.Web.Extensions
{
    public static class SelectableExtensions
    {
        public static IEnumerable<SelectListItem> ToSelectListItems(this IEnumerable<ISelectable> selectables)
        {
            return selectables.Select(_ => _.ToSelectListItem());
        }
    }
}
