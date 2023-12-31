﻿using Domain.Entities.ProductAggregate;
using Domain.UseCases.ProductCategories.Common.Responses;

namespace Domain.UseCases.Products.Common.Responses;

public class ProductResponse
{
    public Guid Id { get; set; }

    public string Description { get; set; }

    public string Currency { get; set; }

    public decimal Amount { get; set; }

    public string ImageUrl { get; set; }

    public ProductCategoryResponse ProductCategory { get; set; }

    public DateTime CreatedAtUtc { get; set; }

    public DateTime UpdatedAtUtc { get; set; }

    // ---

    public static ProductResponse MapFromDomain(Product product)
    {
        return new ProductResponse
        {
            Id = product.Id.Value,
            Description = product.Description,
            Currency = product.Price.Currency,
            Amount = product.Price.Amount,
            ImageUrl = product.ImageUrl,
            ProductCategory = ProductCategoryResponse.MapFromDomain(product.ProductCategory),
            CreatedAtUtc = product.CreatedAtUtc,
            UpdatedAtUtc = product.UpdatedAtUtc
        };
    }
}
