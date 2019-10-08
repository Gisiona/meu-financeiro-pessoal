using OEconomicoPessoal.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OEconomicoPessoal.Infra.Maps
{
    public class AccountMap : EntityTypeConfiguration<Account>
    {
        public AccountMap()
        {
            ToTable("Accounts");

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

            Property(col => col.Email)
                .HasColumnName("Email")
                .HasColumnType("nvarchar")
                .HasMaxLength(200)
                .IsRequired();

            Property(col => col.IsAtivo)
                .HasColumnName("IsAtivo")
                .HasColumnType("bit")
                .IsRequired();

            Property(col => col.Senha)
               .HasColumnName("Senha")
               .HasColumnType("nvarchar")
               .HasMaxLength(20)
               .IsRequired();

            Property(col => col.ConfirmarSenha)
              .HasColumnName("ConfirmarSenha")
              .HasColumnType("nvarchar")
              .HasMaxLength(20)
              .IsRequired();

            Property(col => col.DataNascimento)
               .HasColumnName("DataNascimento")
               .HasColumnType("datetime")
               .IsRequired();

            Property(col => col.Telefone)
              .HasColumnName("Telefone")
              .HasMaxLength(20)
              .HasColumnType("nvarchar")
              .IsRequired();

            Property(col => col.RememberMe)
                .HasColumnName("LembrarSenha")
                .HasColumnType("bit")
                .IsRequired();

            Property(col => col.Nome)
              .HasColumnName("Nome")
              .HasColumnType("nvarchar")
              .HasMaxLength(200)
              .IsRequired();

            Property(col => col.Cpf)
               .HasColumnName("Cpf")
               .HasColumnType("nvarchar")
               .HasMaxLength(20)
               .IsRequired();

            //forengkey  
        }
    }
}