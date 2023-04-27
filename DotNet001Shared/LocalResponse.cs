using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DotNet001Shared
{
    public class LocalResponse<T>
    {
        public List<T> Value { get; set; }

        public HttpResponseMessage HttpResponseMessage { get; set; }
    }
}
