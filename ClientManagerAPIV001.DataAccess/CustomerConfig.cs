using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ClientManagerAPIV001.Models;
using System.Reflection.Emit;

namespace ClientManagerAPIV001.DataAccess
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> modelBuilder)
        {
            modelBuilder
                .Property(u => u.CustomerId)
                .ValueGeneratedOnAdd();

            modelBuilder
                .HasKey(u => u.CustomerId);

            modelBuilder
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder
                .HasIndex(u => u.CustomerCD)
                .IsUnique();
        }
    }

    public class CustomerNoteConfig : IEntityTypeConfiguration<CustomerNote>
    {
        public void Configure(EntityTypeBuilder<CustomerNote> modelBuilder)
        {

            modelBuilder
                .HasKey(x => new { x.CustomerID, x.ID });

            modelBuilder
                .Property(e => e.ID)
                .ValueGeneratedNever();
        }
    }

    public class CustomerFieldDefinitionConfig : IEntityTypeConfiguration<CustomerFieldDefinition>
    {
        public void Configure(EntityTypeBuilder<CustomerFieldDefinition> modelBuilder)
        {


            modelBuilder
                .HasKey(x => x.ID);

            modelBuilder
                .Property(e => e.ID)
                .ValueGeneratedOnAdd();
        }
    }

    public class CustomerFieldValueConfig : IEntityTypeConfiguration<CustomerFieldValue>
    {
        public void Configure(EntityTypeBuilder<CustomerFieldValue> modelBuilder)
        {
            modelBuilder
                .HasKey(x => new { x.CustomerID, x.ID });

            modelBuilder
                .Property(e => e.ID)
                .ValueGeneratedNever();
        }
    }
}



