using dariabarinovakt4120.Database.Helpers;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using dariabarinovakt4120.Models;

namespace dariabarinovakt4120.Database.Configurations
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        private const string TableName = "subject";
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            //первичный ключ
            builder
                .HasKey(p => p.SubjectId)
                .HasName($"pk_{TableName}_subject_id");

            // автогенерация пк
            builder.Property(p => p.SubjectId)
                .ValueGeneratedOnAdd();

            // описываем колонки таблицы

            builder.Property(p => p.SubjectId)
                .HasColumnName("subject_id")
                .HasComment("ID предмета");

            builder.Property(p => p.SubjectName)
                .IsRequired()
                .HasColumnName("sudject_name")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Название предмета");

            builder.Property(p => p.DirectionId)
                .IsRequired()
                .HasColumnName("direction_id")
                .HasColumnType(ColumnType.Int)
                .HasComment("ID направления");

            builder.Property(p => p.IsDeleted)
                .IsRequired()
                .HasColumnName("is_deleted")
                .HasColumnType(ColumnType.Bool)
                .HasComment("Статус удаления");

            // описываем связи

            builder.ToTable(TableName)
                .HasOne(p => p.Direction)
                .WithMany()
                .HasForeignKey(p => p.DirectionId)
                .HasConstraintName("fk_f_direction_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName)
                .HasIndex(p => p.DirectionId, $"idx_{TableName}_fk_f_direction_id");


            builder.Navigation(p => p.Direction)
                .AutoInclude();
        }

    }
}
