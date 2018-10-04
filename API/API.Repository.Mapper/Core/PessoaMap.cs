using API.Common.Entity.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Repository.Mapper.Core
{
    public class PessoaMap : Mapper.Map<Pessoa>
    {
        public PessoaMap(EntityTypeBuilder<Pessoa> builder) : base(builder)
        {
            builder
                   .ToTable("PESSOA");

            builder.Property(p => p.Id)
                .HasColumnName("ID_TIPO_PESSOA")
                .HasColumnType("INT");

            builder.Property(p => p.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(128);
        }
    }
}
