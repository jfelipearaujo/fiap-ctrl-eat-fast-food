﻿using Domain.Entities;
using Domain.Entities.TypedIds;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class ProductCategoryEntityTypeConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable("product_category");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasConversion(
                productCategoryId => productCategoryId.Value,
                value => new ProductCategoryId(value));

            builder
                .Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(250);

            builder
                .Property(x => x.CreatedAtUtc)
                .IsRequired()
                .HasPrecision(7);

            builder
                .Property(x => x.UpdatedAtUtc)
                .IsRequired()
                .HasPrecision(7);
        }
    }
}