using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("Comments").HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.BlogPostId).HasColumnName("BlogPostId").IsRequired();
        builder.Property(c => c.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(c => c.CommentContent).HasColumnName("CommentContent").IsRequired();
        builder.Property(c => c.CommentDate).HasColumnName("CommentDate").IsRequired();
        builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);

        //Fk Blogpost-User için
        builder.HasOne(c => c.BlogPost)
               .WithMany(bp => bp.Comments)
               .HasForeignKey(c => c.BlogPostId)
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(c => c.User)
               .WithMany(u => u.Comments)
               .HasForeignKey(c => c.UserId)
               .OnDelete(DeleteBehavior.NoAction);
    }
}
