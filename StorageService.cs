using Microsoft.JSInterop;

namespace CharacterSheet
{
    public class StorageService
    {
        private readonly IJSRuntime _js;
        public StorageService(IJSRuntime jsr)
        {
            _js = jsr;
        }
        public async ValueTask SetToLocalStorage(string key, string value) => await _js.InvokeVoidAsync("localStorage.setItem", key, value);
        public async ValueTask<string?> GetFromLocalStorage(string key, string? defaultValue = null) => await _js.InvokeAsync<string>("localStorage.getItem", key) ?? defaultValue;
        public async ValueTask RemoveFromLocalStorage(string key) => await _js.InvokeVoidAsync("localStorage.removeItem", key);
        public async ValueTask SetToSessionStorage(string key, string value) => await _js.InvokeVoidAsync("sessionStorage.setItem", key, value);
        public async ValueTask<string?> GetFromSessionStorage(string key, string? defaultValue = null) => await _js.InvokeAsync<string>("sessionStorage.getItem", key) ?? defaultValue;
        public async ValueTask RemoveFromSessionStorage(string key) => await _js.InvokeVoidAsync("sessionStorage.removeItem", key);
    }
}
