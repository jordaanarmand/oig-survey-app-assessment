using System.ComponentModel.DataAnnotations;

namespace OIG_Survey_App.Models;

public class EditQuestionnaireModel
{
    public long Id { get; set; }
    
    [Required]
    [DataType(DataType.Text)]
    public string Name { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime StartDate { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime EndDate { get; set; }

    public long StatusId { get; set; }
}