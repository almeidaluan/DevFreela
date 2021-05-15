using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infrastructure.Persistence.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
             builder
            .HasKey( p => p.Id);

            builder // um projeto tem um PROJECT tem um freelancer e esse FREELANCER tem muitos projetos
            .HasOne(p => p.Freelancer)
            .WithMany(p => p.FreelancerProjects)
            .HasForeignKey( p => p.IdFreelancer)
            .OnDelete(DeleteBehavior.Restrict);


            builder // um projeto tem um PROJECT tem um freelancer e esse FREELANCER tem muitos projetos
            .HasOne(p => p.Client)
            .WithMany(p => p.OwnedProjects)
            .HasForeignKey( p => p.IdClient)
            .OnDelete(DeleteBehavior.Restrict);
            
        }
    }
}