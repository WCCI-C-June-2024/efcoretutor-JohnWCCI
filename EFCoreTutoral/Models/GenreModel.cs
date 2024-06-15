using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreTutoral.Models
{
    /// <summary>
    /// This contains all the different Genres for the songs
    /// </summary>
    [Table("T_Genres")] 
    public class GenreModel
    {
        /// <summary>
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
        private string genreName = null!;

        public int Id { get { return id; } set { id = value; } }

        public string GenreName { get {  return genreName; } set {  genreName = value; } }  
    }
}
