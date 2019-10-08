using OEconomicoPessoal.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OEconomicoPessoal.Infra.Maps
{
    public class ContaMap : EntityTypeConfiguration<Conta>
    {
        public ContaMap()
        {
            ToTable("Contas");

            HasKey(c => c.Id);

            Property(col => col.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(col => col.DataCadastro)
                .HasColumnName("DataCadastro")
                .HasColumnType("datetime")
                .IsRequired();

            Property(col => col.Descricao)
                .HasColumnName("Descricao")
                .HasColumnType("nvarchar")
                .HasMaxLength(200)
                .IsRequired();

            Property(col => col.IsAtivo)
                .HasColumnName("IsAtivo")
                .HasColumnType("bit")
                .IsRequired();

            Property(col => col.Valor)
                .HasColumnName("Valor")
                .HasColumnType("decimal")
                .HasPrecision(18, 2)
                .IsRequired();

            //Property(col => col.Accounts.Id)
            //    .HasColumnName("AccountId")
            //    .IsRequired()
            //    .HasColumnType("int");

            //HasOptional(s => s.Accounts)
            //    .WithMany(v => v.Contas)
            //    .HasForeignKey(s => s.AccountId);

        }
    }
}