using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OIG_Survey_App.Models;

public class CreateQuestionnaireModel
{
    [Required]
    [DataType(DataType.Text)]
    public string Name { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime StartDate { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime EndDate { get; set; }
    
    public CreateQuestionnaireModel()
    {
        this.StartDate = DateTime.Now;
        this.EndDate = DateTime.Now.AddDays(2);
    }
}