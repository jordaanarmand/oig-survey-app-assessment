using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OIG.Survey.Data.Database.Entities;

namespace OIG.Survey.Data.Database.EntityConfigs;

public class QuestionnaireStatusEntityConfig : IEntityTypeConfiguration<QuestionnaireStatus>
{
    public void Configure(EntityTypeBuilder<QuestionnaireStatus> builder)
    {
    }
}