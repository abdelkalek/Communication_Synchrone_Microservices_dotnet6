using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace User.Model.Dtos
{
    public class UserDto
    {

        [Key, Column("id")]
        public Guid id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public Guid roleId { get; set; }
    }



}
