using Microsoft.AspNetCore.Components;
using System.Net;
using System.Net.Http.Headers;

namespace HealthCareAdmin.Web.Services;

public class AuthMessageHandler : DelegatingHandler
{
    private readonly TokenProvider _tokenProvider;
    private readonly NavigationManager _navigationManager;
    private readonly IConfiguration _config;

    public AuthMessageHandler(
        TokenProvider tokenProvider,
        NavigationManager navigationManager,
        IConfiguration config)
    {
        _tokenProvider = tokenProvider;
        _navigationManager = navigationManager;
        _config = config;
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var token = await _tokenProvider.GetTokenAsync();

        if (!string.IsNullOrWhiteSpace(token))
        {
            request.Headers.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        }

        var response = await base.SendAsync(request, cancellationToken);

        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            await _tokenProvider.ClearTokenAsync();

            var loginUrl = _config["ApplicationUrls:LoginUrl"];

            _navigationManager.NavigateTo($"{loginUrl}?expired=true", forceLoad: true);
        }

        return response;
    }
}