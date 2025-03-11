using System;

namespace Core.Model

{
    public class Comment
    {
        public int Id { get; set; }
        public int ThreadId { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
        public string Author { get; set; }
        public int Votes { get; set; }
        public Thread Thread { get; set; }
    }
}