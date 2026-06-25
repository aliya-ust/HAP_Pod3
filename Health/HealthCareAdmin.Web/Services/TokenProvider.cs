using Microsoft.JSInterop;

public class TokenProvider
{
    private readonly IJSRuntime _js;

    public TokenProvider(IJSRuntime js)
    {
        _js = js;
    }

    public async Task<string?> GetTokenAsync()
    {
        return await _js.InvokeAsync<string>("localStorage.getItem", "accesstoken");
    }
}