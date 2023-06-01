using Xunit;
using Moq;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using CloudCustomers.API.Controllers;
using CloudCustomers.API.Services;
using CloudCustomers.API.Models;
using System.Threading.Tasks;
using CloudCustomers.UnitTests.Fixtures;
using CloudCustomers.UnitTests.Helpers;

namespace CloudCostumers.UnitTests.Systems.Controllers;

public class TestUsersControllers
{
	[Fact]
	public async void Get_OnSuccess_ReturnsStatusCode200()
	{
		//Arrange
		var mockUsersService = MockUsersService.SetupGetAllUsers(UsersFixture.GetTestUsers());

		var sut = new UsersController(mockUsersService.Object);

		//Act
		var result = (OkObjectResult) await sut.Get();

		//Assert
		result.StatusCode.Should().Be(200);
	}

	[Fact]
	public async void Get_OnSuccess_InvokesUserServiceExactlyOnce()
	{
		//Arrange
		var mockUsersService = MockUsersService.SetupGetAllUsers(new List<User>());

		var sut = new UsersController(mockUsersService.Object);

		//Act
		var result = await sut.Get();

		//Assert
		mockUsersService.Verify(s => s.GetAllUsers(), Times.Once());
	}

	[Fact]
	public async Task Get_OnSuccess_ReturnsListOfUsers()
	{
		//Arrange
		var mockUsersService = MockUsersService.SetupGetAllUsers(UsersFixture.GetTestUsers());

		var sut = new UsersController(mockUsersService.Object);

		//Act
		var result = await sut.Get();

		//Assert
		result.Should().BeOfType<OkObjectResult>();
		var objectResult = (OkObjectResult)result;
		objectResult.Value.Should().BeOfType<List<User>>()
;	}

	[Fact]
	public async Task Get_OnNonUsersFound_Returns404()
	{
		//Arrange
		var mockUsersService = MockUsersService.SetupGetAllUsers(new List<User>());

		var sut = new UsersController(mockUsersService.Object);

		//Act
		var result = await sut.Get();

		//Assert
		result.Should().BeOfType<NotFoundResult>();
		var objectResult = (NotFoundResult)result;
		objectResult.StatusCode.Should().Be(404);
;
	}
}
