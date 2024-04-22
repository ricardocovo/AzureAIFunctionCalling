using System.Text;
using System.Text.Json;

namespace AzureAIFuncitonCalling
{
    public class ApiWrapper
    {
        public static async Task<string> GetProjects(string baseUrl) {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{baseUrl}projects");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else { 
                    return $"Error: {response.StatusCode}";
                }
            }
        }

        public static async Task<string> AddHoursToProject(string baseUrl, string arguments) {
            using (var client = new HttpClient())
            {
                var parameters = JsonSerializer.Deserialize<AddHoursModel>(arguments);
                var data = new StringContent(arguments, Encoding.UTF8, "application/json");
                var url = $"{baseUrl}projects/{parameters.projectId}/hours";
                var response = await client.PostAsync(url, data);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    return $"Error: {response.StatusCode}";
                }
            }
        }
    }
}
