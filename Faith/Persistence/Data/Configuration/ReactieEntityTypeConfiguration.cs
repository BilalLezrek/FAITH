using Domain.Posts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Data.Configuration
{
    internal class ReactieEntityTypeConfiguration : IEntityTypeConfiguration<Reactie>
    { 

        public void Configure(EntityTypeBuilder<Reactie> builder)
        {
            builder.Property(p => p.Tekst).IsRequired();
            builder.Property(p => p.Datum).IsRequired();
            builder.HasOne(p => p.Post);
            builder.HasOne(p => p.Gebruiker);
        }
    }
}
