using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LibraryManagementSystem.Models
{
    public class Author
    {
        public int Id { get; set; }  // EF assumes Id as PK by convention

        public string? Name { get; set; }

        public string? Biography { get; set; }

        public string? Nationality { get; set; }

        public string? Email { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedDate { get; set; }

        [JsonIgnore]
        public List<Book>? Books { get; set; }
    }
}
