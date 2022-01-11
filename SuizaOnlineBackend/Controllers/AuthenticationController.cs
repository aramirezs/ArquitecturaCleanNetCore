﻿using Application.Interfaces.IServices;
using Domain.Payloads.Auths;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SuizaOnlineBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync([FromBody] AuthPayload payload)
        {
            return Ok(await authenticationService.Auth(payload));
        }


    }
}
