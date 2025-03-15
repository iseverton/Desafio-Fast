using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkshopManager.Api.Models;


namespace WorkshopManager.Api.Data.Mappings;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employee");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("id")
            .HasColumnType("int")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(e => e.Name)
            .HasColumnName("name")
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder.Property(e => e.Email)
            .HasColumnName("email")
            .HasColumnType("varchar(150)")
            .IsRequired();

        builder.Property(e => e.Password)
            .HasColumnName("password")
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder.Property(e => e.Role)
            .HasConversion<string>() 
            .HasMaxLength(30); 
    }
}
