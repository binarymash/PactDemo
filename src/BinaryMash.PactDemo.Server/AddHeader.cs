using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;

namespace BinaryMash.PactDemo.Server
{
    public class AddHeader :OwinMiddleware
    {
        private readonly OwinMiddleware _next;

        public AddHeader(OwinMiddleware next) : base(next)
        {
            _next = next;
        }

        public override async Task Invoke(IOwinContext context)
        {
            context.Response.Headers.Add("abc",new [] {"def"});
            await _next.Invoke(context);
        }
    }
}
