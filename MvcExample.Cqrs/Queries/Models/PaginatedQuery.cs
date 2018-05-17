using MvcExample.Cqrs.Queries.Constants;

namespace MvcExample.Cqrs.Queries.Models
{
    public abstract class PaginatedQuery : BaseQuery
    {
        private int _page = 1;

        public int Page
        {
            get => _page;
            set => _page = value < 1 ? 1 : value;
        }
        public int Count { get; set; } = Defaults.DefaultPageSize;
    }
}
