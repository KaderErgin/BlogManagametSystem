namespace Domain.Entities;

public class User : NArchitecture.Core.Security.Entities.User<Guid>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    
   

    //ilişki kısmı
    //Bir kullancının birden fazla yorumu olabilir
    public virtual ICollection<Comment>? Comments { get; set; } = null;
    //bir kullanıcının birden fazla blogpsotu olabilir
    public virtual ICollection<BlogPost>? BlogPost { get; set; } = null;


    //sistemin kendi alanları-START
    public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; } = default!;//bir kullanıcının birden çok işlem talebi olabilir one-to-many
    //kullanıcının oturumunun süresini uzatmak veya yeniden doğrulamak için
    public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = default!;// bir kullanıcının birden çok yenileme anahtarı olabilir one-to-many
    //bir kullanıcının iki faktörlü kimlik doğrulama için tek kullanımlık şifreler (OTP) 
    public virtual ICollection<OtpAuthenticator> OtpAuthenticators { get; set; } = default!; //bir kullanıcının birden çok OTP doğrulayıcısı olabilir one-to-many
    // e-posta yoluyla kimlik doğrulamasını sağlayan nesneler
    public virtual ICollection<EmailAuthenticator> EmailAuthenticators { get; set; } = default!;//bir kullanıcının birden çok e-posta doğrulayıcısı olabilir one-to-many
                                                                                                //sistemin kendi alanları-END

}
