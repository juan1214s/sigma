using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using technical_test_sigma.Application.Interfaces.Customer;
using technical_test_sigma.DTO.CrmDto;

public class HubSpotCrmService : ICrmService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;

    public HubSpotCrmService(HttpClient httpClient, IConfiguration config)
    {
        _httpClient = httpClient;
        _baseUrl = Environment.GetEnvironmentVariable("HUBSPOT_BASE_URL");

        var token = Environment.GetEnvironmentVariable("HUBSPOT_ACCESS_TOKEN");
        _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", token);
    }

    public async Task CreateOrUpdateCustomerAsync(CrmCustomerDto dto)
    {
        var payload = new
        {
            properties = new
            {
                email = dto.Email,
                firstname = dto.Name,
                total_paid = dto.TotalPaid
            }
        };

        var content = new StringContent(
            JsonSerializer.Serialize(payload),
            Encoding.UTF8,
            "application/json"
        );

        var response = await _httpClient.PostAsync(
            $"{_baseUrl}/crm/v3/objects/contacts",
            content
        );

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            throw new Exception($"HubSpot error: {error}");
        }
    }
}
