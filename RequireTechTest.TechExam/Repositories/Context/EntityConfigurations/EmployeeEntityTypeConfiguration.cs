using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RequireTechTest.TechExam.Models;

namespace RequireTechTest.TechExam.Repositories.Context.EntityConfigurations
{
    public class EmployeeEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
             builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                    .UseIdentityColumn();
            builder.Property(x => x.Name).HasMaxLength(255);
            builder.Property(x => x.BirthDate);
            builder.Ignore(x => x.Age);

            builder.HasIndex(b => new { b.BirthDate }, "IX_Birthday_Descending")
                .IsDescending();
        }
    }
}