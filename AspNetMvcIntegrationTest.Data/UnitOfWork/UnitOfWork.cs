using AspNetMvcIntegrationTest.Data.Models;
using AspNetMvcIntegrationTest.Data.Repositories;

namespace AspNetMvcIntegrationTest.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WeTubeContext _context;

        public UnitOfWork()
        {
            _context = new WeTubeContext();

            Videos = new VideoRepository(_context);
        }

        public VideoRepository Videos { get; set; }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}