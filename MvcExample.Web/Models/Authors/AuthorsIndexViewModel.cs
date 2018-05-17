using System.Collections.Generic;
using MvcExample.Domain.Models.Authors;

namespace MvcExample.Web.Models.Authors
{
    public class AuthorsIndexViewModel
    {
        public List<AuthorDto> Authors { get; set; }
    }
}
