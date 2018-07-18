using Microsoft.AspNetCore.Mvc.Rendering;

namespace MvcExample.Web.Infrastructure
{
    public interface ISelectable
    {
        SelectListItem ToSelectListItem();
    }
}
