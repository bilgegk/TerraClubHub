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
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; }
        public decimal Budget { get; set; }
        public string File { get; set; } // Optional
        public decimal CostPerPerson { get; set; }
        public int NumberOfMembersParticipated { get; set; }
        public string Image { get; set; }
        public int ClubId { get; set; }
        public virtual Club Club { get; set; }
    }
}