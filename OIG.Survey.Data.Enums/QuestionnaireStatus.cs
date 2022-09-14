using System.ComponentModel;

namespace OIG.Survey.Data.Enums;

public enum QuestionnaireStatus
{
    [Description("Concept")]
    Concept = 0,
    
    [Description("Scheduled")]
    Scheduled = 1,
    
    [Description("Active")]
    Active = 2,
    
    [Description("Finished")]
    Finished = 3
}