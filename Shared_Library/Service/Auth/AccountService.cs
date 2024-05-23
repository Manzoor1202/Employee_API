using Blazored.LocalStorage;
using Shared_Library.GenericsModel;
using Shared_Library.Model;
using Shared_Library.Service.Auth;
using static Shared_Library.Model.ServiceResponses;
using System.Net.Http;

namespace Shared_Library.Service.Auth
{
    public class AccountService : IUserAccount
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorageService;

        public AccountService(HttpClient httpClient, ILocalStorageService localStorageService)
        {
            _httpClient = httpClient;
            _localStorageService = localStorageService;
        }

        private const string BaseUrl = "api/Account";

        public async Task<GeneralResponse> CreateAccount(UserDTO userDTO)
        {
            var response = await _httpClient
                 .PostAsync($"{BaseUrl}/register",
                 Generics.GenerateStringContent(
                 Generics.SerializeObj(userDTO)));

            //Read Response
            if (!response.IsSuccessStatusCode)
                return new GeneralResponse(false, "Error occured. Try again later...");

            var apiResponse = await response.Content.ReadAsStringAsync();
            return Generics.DeserializeJsonString<GeneralResponse>(apiResponse);
        }


        public async Task<LoginResponse> LoginAccount(LoginDTO loginDTO)
        {
            var response = await _httpClient
               .PostAsync($"{BaseUrl}/login",
               Generics.GenerateStringContent(
               Generics.SerializeObj(loginDTO)));

            //Read Response
            if (!response.IsSuccessStatusCode)
                return new LoginResponse(false, null!, "Error occured. Try again later...");

            var apiResponse = await response.Content.ReadAsStringAsync();
            return Generics.DeserializeJsonString<LoginResponse>(apiResponse);

        }
    }
}
