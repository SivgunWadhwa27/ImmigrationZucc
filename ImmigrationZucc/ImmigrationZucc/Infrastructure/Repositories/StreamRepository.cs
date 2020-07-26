using ImmigrationZucc.Data;
using ImmigrationZucc.Data.Entities;
using System.Linq;

namespace ImmigrationZucc.Infrastructure.Repositories
{
    public interface IStreamRepository
    {
        Stream GetByStreamCode(string streamCode);
        Stream GetById(long streamId);
    }

    public class StreamRepository : IStreamRepository
    {
        private ApplicationDbContext _context;
        public StreamRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Stream GetByStreamCode(string streamCode)
        {
            var stream = _context.Streams.Where(o => o.StreamCode == streamCode).SingleOrDefault();
            return stream;
        }

        public Stream GetById(long streamId)
        {
            var stream = _context.Streams.Where(o => o.StreamId == streamId).SingleOrDefault();
            return stream;
        }
    }
}
