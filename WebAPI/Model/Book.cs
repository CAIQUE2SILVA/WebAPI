using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAPI.Model.Base;

namespace WebAPI.Model
{
    [Table("books")]
    public class Book : BaseEntidy
    {
        [Required]
        [Column("title", TypeName = "varchar(MAX)")]
        public string Title { get; set; }

        [Required]
        [Column("author", TypeName = "varchar(MAX)")]
        public string Author { get; set; }

        [Required]
        [Column("price")]
        public decimal Price { get; set; }

        [Required]
        [Column("launch_date")]
        public DateTime LaunchDate { get; set; }
    }
}
