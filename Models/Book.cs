using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LibraryManagementSystem.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;  // non-nullable

        public string ISBN { get; set; } = null!;   // non-nullable

        public string? Genre { get; set; }

        public int PageCount { get; set; }

        public string? Language { get; set; }

        public int PublicationYear { get; set; }

        public DateTime? PublishedDate { get; set; }

        public bool IsAvailable { get; set; } = true;

        public int AuthorId { get; set; }

        [JsonIgnore]
        public Author? Author { get; set; }
    }
}
