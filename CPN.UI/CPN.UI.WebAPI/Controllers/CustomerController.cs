using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CPN.Application.Interfaces;
using CPN.Application.ViewModels;
using CPN.UI.WebAPI.Configuration;
using CPN.UI.WebAPI.ExceptionHandling;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CPN.UI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ControllerExceptionFilterAttribute))]
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = IdentityServerAuthenticationDefaults.AuthenticationScheme, Policy = AuthorizationConsts.AdministrationPolicy)]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;


        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<ActionResult<CustomerViewModel>> Get()
        {
            var clientsDto = _customerService.GetAllCustomersAsync();
           // var clientsApiDto = clientsDto.ToClientApiModel<CustomerViewModel>();

            return Ok(clientsDto);
        }

    }
}