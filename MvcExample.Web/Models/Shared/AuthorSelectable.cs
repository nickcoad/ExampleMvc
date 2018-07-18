using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcExample.Web.Infrastructure;

namespace MvcExample.Web.Models.Shared
{
    public class AuthorSelectable : ISelectable
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public SelectListItem ToSelectListItem()
        {
            return new SelectListItem { Text = $"{FirstName} {LastName}", Value = Id.ToString() };
        }
    }
}
