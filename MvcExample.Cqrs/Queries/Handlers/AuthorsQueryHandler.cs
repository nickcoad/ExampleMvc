using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MvcExample.Cqrs.Queries.Interfaces;
using MvcExample.Cqrs.Queries.Models;
using MvcExample.Data;

namespace MvcExample.Cqrs.Queries.Handlers
{
    public class AuthorsQueryHandler<TResult> : IQueryHandler<AuthorsQuery, TResult>
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public AuthorsQueryHandler(
            IMapper mapper,
            DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<TResult>> Handle(AuthorsQuery query)
        {
            var skip = (query.Page - 1) * query.Count;

            return await _context
                    .Authors
                    .OrderBy(_ => _.Id)
                    .Skip(skip)
                    .Take(query.Count)
                    .ProjectTo<TResult>(_mapper.ConfigurationProvider)
                    .ToListAsync();
        }
    }
}
