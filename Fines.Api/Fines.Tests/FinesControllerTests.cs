using System.Net;
using AutoFixture;
using Fines.Api;
using Fines.Core.Dtos;
using Fines.Core.Enums;
using Fines.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Moq.AutoMock;

namespace Fines.Tests;

public class FinesControllerTests
{
    private readonly AutoMocker _autoMocker = new();
    private readonly Fixture _fixture = new();

    private readonly FinesController _subject;

    public FinesControllerTests()
    {
        _subject = _autoMocker.CreateInstance<FinesController>();
    }
    
    [Fact]
    public async Task GivenFines_WhenGetFines_ThenReturns200OK()
    {
        // Given
        var fines = _fixture.CreateMany<FinesResponse>();

        _autoMocker.GetMock<IFinesService>()
            .Setup(s => s.GetFinesAsync())
            .ReturnsAsync(fines);

        // When
        var actionResult = await _subject.GetFines();
        var result = actionResult.Result as OkObjectResult;
        
        // Then
        result.StatusCode.Should().Be((int)HttpStatusCode.OK);
        result.Value.Should().BeEquivalentTo(fines);
    }

    [Fact]
    public async Task GivenServiceReturnsNull_WhenGetFines_ThenReturns200OK_EmptyList()
    {
        // Given
        _autoMocker.GetMock<IFinesService>()
            .Setup(s => s.GetFinesAsync())
            .ReturnsAsync((IEnumerable<FinesResponse>?)null);

        // When
        var actionResult = await _subject.GetFines();
        var result = actionResult.Result as OkObjectResult;

        // Then
        result.StatusCode.Should().Be((int)HttpStatusCode.OK);
        result.Value.Should().BeEquivalentTo(Enumerable.Empty<FinesResponse>());
    }
    
    [Fact]
    public async Task GivenServiceThrowsException_WhenGetFines_ThenReturns500InternalServerError()
    {
        // Given
        _autoMocker.GetMock<IFinesService>()
            .Setup(s => s.GetFinesAsync())
            .ThrowsAsync(new Exception("Fail to get fines"));

        // When
        var actionResult = await _subject.GetFines();
        var result = actionResult.Result as ObjectResult;

        // Then
        result.StatusCode.Should().Be((int)HttpStatusCode.InternalServerError);
    }
    
    [Fact]
    public async Task GivenFilteredFines_WhenGetFilteredFines_ThenReturns200OK()
    {
        // Given
        var filtered = _fixture.CreateMany<FinesResponse>();
        var fineType = _fixture.Create<FineType>();
        var fineDate = _fixture.Create<DateTime>();
        var reg = _fixture.Create<string>();

        _autoMocker.GetMock<IFinesService>()
            .Setup(s => s.GetFilteredFinesAsync(fineType, fineDate, reg))
            .ReturnsAsync(filtered);

        // When
        var actionResult = await _subject.GetFilteredFines(fineType, fineDate, reg);
        var result = actionResult.Result as OkObjectResult;

        // Then
        result.StatusCode.Should().Be((int)HttpStatusCode.OK);
        result.Value.Should().BeEquivalentTo(filtered);
    }
    
    [Fact]
    public async Task GivenServiceThrowsException_WhenGetFilteredFines_ThenReturns500InternalServerError()
    {
        // Given
        _autoMocker.GetMock<IFinesService>()
            .Setup(s => s.GetFilteredFinesAsync(It.IsAny<FineType?>(), It.IsAny<DateTime?>(), It.IsAny<string>()))
            .ThrowsAsync(new Exception("Fail to get filtered fines"));

        // When
        var actionResult = await _subject.GetFilteredFines(null, null, null);
        var result = actionResult.Result as ObjectResult;

        // Then
        result.StatusCode.Should().Be((int)HttpStatusCode.InternalServerError);
    }

}