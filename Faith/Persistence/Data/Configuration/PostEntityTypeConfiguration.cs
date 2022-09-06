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
    internal class PostEntityTypeConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(p => p.Onderwerp).IsRequired();
            builder.Property(p => p.Tekst).IsRequired();
            builder.Property(p => p.Datum).IsRequired();
            builder.Property(p => p.Archief).IsRequired();
            builder.Property(p => p.Url);
            builder.Property(p => p.Gebruiker);
            
        }
    }
}
