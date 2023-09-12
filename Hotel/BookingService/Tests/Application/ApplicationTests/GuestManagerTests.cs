using Application.Base;
using Application.Guest.Requests;
using Application.UseCases.Guest;
using ApplicationTests.Request;
using Bogus;
using FluentAssertions;
using Tests.Mapper;
using Tests.Repositories;

namespace ApplicationTests;

public class GuestManagerTests
{
    [Fact]
    public async Task Should_Create_Successfully()
    {
        var guestDto = GuestRequestBuilder.Build();

        var request = new GuestRequest()
        {
            Data = guestDto
        };

        var useCase = CreateUseCase(request);

        var response = await useCase.Create(request);

        response.Should().NotBeNull();
        response.Success.Should().BeTrue();
        response.Data.Should().NotBeNull();
    }

    [Theory]
    [InlineData("")]
    [InlineData("ab")]
    public async Task Should_Return_Invalid_Person_Docs(string docNumber)
    {
        var guestDto = GuestRequestBuilder.Build();
        guestDto.IdNumber = docNumber;

        var request = new GuestRequest()
        {
            Data = guestDto
        };

        var useCase = CreateUseCase(request);

        var action = async () =>
        {
            await useCase.Create(request);
        };

        await action.Should().ThrowAsync<FluentValidation.ValidationException>()
            .Where(ex => ex.Message.Equals("IdNumber must be at least 3 characters"));
    }

    [Theory]
    [InlineData("")]
    public async Task Should_Return_Invalid_Person_Email(string email)
    {
        var guestDto = GuestRequestBuilder.Build();
        guestDto.Email = email;

        var request = new GuestRequest()
        {
            Data = guestDto
        };

        var useCase = CreateUseCase(request);

        var action = async () =>
        {
            await useCase.Create(request);
        };

        await action.Should().ThrowAsync<FluentValidation.ValidationException>()
            .Where(ex => ex.Message.Equals("Insert a valid email"));
    }

    [Theory]
    [InlineData("nm", "sm")]
    [InlineData("nm", "sm")]
    public async Task Should_Return_Invalid_Person_Name_And_Surname(string name, string surname)
    {
        var guestDto = GuestRequestBuilder.Build();
        guestDto.Name = name;
        guestDto.Surname = surname;

        var request = new GuestRequest()
        {
            Data = guestDto
        };

        var useCase = CreateUseCase(request);

        var action = async () =>
        {
            await useCase.Create(request);
        };

        await action.Should().ThrowAsync<FluentValidation.ValidationException>()
            .Where(ex => ex.Message.Equals("Name must be at least 3 characters"));
    }

    private static GuestManager CreateUseCase(GuestRequest guest)
    {
        var mapper = MapperBuilder.Instance();
        var repository = GuestRepositoryBuilder.Instance().Build();

        return new GuestManager(repository, mapper);
    }
}