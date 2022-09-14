using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OIG.Survey.Data.Database.Entities;

namespace OIG.Survey.Data.Database.EntityConfigs;

public class QuestionTypeEntityConfig : IEntityTypeConfiguration<QuestionType>
{
    public void Configure(EntityTypeBuilder<QuestionType> builder)
    {
    }
}