﻿using Application.UseCases.ProductCategories;

using Domain.Adapters;
using Domain.Entities;
using Domain.UseCases.ProductCategories.Requests;
using Domain.UseCases.ProductCategories.Responses;

namespace Application.Tests.UseCases.ProductCategories
{
    public class CreateProductCategoryUseCaseTests
    {
        private readonly CreateProductCategoryUseCase sut;

        private readonly IProductCategoryRepository repository;

        public CreateProductCategoryUseCaseTests()
        {
            repository = Substitute.For<IProductCategoryRepository>();

            sut = new CreateProductCategoryUseCase(repository);
        }

        [Fact]
        public async Task ShouldCreateProductCategorySuccessfully()
        {
            // Arrange
            var request = new CreateProductCategoryRequest
            {
                Description = "Product Category Description",
            };

            var expectedResponse = new ProductCategoryResponse
            {
                Description = "Product Category Description",
            };

            // Act
            var response = await sut.ExecuteAsync(request, cancellationToken: default);

            // Assert
            response.Should().BeSuccess().And.Satisfy(result =>
            {
                result.Value.Should().BeEquivalentTo(expectedResponse, opt => opt.Excluding(x => x.Id));
                result.Value.Id.Should().NotBeEmpty();
            });

            await repository
                .Received(1)
                .CreateAsync(
                    Arg.Any<ProductCategory>(),
                    Arg.Any<CancellationToken>());
        }
    }
}