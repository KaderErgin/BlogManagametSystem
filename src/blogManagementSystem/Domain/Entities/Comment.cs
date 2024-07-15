using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Entities;

public class Comment : Entity<Guid>
{
    public Guid BlogPostId { get; set; }//yazı id'si
    public Guid UserId { get; set; } //yorum yapan
    public string CommentContent { get; set; }//yorum icerigi
    public DateTime CommentDate { get; set; } // Yorum tarihi
  


    //ilişki kısmı
    public virtual BlogPost? BlogPost { get; set; } = null;//yazi id'si ilişki Fk
    public virtual User? User { get; set; } = null;//ilişki Fk
    public Comment()
    {
    }

    public Comment(Guid blogPostId, Guid userId,string commentContent, DateTime commentDate)
    {
        BlogPostId = blogPostId;
        UserId = userId;
        CommentContent = commentContent;
        CommentDate = commentDate;
      
    }
}

