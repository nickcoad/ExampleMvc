using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcExample.Web.Models.Shared;

namespace MvcExample.Web.Models.Books
{
    public class BooksCreateViewModel
    {
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }

        public Guid AuthorId { get; set; }
        public IEnumerable<AuthorSelectable> Authors { get; set; }
    }
}
