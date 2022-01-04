using BlogAspnetCursombanagouro.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace BlogAspnetCursombanagouro.Data.Mapping
{
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            ToTable("Categories");
            HasKey(x => x.Id);

            Property(x => x.Name)
                .HasMaxLength(80)
                .IsVariableLength()
                .IsRequired();

            Property(x => x.Permalink)
                .HasMaxLength(80)
                .IsVariableLength()
                .IsRequired()
                .HasColumnAnnotation(
                    "Index",
                    new IndexAnnotation(new IndexAttribute("IX_dbo.Categories.Permalink") { IsUnique = true })
                 );

            HasMany(x => x.Posts)
                .WithOptional(x => x.Category);
        }
    }
}