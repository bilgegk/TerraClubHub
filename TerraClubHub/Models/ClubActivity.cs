using System;
using System.ComponentModel.DataAnnotations;

namespace TerraClubHub.Models
{
    public class ClubActivity
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public decimal Budget { get; set; }

        [Required]
        public decimal CostPerPerson { get; set; }

        public int NumberOfMembersParticipated { get; set; }

        public string FilePath { get; set; } // Optional file path

        
        public int ClubID { get; set; } // Foreign key to Club

        public Club Club { get; set; }
    }
}