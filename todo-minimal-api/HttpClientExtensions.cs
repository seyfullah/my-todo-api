using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public static class HttpClientExtensions
{
    public static async Task<T?> GetFromApiAsync<T>(this HttpClient client, string url)
        => await client.GetFromJsonAsync<T>(url);

    public static async Task<HttpResponseMessage> PostToApiAsync<T>(this HttpClient client, string url, T data)
        => await client.PostAsJsonAsync(url, data);

    public static async Task<HttpResponseMessage> PutToApiAsync<T>(this HttpClient client, string url, T data)
        => await client.PutAsJsonAsync(url, data);

    public static async Task<HttpResponseMessage> DeleteFromApiAsync(this HttpClient client, string url)
        => await client.DeleteAsync(url);
}