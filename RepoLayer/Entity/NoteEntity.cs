using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RepoLayer.Entity
{
    public class NoteEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NoteId { get; set; }
        public string Title { get; set; }
        public string Color { get; set; }
        public bool IsDeleted { get; set; }=false;
        public bool IsArchived { get; set; }=false;
        [JsonIgnore]
        public virtual UserEntity User { get; set; }

        [ForeignKey("Users")]
        public int UserID { get; set; }
    }
}
