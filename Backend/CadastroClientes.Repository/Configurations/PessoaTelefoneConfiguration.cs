using CadastroClientes.Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroClientes.Repository.Configurations
{
    public class PessoaTelefoneConfiguration : IEntityTypeConfiguration<PessoaTelefone>
    {
        public void Configure(EntityTypeBuilder<PessoaTelefone> builder)
        {
            builder.ToTable("PessoaTelefones");

            builder.HasKey("Id");

            builder.HasOne(x => x.Pessoa)
                   .WithMany(x => x.Telefones)
                   .HasForeignKey(x => x.PessoaId);
        }
    }
}
