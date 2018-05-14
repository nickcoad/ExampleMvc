using System;
using System.Threading.Tasks;
using MvcExample.Data;
using MvcExample.Data.Entities;

namespace MvcExample.Cqrs.Commands
{
    public class CreateMovieCommand : BaseCommand
    {
        public Guid DirectorId { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
    }

    public class CreateMovieCommandHandler : ICommandHandler<CreateMovieCommand>
    {
        private readonly DataContext _dbContext;

        public CreateMovieCommandHandler(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(CreateMovieCommand dto)
        {
            var newMovie = new Movie
            {
                DirectorId = dto.DirectorId,
                Title = dto.Title,
                ReleaseDate = dto.ReleaseDate
            };

            _dbContext.Movies.Add(newMovie);

            await _dbContext.SaveChangesAsync();
        }
    }
}
