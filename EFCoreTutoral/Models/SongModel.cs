using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EFCoreTutoral.Models
{
    [Table("T_Songs")]
    public class SongModel
    {
        /// The unique identifier
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private int id;

        /// <summary>
        /// The genre name
        /// </summary>
        [Required]
        [StringLength(50)]
        private string title = null!;
        public string Title { get => title; set => title = value; }

        public int Id { get { return id; } set { id = value; } }

        [ForeignKey("Artist")]
        public int ArtistId { get; set; }
        public virtual ArtistModel? Artist { get; set; }

        [ForeignKey("Genre")]
        public int GenreId { get; set; }

        public virtual GenreModel? Genre { get; set; }




    }
}
