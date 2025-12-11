using AutoFixture;
using Fines.Core.Enums;
using Fines.Data;
using Fines.Data.Models;
using Fines.Services;
using FluentAssertions;
using Moq;
using Moq.AutoMock;
using Xunit;

namespace Fines.Tests;

public class FineFilteredServiceTests
{
    private readonly AutoMocker _autoMocker = new();
    private readonly Fixture _fixture = new();
    private readonly FinesService _service;

    public FineFilteredServiceTests()
    {
        _service = _autoMocker.CreateInstance<FinesService>();
    }
    
    [Fact]
    public async Task GivenValidFilters_WhenGetFilteredFinesAsync_ThenReturnsMappedFines()
    {
        // Given
        var finesEntities = _fixture.Build<FinesEntity>()
            .With(f => f.Vehicle, _fixture.Create<VehicleEntity>())
            .CreateMany(3)
            .ToList();

        var fineType = _fixture.Create<FineType>();
        var fineDate = _fixture.Create<DateTime>();
        var vehicleReg = _fixture.Create<string>();

        _autoMocker.GetMock<IFinesRepository>()
            .Setup(r => r.GetFilteredFinesAsync(fineType, fineDate, vehicleReg))
            .ReturnsAsync(finesEntities);

        // When
        var result = await _service.GetFilteredFinesAsync(fineType, fineDate, vehicleReg);

        // Then
        result.Should().HaveCount(finesEntities.Count);
        result.Select(r => r.Id).Should().BeEquivalentTo(finesEntities.Select(f => f.Id));
    }
    
    [Fact]
    public async Task GivenRepositoryThrows_WhenGetFilteredFinesAsync_ThenPropagatesException()
    {
        // Given
        _autoMocker.GetMock<IFinesRepository>()
            .Setup(r => r.GetFilteredFinesAsync(It.IsAny<FineType?>(), It.IsAny<DateTime?>(), It.IsAny<string>()))
            .ThrowsAsync(new Exception("Database error"));

        // When / Then
        await Assert.ThrowsAsync<Exception>(() => _service.GetFilteredFinesAsync(null, null, null));
    }
}
