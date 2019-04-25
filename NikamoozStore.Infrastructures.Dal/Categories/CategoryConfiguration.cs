using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NikamoozStore.Core.Domain.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace NikamoozStore.Infrastructures.Dal.Categories
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasIndex(c => c.CategoryName).IsUnique();
            builder.Property(c => c.CategoryName).HasMaxLength(100).IsRequired();
            builder.HasData(
                new Category { CategoryId = 1, CategoryName = "Category01" },
                new Category { CategoryId = 2, CategoryName = "Category02" },
                new Category { CategoryId = 3, CategoryName = "Category03" },
                new Category { CategoryId = 4, CategoryName = "Category04" });
        }
    }
}
