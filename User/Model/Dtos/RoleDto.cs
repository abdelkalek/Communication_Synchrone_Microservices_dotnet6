using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace User.Model.Dtos
{
    public class RoleDto
    {
        [Key, Column("id")]
        public Guid id { get; set; }
        public string Nom { get; set; }


    }
}
