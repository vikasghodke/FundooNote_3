using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepoLayer.Entity
{
    public class CollaboratorEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CollaboratorID { get; set; }

        [ForeignKey("Users")]
        public int UserID { get; set; }

        /*[JsonIgnore]
        public string Users {  get; set; }*/
        [ForeignKey("Notes")]
        public int NoteId { get; set; }
        /*[JsonIgnore]
        public string Notes { get; set; }*/

        public string CollaboratorEmail { get; set; }
    }
}
