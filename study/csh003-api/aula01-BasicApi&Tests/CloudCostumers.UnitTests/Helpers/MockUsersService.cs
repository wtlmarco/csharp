using Moq;

using CloudCustomers.API.Models;
using CloudCustomers.API.Services;
using System.Collections.Generic;


namespace CloudCustomers.UnitTests.Helpers;

internal static class MockUsersService
{
	internal static Mock<IUsersService> SetupGetAllUsers(List<User> response)
	{
		var mockService = new Mock<IUsersService>();

		mockService
			.Setup(s => s.GetAllUsers())
			.ReturnsAsync(response);

		return mockService;
	}
}
