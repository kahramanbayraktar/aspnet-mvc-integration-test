using AspNetMvcIntegrationTest.Data.Repositories;

namespace AspNetMvcIntegrationTest.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        VideoRepository Videos { get; set; }

        void Complete();
    }
}