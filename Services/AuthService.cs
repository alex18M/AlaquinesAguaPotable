using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace AguaPotableAlaquines.Services
{
    public class AuthService
    {
        private readonly IJSRuntime _js;

        public AuthService(IJSRuntime js)
        {
            _js = js;
        }

        public async Task<bool> LoginAsync(string email, string password)
        {
            try
            {
                var result = await _js.InvokeAsync<string>("firebaseLogin", email, password);
                return result == "success";
            }
            catch
            {
                return false;
            }
        }

        public async Task LogoutAsync()
        {
            await _js.InvokeVoidAsync("firebaseLogout");
        }

        public async Task<string> GetUserEmailAsync()
        {
            return await _js.InvokeAsync<string>("firebaseGetUserEmail");
        }
    }
}
