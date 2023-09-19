﻿using Application.UseCases.ProductCategories;
using Application.UseCases.Products;

using Domain.UseCases.ProductCategories;
using Domain.UseCases.Products;

using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ApplicationDependency
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<ICreateProductCategoryUseCase, CreateProductCategoryUseCase>();
            services.AddTransient<IGetProductCategoryByIdUseCase, GetProductCategoryByIdUseCase>();
            services.AddTransient<IGetAllProductCategoriesUseCase, GetAllProductCategoriesUseCase>();
            services.AddTransient<IUpdateProductCategoryUseCase, UpdateProductCategoryUseCase>();
            services.AddTransient<IDeleteProductCategoryUseCase, DeleteProductCategoryUseCase>();

            services.AddTransient<ICreateProductUseCase, CreateProductUseCase>();
            services.AddTransient<IGetProductByIdUseCase, GetProductByIdUseCase>();
            services.AddTransient<IGetAllProductsUseCase, GetAllProductsUseCase>();
            services.AddTransient<IUpdateProductUseCase, UpdateProductUseCase>();
            services.AddTransient<IDeleteProductUseCase, DeleteProductUseCase>();

            return services;
        }
    }
}