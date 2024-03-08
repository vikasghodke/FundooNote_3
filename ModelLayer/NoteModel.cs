namespace ModelLayer
{
    public class NoteModel
    {
        public string title { get; set; }
        public string color { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsArchived { get; set; } = false;
        //[ForeignKey("User")]

    }
}
