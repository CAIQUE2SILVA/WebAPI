using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Model
{

    [Table("books")]
    public class Book
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public long Id { get; set; }
        
        [Required]
        [Column("title")]
        public string Title { get; set; }

        [Required]
        [Column("author", TypeName= "varchar(MAX)")]
        public string Author { get; set; }
        [MaxLength(200)]

        [Required]
        [Column("price")]
        public decimal Price { get; set; }

        [Required]
        [Column("launch_date")]
        public DateTime Launch_date { get; set; }
    }
}
