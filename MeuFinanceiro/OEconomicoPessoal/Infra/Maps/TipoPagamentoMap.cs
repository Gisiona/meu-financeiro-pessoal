using OEconomicoPessoal.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OEconomicoPessoal.Infra.Maps
{
    public class TipoPagamentoMap : EntityTypeConfiguration<TipoPagamento>
    {
        public TipoPagamentoMap()
        {
            ToTable("TipoPagamentos");

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

            Property(col => col.AccountId)
                .HasColumnName("AccountId")
                .HasColumnType("int")
                .IsRequired();

            ////forengkey
            //HasOptional(s => s.Accounts)
            //    .WithMany(v => v.TipoPagamentos)
            //    .HasForeignKey(s => s.AccountId);  
        }

    }
}