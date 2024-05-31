using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Club
{
    [Key]
    public int ID { get; set; }
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public string Banner { get; set; }
    public bool Status { get; set; } // Active or not
    public virtual ICollection<ClubActivity> Activities { get; set; }
}