using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OIG.Survey.Data.Database.Entities;

namespace OIG.Survey.Data.Database.EntityConfigs;

public class AnswersEntityConfig : IEntityTypeConfiguration<Answers>
{
    public void Configure(EntityTypeBuilder<Answers> builder)
    {
    }
}