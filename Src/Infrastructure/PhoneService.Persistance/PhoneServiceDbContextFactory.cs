using Microsoft.EntityFrameworkCore;
using PhoneService.Persistance;
using PhoneService.Domain;


namespace PhoneService.Persistance
{
    public class PhoneServiceDbContextFactory : DesignTimeDbContextFactoryBase<PhoneServiceDbContext>
    {
        protected override PhoneServiceDbContext CreateNewInstance(DbContextOptions<PhoneServiceDbContext> options)
        {
            return new PhoneServiceDbContext(options);
        }
    }
}
