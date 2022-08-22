using Domain.Gebruikers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Data.Configuration
{
    internal class BegeleiderEntityTypeConfiguration : IEntityTypeConfiguration<Begeleider>
    {
        public void Configure(EntityTypeBuilder<Begeleider> builder)
        {
            builder.Property(p => p.Achternaam).IsRequired();
            builder.Property(p => p.Voornaam).IsRequired();
            builder.Property(p => p.Geboortedatum);
            builder.Property(p => p.Geslacht).IsRequired();
        }
    }
}
