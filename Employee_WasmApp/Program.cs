using Blazored.LocalStorage;
using Shared_Library.Authentication;
using Employee_WasmApp;
using Shared_Library.Service;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Shared_Library.Service.Auth;
using Shared_Library;


//using Shared_Library.Service;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var apiUrl = builder.Configuration.GetValue<String>("ApiSettings:Url");
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiUrl) });

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();

builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddScoped<IUserAccount, AccountService>();
builder.Services.AddScoped<AccountService, AccountService>();

await builder.Build().RunAsync();
