using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infrastructure.Persistence.Configurations
{
    public class ProjectCommentConfiguration : IEntityTypeConfiguration<ProjectComment>
    {
        public void Configure(EntityTypeBuilder<ProjectComment> builder)
        {
            builder
            .HasKey( p => p.Id);


            builder
            .HasOne( p => p.project)
            .WithMany( p => p.Comments)
            .HasForeignKey( p => p.IdProject)
            .OnDelete(DeleteBehavior.Restrict);

            builder
            .HasOne( p => p.user)
            .WithMany( p => p.Comments)
            .HasForeignKey( p => p.IdUSer)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}