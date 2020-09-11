using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Edify.Service;
using Edify.Model;
using Edify.Api.ViewModel;
using System.Text;
using Microsoft.Extensions.Logging;
using System;

namespace Edify.Api.Controllers
{
    [Controller]
    [Route("Customer")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _service;
        private readonly ILogger _logger;
        public CustomerController(ICustomerService service, ILogger<CustomerController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            return View("Views/Customer.cshtml");
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Add(CustomerViewModel customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _service.AddCustomer(new CustomerModel
                    {
                        Id = customer.Id,
                        Name = customer.Name,
                        Email = customer.Email
                    });
                    return Json(true);
                }
                else
                {

                    StringBuilder result = new StringBuilder();

                    foreach (var item in ModelState)
                    {
                        string key = item.Key;
                        var errors = item.Value.Errors;

                        foreach (var error in errors)
                        {
                            result.Append(key + " " + error.ErrorMessage);
                        }
                    }
                    return Json(result.ToString());
                }
            }
            catch (Exception ex) {
                _logger.LogError("error :"+DateTime.Now.ToString()+"  "+ ex.Message);
                return Json("Some error occured");
            }
            //return View("Views/Customer.cshtml");
        }
    }
}