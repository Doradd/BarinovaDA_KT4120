using dariabarinovakt4120.Database.Helpers;
using dariabarinovakt4120.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dariabarinovakt4120.Database.Configurations
{
    public class DirectionConfiguration: IEntityTypeConfiguration<Direction>
    {
        private const string TableName = "direction";
        public void Configure(EntityTypeBuilder<Direction> builder)
        {
            //первичный ключ
            builder
                .HasKey(p => p.DirectionId)
                .HasName($"pk_{TableName}_direction_id");

            // автогенерация пк
            builder.Property(p => p.DirectionId)
                .ValueGeneratedOnAdd();

            // описываем колонки таблицы

            builder.Property(p => p.DirectionId)
                .HasColumnName("direction_id")
                .HasComment("ID направления");

            builder.Property(p => p.DirectionName)
                .IsRequired()
                .HasColumnName("direction_name")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Название направления");

        }
    }
}

