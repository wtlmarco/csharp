using System.Collections.Generic;

using CloudCustomers.API.Models;

namespace CloudCustomers.UnitTests.Fixtures;

internal static class UsersFixture
{
	internal static List<User> GetTestUsers() => new()
		{
			new User{
				Id = 1,
				Name = "Test User 1",
				Address = new Address
				{
					Street = "123 Market St",
					City = "Somewhere",
					ZipCode = "213124"
				},
				Email = "test.user.1@example.com"
			},
			new User{
				Id = 2,
				Name = "Test User 2",
				Address = new Address
				{
					Street = "900 Main St",
					City = "Somewhere",
					ZipCode = "213124"
				},
				Email = "test.user.2@example.com"
			},
			new User{
				Id = 3,
				Name = "Test User 3",
				Address = new Address
				{
					Street = "108 Maple St",
					City = "Somewhere",
					ZipCode = "213124"
				},
				Email = "test.user.3@example.com"
			}
		};
}
