using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using static System.Environment;

namespace ConsoleAPP;

/// <summary>
/// HttpClient Study
/// https://zetcode.com/csharp/httpclient/
/// </summary>
internal class Person
{
	public int Id { get; set; }
	public string Name { get; set; }
	public int Age { get; set; }
}
internal static class Lab
{
	internal static async Task<string> GetDirectly(string url)
	{
		string result;

		Uri uri = new Uri(url);

		using (var client = new HttpClient())
		{
			result = await client.GetStringAsync(uri).ConfigureAwait(false);
		}

		return result;
	}

	internal static async Task<string> GetUsingExplicitRequest(string url)
	{
		string result;

		//var uri = new Uri(url);
		var uri = new UriBuilder(url);
		uri.Query = "name=John Doe&occupation=gardener";

		using (var client = new HttpClient())
		using (var request = new HttpRequestMessage(HttpMethod.Get, uri.Uri))
		using (var response = await client.SendAsync(request).ConfigureAwait(false))
		{
			request.Headers.Add("User-Agent", "C# Program");

			result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
		}

		return result;
	}

	internal static async Task<string> GetUsingExplicitResponse(string url)
	{
		string result;

		Uri uri = new Uri(url);

		using (var client = new HttpClient())
		using (HttpResponseMessage response = await client.GetAsync(uri).ConfigureAwait(false))
		using (HttpContent content = response.Content)
		{
			if (response.IsSuccessStatusCode)
				result = await content.ReadAsStringAsync().ConfigureAwait(false);
			else
				result = string.Empty;
		}

		return result;
	}

	internal static async Task<string> GetByPath<T>(string url, string path)
	{
		StringBuilder result = new StringBuilder();

		using (var client = new HttpClient())
		{
			client.BaseAddress = new Uri(url);
			client.DefaultRequestHeaders.Add("User-Agent", "C# console program");
			client.DefaultRequestHeaders.Accept.Add(
				new MediaTypeWithQualityHeaderValue("application/json"));
			
#pragma warning disable CA2234 // Pass system uri objects instead of strings
			HttpResponseMessage response = await client.GetAsync(path).ConfigureAwait(false);
#pragma warning restore CA2234 // Pass system uri objects instead of strings
			response.EnsureSuccessStatusCode();
			var resp = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

			var data = JsonConvert.DeserializeObject<List<T>>(resp);
			data.ForEach(delegate(T d) {
				result.Append(d.ToString());
			});
		}

		return result.ToString();
	}
	internal static async Task<string> GetByProxy(string url, string proxy, int port)
	{
		string result;

		using (var handler = new HttpClientHandler()
		{
			Proxy = new WebProxy(new Uri($"socks5://{proxy}:{port}")),
			UseProxy = true
		})
		using (var client = new HttpClient(handler))
		{
			var res = await client.GetAsync(new Uri(url)).ConfigureAwait(false);
			result = await res.Content.ReadAsStringAsync().ConfigureAwait(false);
		}

		return result;
	}

	internal static async Task<string> GetFile(string url)
	{
		using var client = new HttpClient();

		var uri = new Uri(url);
		string fileName = Path.GetFileName(uri.LocalPath);

		byte[] imageBytes = await client.GetByteArrayAsync(new Uri(url)).ConfigureAwait(false);

		string documentsPath = GetFolderPath(SpecialFolder.Personal);
		string localPath = Path.Combine(documentsPath, fileName);

		await File.WriteAllBytesAsync(localPath, imageBytes).ConfigureAwait(false);

		return localPath;
	}

	internal static async Task<string> GetStream(string url)
	{
		using var client = new HttpClient();

		var uri = new Uri(url);
		string fileName = Path.GetFileName(uri.LocalPath);
		
		string documentsPath = GetFolderPath(SpecialFolder.Personal);
		string localPath = Path.Combine(documentsPath, fileName);

		var resp = await client.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
		resp.EnsureSuccessStatusCode();

		using Stream ms = await resp.Content.ReadAsStreamAsync().ConfigureAwait(false);

		using FileStream fs = File.Create(localPath);
		await ms.CopyToAsync(fs).ConfigureAwait(false);

		return localPath;
	}

	internal static async Task<string> GetWithAuthorization(string url, string user, string pass)
	{
		string result;

		var uri = new Uri(url);

		using var client = new HttpClient();

		var authToken = Encoding.ASCII.GetBytes($"{user}:{pass}");
		client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authToken));

		var resp = await client.GetAsync(uri).ConfigureAwait(false);

		result = await resp.Content.ReadAsStringAsync().ConfigureAwait(false);

		return result;
	}

	internal static async Task<string> PostByData<T>(string url, T data)
	{
		string result;

		var json = JsonConvert.SerializeObject(data);

		using (var client = new HttpClient())
		using (var content = new StringContent(json, Encoding.UTF8, "application/json"))
		{
			var response = await client.PostAsync(new Uri(url), content).ConfigureAwait(false);

			result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
		}

		return result;
	}

	internal static async Task<string> PostByForm(string url, Dictionary<string,string> data)
	{
		string result;

		using (var client = new HttpClient())
		using (var content = new FormUrlEncodedContent(data))
		{
			var res = await client.PostAsync(new Uri(url), content).ConfigureAwait(false);

			result = await res.Content.ReadAsStringAsync().ConfigureAwait(false);
		}

		return result;
	}
}
