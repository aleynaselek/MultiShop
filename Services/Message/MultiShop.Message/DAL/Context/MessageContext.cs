using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace MultiShop.Message.DAL.Entities
{
    public class MessageContext : DbContext
    {
        public MessageContext(DbContextOptions<MessageContext> options):base(options) 
        {  
        }

        public DbSet<UserMessage> UserMessages { get; set; }
    }
}
