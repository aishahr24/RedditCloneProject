using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Core.Model;

namespace RedditCloneProject.Data;

public class ApiService
{
    private readonly HttpClient _httpClient;

    public ApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ThreadPost>?> GetThreadsPostAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<ThreadPost>>("api/Threads");
    }

    public async Task<bool> CreateThread(ThreadPost newThread)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Threads", newThread);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> LoginAsync(string username, string password)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Users/login", new { username, password });
        return response.IsSuccessStatusCode;
    }
}