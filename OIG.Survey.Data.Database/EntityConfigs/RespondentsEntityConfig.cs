using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OIG.Survey.Data.Database.Entities;

namespace OIG.Survey.Data.Database.EntityConfigs;

public class RespondentsEntityConfig : IEntityTypeConfiguration<Respondent>
{
    public void Configure(EntityTypeBuilder<Respondent> builder)
    {
    }
}