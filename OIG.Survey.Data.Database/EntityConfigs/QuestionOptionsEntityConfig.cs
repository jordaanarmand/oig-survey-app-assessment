using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OIG.Survey.Data.Database.Entities;

namespace OIG.Survey.Data.Database.EntityConfigs;

public class QuestionOptionsEntityConfig : IEntityTypeConfiguration<QuestionOption>
{
    public void Configure(EntityTypeBuilder<QuestionOption> builder)
    {
    }
}