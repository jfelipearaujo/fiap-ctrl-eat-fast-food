﻿using Application.UseCases.ProductCategories;

using Domain.Adapters;
using Domain.Entities;
using Domain.Errors.ProductCategories;
using Domain.UseCases.ProductCategories.Requests;
using Domain.UseCases.ProductCategories.Responses;

namespace Application.Tests.UseCases.ProductCategories
{
    public class UpdateProductCategoryUseCaseTests
    {
        private readonly UpdateProductCategoryUseCase sut;

        private readonly IProductCategoryRepository repository;

        public UpdateProductCategoryUseCaseTests()
        {
            repository = Substitute.For<IProductCategoryRepository>();

            sut = new UpdateProductCategoryUseCase(repository);
        }

        [Fact]
        public async Task ShouldUpdateProductCategorySuccessfully()
        {
            // Arrange
            var request = new UpdateProductCategoryRequest
            {
                Id = Guid.NewGuid(),
                Description = "New Product Description"
            };

            repository
                .GetByIdAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>())
                .Returns(new ProductCategory
                {
                    Id = request.Id,
                    Description = "Old Product Description"
                });

            // Act
            var response = await sut.ExecuteAsync(request, cancellationToken: default);

            // Assert
            response.Should().BeSuccess().And.Satisfy(result =>
            {
                result.Value.Should().BeEquivalentTo(new ProductCategoryResponse
                {
                    Id = request.Id,
                    Description = request.Description
                });
            });

            await repository
                .Received(1)
                .UpdateAsync(
                    Arg.Is<ProductCategory>(x => x.Description == request.Description),
                    Arg.Any<CancellationToken>());
        }

        [Fact]
        public async Task ShouldHandleWhenNothingWasFound()
        {
            // Arrange
            var request = new UpdateProductCategoryRequest
            {
                Id = Guid.NewGuid(),
                Description = "New Product Description"
            };

            repository
                .GetByIdAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>())
                .Returns(default(ProductCategory));

            // Act
            var response = await sut.ExecuteAsync(request, cancellationToken: default);

            // Assert
            response.Should().BeFailure().And.HaveReason(new ProductCategoryNotFoundError(request.Id));

            await repository
                .DidNotReceive()
                .UpdateAsync(
                    Arg.Any<ProductCategory>(),
                    Arg.Any<CancellationToken>());
        }
    }
}