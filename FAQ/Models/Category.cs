// Category.cs 
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FAQ.Models
{
    public class Category
    {
        // Entities are rows in a C# database. 
        public string CategoryId { get; set; } = string.Empty; 
        public string Name { get; set; } = string.Empty;
        
    }

    // make a category constructor and on model builder
}