using GlobalQueryFilter.Domain.Contracts.Common;
using GlobalQueryFilter.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GlobalQueryFilter.Data.Base
{
    public interface IDatabaseContext
    {
        DbSet<T> Set<T>() where T : class;
        Task<int> CommmitAsync(CancellationToken cancellationToken);
    }

    public class DatabaseContext : DbContext, IDatabaseContext
    {
        private readonly IUserRequest _userRequest;
        public DatabaseContext(DbContextOptions options, IUserRequest userRequest) : base(options)
        {
            _userRequest = userRequest;
        }

        public async Task<int> CommmitAsync(CancellationToken cancellationToken)
        {
            return await SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            modelBuilder.Entity<Invoice>().HasQueryFilter(x => x.Owner == _userRequest.Email);
        }
    }
}
