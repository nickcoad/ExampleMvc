using System;
using System.Collections.Generic;
using System.Text;

namespace MvcExample.Domain.Models.Authors
{
    public class AuthorDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
