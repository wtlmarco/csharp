using Xunit;
using Moq;
using Moq.Protected;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

using CloudCustomers.API.Services;
using CloudCustomers.API.Models;
using CloudCustomers.API.Config;
using CloudCustomers.UnitTests.Helpers;
using CloudCustomers.UnitTests.Fixtures;

namespace CloudCustomers.UnitTests.Systems.Services;

public class TestUserServices
{
	[Fact]
	public async Task GetAllUsers_WhenCalled_InvokeHttpGetRequest()
	{
		//Arrange
		var expectedResponse = UsersFixture.GetTestUsers();
		
		var handlerMock = MockHttpMessageHandler<User>.SetupBasicResourceList(expectedResponse);
		var httpClient = new HttpClient(handlerMock.Object);
		
		var endpoint = "https://example.com";
		var config = Options.Create(new UsersApiOptions
		{
			Endpoint = endpoint
		});

		var sut = new UsersService(httpClient, config);

		//Act
		await sut.GetAllUsers();

		//Assert
		handlerMock.Protected().Verify("SendAsync",
			Times.Exactly(1),
			ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get),
			ItExpr.IsAny<CancellationToken>()
		);
	}

	[Fact]
	public async Task GetAllUsers_WhenCalled_ReturnListOfUsers()
	{
		//Arrange
		var expectedResponse = UsersFixture.GetTestUsers();
		
		var handlerMock = MockHttpMessageHandler<User>.SetupBasicResourceList(expectedResponse);
		var httpClient = new HttpClient(handlerMock.Object);

		var endpoint = "https://example.com";
		var config = Options.Create(new UsersApiOptions
		{
			Endpoint = endpoint
		});

		var sut = new UsersService(httpClient, config);

		//Act
		var result = await sut.GetAllUsers();

		//Assert
		result.Should().BeOfType<List<User>>();
	}

	[Fact]
	public async Task GetAllUsers_WhenHits404_ReturnEmptyListOfUsers()
	{
		//Arrange
		var handlerMock = MockHttpMessageHandler<User>.SetupReturn404();
		var httpClient = new HttpClient(handlerMock.Object);

		var endpoint = "https://example.com";
		var config = Options.Create(new UsersApiOptions
		{
			Endpoint = endpoint
		});

		var sut = new UsersService(httpClient, config);

		//Act
		var result = await sut.GetAllUsers();

		//Assert
		result.Count.Should().Be(0);
	}

	[Fact]
	public async Task GetAllUsers_WhenCalled_ReturnListOfUsersOfExpectedSize()
	{
		//Arrange
		var expectedResponse = UsersFixture.GetTestUsers();
		var handlerMock = MockHttpMessageHandler<User>.SetupBasicResourceList(expectedResponse);
		var httpClient = new HttpClient(handlerMock.Object);

		var endpoint = "https://example.com";
		var config = Options.Create(new UsersApiOptions
		{
			Endpoint = endpoint
		});

		var sut = new UsersService(httpClient, config);

		//Act
		var result = await sut.GetAllUsers();

		//Assert
		result.Count.Should().Be(expectedResponse.Count);
	}

	[Fact]
	public async Task GetAllUsers_WhenCalled_InvokesConfiguredExternalUrl()
	{
		//Arrange
		var endpoint = "https://example.com/users";

		var expectedResponse = UsersFixture.GetTestUsers();
		var handlerMock = MockHttpMessageHandler<User>
			.SetupBasicResourceList(expectedResponse);
		
		var httpClient = new HttpClient(handlerMock.Object);
		
		var config = Options.Create(new UsersApiOptions
		{
			Endpoint = endpoint
		});

		var sut = new UsersService(httpClient, config);

		//Act
		var result = await sut.GetAllUsers();

		var uri = new Uri(endpoint);

		//Assert
		handlerMock
			.Protected()
			.Verify("SendAsync",
			Times.Exactly(1),
			ItExpr.Is<HttpRequestMessage>(req => 
				req.Method == HttpMethod.Get && 
				req.RequestUri == uri
				),
			ItExpr.IsAny<CancellationToken>()
		);
	}
}