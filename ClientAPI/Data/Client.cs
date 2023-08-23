using System.ComponentModel.DataAnnotations.Schema;

namespace ClientAPI.Data
{
    [Table("Client")]
    public record Client(int Id, string Name, string Description);
}
