using System;
using System.ComponentModel.DataAnnotations;

public class Member
{
    [Key]
    public int ID { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Surname { get; set; }
    [Required]
    public string Department { get; set; }
    public string Title { get; set; }
}