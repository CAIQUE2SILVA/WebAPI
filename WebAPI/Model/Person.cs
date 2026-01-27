using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Model
{
    [Table("person")]
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        [Required]
        public long Id { get; set; }

        [Column("frist_name", TypeName = "varchar(80)")]
        [MaxLength(80)]
        public string FristName { get; set; }

        [Required]
        [Column("last_name", TypeName = "varchar(80)")]
        [MaxLength(80)]
        public string LastName { get; set; }

        [Required]
        [Column("address", TypeName = "varchar(200)")]
        [MaxLength(200)]
        public string Address { get; set; }

        [Required]
        [Column("gender", TypeName = "varchar(6)")]
        [MaxLength(6)]
        public string Gender { get; set; }
    }
}
