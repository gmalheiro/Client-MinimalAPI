using System.ComponentModel.DataAnnotations.Schema;

namespace ClientAPI.Data
{
    [Table("Client")]
    public class Client
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public Client()
        {
            
        }


        public Client(string name, string description)
        {
            Name = name;
            Description = description;
        }

    }
}
