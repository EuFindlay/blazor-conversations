using System;
using System.Net.Http;
using System.Text.Json;
using client.Models;
using client.Services;
using Microsoft.AspNetCore.Components;

namespace client.Pages
{
    public partial class Login : IDisposable
    {
        [Inject]
        protected HttpClient HttpClient {get;set;}
        [Inject]
        public StateContainerService StateContainerService { get; set; }

        public LoginModel model { get; set; } = new LoginModel();

        protected override void OnInitialized()
        {
            StateContainerService.OnChange += StateHasChanged;
        }

        public void Dispose()
        {
            StateContainerService.OnChange -= StateHasChanged;
        }

        async void HandleSubmit()
        {
            // Update state value
            this.StateContainerService.Property.Name = model.Name;
            this.StateContainerService.Property.LoggedIn = true;

            // Call API for Conversations Token
            var response = await HttpClient.GetAsync($"https://localhost:5003/token?identity={model.Name}");
            response.EnsureSuccessStatusCode();

            var json = JsonDocument.Parse(await response.Content.ReadAsStringAsync()); 
            this.StateContainerService.Property.Token = json.RootElement.GetProperty("token").GetString();
        }
    }
}