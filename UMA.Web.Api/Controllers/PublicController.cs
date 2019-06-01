using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMA.Web.Api.Controllers
{
    public class PublicController : BaseController
    {
        [HttpGet]
        [AllowAnonymous]
        public string Version()
        {
            return @"Api v1.0.0";
        }
    }
}
