using System.ComponentModel.DataAnnotations;

namespace SmcLibrary.Core.Models
{
    public class Video : LibraryAsset
    {
        [Required]
        public string Director { get; set; }
    }
}