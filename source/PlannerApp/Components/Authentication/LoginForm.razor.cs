﻿using System;
using System.Net.Http.Json;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using PlannerApp.Shared.Models;
using PlannerApp.Shared.Responses;

namespace PlannerApp.Components
{
	public partial class LoginForm : ComponentBase
	{
		[Inject]
		public HttpClient HttpClient { get; set; }

		[Inject]
		public NavigationManager Navigation { get; set; }

		[Inject]
		public AuthenticationStateProvider AuthenticationStateProvider { get; set; }

		[Inject]
		public ILocalStorageService storage { get; set; }

		private LoginRequest _model = new LoginRequest();
		private bool _isBusy = false;
		private string _errorMessage = string.Empty;

		private async Task LoginUserAsnyc()
		{
			_isBusy = true;
			_errorMessage = string.Empty;

			var response = await HttpClient.PostAsJsonAsync("/api/v2/auth/login", _model);
			if (response.IsSuccessStatusCode)
			{
				var result = await response.Content.ReadFromJsonAsync<APIResponse<LoginResult>>();
				//Store the token in local storage.
				await storage.SetItemAsStringAsync("access_token", result.Value.Token);
				await storage.SetItemAsync<DateTime>("expiry_date", result.Value.ExpieryDate);

				await AuthenticationStateProvider.GetAuthenticationStateAsync();

				Navigation.NavigateTo("/");

			}
			else
			{
				var errorResult = await response.Content.ReadFromJsonAsync<APIErrorResponse>();
			}

			_isBusy = false;
		}
	}
}

