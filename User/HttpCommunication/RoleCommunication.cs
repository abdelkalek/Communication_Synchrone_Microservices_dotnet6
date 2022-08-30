using Newtonsoft.Json;
using User.Model;
using User.Model.Dtos;

namespace User.Model
{
    public class RoleCommunication
    {
        public async  Task<List<RoleDto>> getListRole()
        {

            HttpClient _httpClient = new HttpClient();
            var obj = await _httpClient.GetAsync("https://localhost:7268/GetListRole");
            HttpResponseMessage response = _httpClient.GetAsync("https://localhost:7268/GetListRole").Result;
            response.EnsureSuccessStatusCode();
            string responseBody = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<List<RoleDto>>(responseBody);
        }
    }
}