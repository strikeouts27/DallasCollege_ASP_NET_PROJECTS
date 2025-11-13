// TopicModel.cs 
namespace FAQ.Models

{
    public class Topic
    {
        // must be a string per instructions
        public string TopicId { get; set; } = string.Empty; 
        public string Name { get; set; } = string.Empty; 
    }

    // make a topic constructor and on model builder
    // public FAQModel() { } // EF-friendly parameterless ctor

    //  protected void OnModelCreating(ModelBuilder modelBuilder)
}