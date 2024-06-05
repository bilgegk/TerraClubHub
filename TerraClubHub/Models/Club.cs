using System.ComponentModel.DataAnnotations;

namespace TerraClubHub.Models
{
    public enum ClubStatus
    {
        Open,
        Closed
    }

    public class Club
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public string? Image { get; set; } // This should store the file path

        [Required]
        public string Banner { get; set; }

        [Required]
        public ClubStatus Status { get; set; }
    }
}