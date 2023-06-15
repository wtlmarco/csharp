using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

using CloudCustomers.API.Models;
using CloudCustomers.API.Config;

namespace CloudCustomers.API.Services;

public interface IUsersService
{
	public Task<List<User>> GetAllUsers();
}

public class UsersService : IUsersService
{
	private readonly UsersApiOptions _apiConfig;
	private readonly HttpClient _httpClient;
	public UsersService(HttpClient httpClient, IOptions<UsersApiOptions> apiConfig)
	{
		_apiConfig = apiConfig.Value;
		_httpClient = httpClient;
	}

	public async Task<List<User>> GetAllUsers()
	{
		var usersResponse = await _httpClient.GetAsync(_apiConfig.Endpoint);
		if(usersResponse.StatusCode == HttpStatusCode.NotFound)
		{
			return new List<User>();
		}

		var responseContent = usersResponse.Content;
		var allUsers = await responseContent.ReadFromJsonAsync<List<User>>();

		return allUsers.ToList();
	}
}