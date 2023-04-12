#nullable disable
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InstituteWebApp.Data.Models;

public class StudentsModels
{
    public Guid Id { get; set; }
    [Required]
    [DisplayName("Name")]
    public string Name { get; set; }
    [Required]
    public int Age { get; set; }
    [Required]
    public string ClassRoom { get; set; }
    [Required]
    public int Grades { get; set; }
    
    
}