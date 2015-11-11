using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HTMLUIWinFormsApp.Web.controllers
{
    [RoutePrefix("api")]
    public class DefaultAPIController : ApiController
    {
        [HttpGet, Route("values")]
        public int[] GetValues()
        {
            return new[] { 1, 2, 3 };
        }
    }
}
