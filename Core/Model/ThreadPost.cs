namespace Core.Model
{
    public class ThreadPost
    {
        public int Id { get; set; }  
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public int Votes { get; set; } = 0;
        
    }
}