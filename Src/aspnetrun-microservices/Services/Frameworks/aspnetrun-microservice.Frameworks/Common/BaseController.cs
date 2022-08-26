using System;
using Microsoft.AspNetCore.Mvc;

namespace aspnetrun_microservice.Frameworks.Common
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BaseController: ControllerBase
    {
        public BaseController()
        {
        }
    }
}

