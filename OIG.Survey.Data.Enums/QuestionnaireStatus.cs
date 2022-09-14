using System.ComponentModel;

namespace OIG.Survey.Data.Enums;

public enum QuestionnaireStatus
{
    [Description("Concept")]
    Concept = 1,
    
    [Description("Scheduled")]
    Scheduled = 2,
    
    [Description("Active")]
    Active = 3,
    
    [Description("Finished")]
    Finished = 4
}