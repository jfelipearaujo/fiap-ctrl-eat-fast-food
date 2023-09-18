﻿using Domain.Models;

namespace Domain.Adapters
{
    public interface IProductCategoryRepository
    {
        Task<int> CreateAsync(ProductCategory productCategory, CancellationToken cancellationToken);

        Task<int> DeleteAsync(Guid id, CancellationToken cancellationToken);

        Task<IEnumerable<ProductCategory>> GetAllAsync(CancellationToken cancellationToken);

        Task<ProductCategory?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        Task<int> UpdateAsync(ProductCategory productCategory, CancellationToken cancellationToken);
    }
}