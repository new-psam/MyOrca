using Microsoft.EntityFrameworkCore;

namespace MyOrca.Data;

public class OrcaDataContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer(@"Server=localhost, 1433; Database=MyOrca; User Id=sa; Password=1q2w3e4r@#$;
                            Encrypt=True;TrustServerCertificate=True;");
}