using System.Threading.Tasks;
using Microsoft.Owin;

namespace BinaryMash.PactDemo.Provider.Middleware
{
    public class TweakHeaders : OwinMiddleware
    {
        private readonly OwinMiddleware _next;

        public TweakHeaders(OwinMiddleware next) : base(next)
        {
            _next = next;
        }

        public override async Task Invoke(IOwinContext context)
        {
            var response = context.Response;

            response.OnSendingHeaders(state =>
            {
                var resp = (OwinResponse) state;

                resp.Headers.Add("Another", new []{ "header"});

                //MOD-2 - extra header returned by provider
                //resp.Headers.Add("abc", new[] { "def" });

                //MOD-5 - fewer headers returned by provider
                //resp.Headers.Remove("Another");

            }, response);

            await _next.Invoke(context);
        }
    }
}
