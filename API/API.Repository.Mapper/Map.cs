using API.Common.Entity.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Repository.Mapper
{
    public class Map<T> where T : Base
    {
        public Map(EntityTypeBuilder<T> builder)
        {
            builder
                .HasKey(k => k.Id);

            builder
                .Property(p => p.Id)
                .HasColumnName("ID")
                .HasColumnType("int");

            builder
                .Property(p => p.DataCriacao)
                .HasColumnName("DATA_CRIACAO")
                .HasColumnType("datetime");

            builder
                .Property(p => p.DataAlteracao)
                .HasColumnName("DATA_ALTERACAO")
                .HasColumnType("datetime");
        }
    }
}
