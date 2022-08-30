using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Role.Model
{
    public class Role
    {
        [Key, Column("id")]
        public Guid id { get; set; }
        public string Nom { get; set; }
    //    public User User { get; set; }

    }
}
