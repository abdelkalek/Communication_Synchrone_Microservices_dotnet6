using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace User.Model
{
    public class User
    {
        [Key, Column("id")]
        public Guid id { get; set; }
        public string Nom  { get; set; }
        public string Prenom  { get; set; }
        public Guid RoleID { get; set; }
        public Role Role { get; set; }

    }
}
