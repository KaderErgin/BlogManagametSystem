using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Entities;
public class BlogPost : Entity<Guid>
{
    public string? Title { get; set; }//baslik
    public string? Contents { get; set; }//icerik
    public Guid UserId { get; set; } //yazar
    public DateTime ReleaseDate { get; set; } // Yayınlanma tarihi
    
    //ilişki kısmı
    //Bir blogpostun  birden fazla yorumu olabilir
    public virtual ICollection<Comment>? Comments { get; set; } = null;
    public virtual User? User { get; set; } = null;//user <-> blogpost  ilişki Fk


    public BlogPost()
    {
    }

    public BlogPost(string title,string contents,Guid userId,DateTime releaseDate)
    {
      Title= title;
      Contents= contents;
      UserId= userId;
      ReleaseDate= releaseDate;

    }
}