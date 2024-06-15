using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace EFCoreTutoral.Models
{
    [Table("T_Artists")]
    public class ArtistModel
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
        private string firstName = null!;
        /// <summary>
        /// The genre name
        /// </summary>
        [Required]
        [StringLength(50)]
        private string lastName = null!;

        public int Id { get => id; set => id = value; } 

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }

        public virtual List<SongModel>? Songs { get; set; }

    }
}
