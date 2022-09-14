using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OIG.Survey.Data.Database.Entities;

namespace OIG.Survey.Data.Database.EntityConfigs;

public class QuestionnaireEntityConfig : IEntityTypeConfiguration<Questionnaire>
{
    public void Configure(EntityTypeBuilder<Questionnaire> builder)
    {
    }
}