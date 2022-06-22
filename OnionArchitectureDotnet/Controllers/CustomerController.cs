﻿using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;

namespace OnionArchitectureDotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        #region Property
        private readonly ICustomerService _customerService;
        #endregion

        #region Controller
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        #endregion

        [HttpGet(nameof(GetCustomer))]
        public IActionResult GetCustomer(int id)
        {
            var result = _customerService.GetCustomer(id);
            if(result is not null)
            {
                return Ok(result);
            }
            return BadRequest("No record found");
        }

        [HttpGet(nameof(GetAllCustomers))]
        public IActionResult GetAllCustomers()
        {
            var result = _customerService.GetAllCustomers();
            if(result is not null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");
        }

        [HttpPost(nameof(InsertCustomer))]
        public IActionResult InsertCustomer(Customer customer)
        {
            _customerService.InsertCustomer(customer);
            return Ok("Data inserted");
        }

        [HttpPut(nameof(UpdateCustomer))]
        public IActionResult UpdateCustomer(Customer customer)
        {
            _customerService.UpdateCustomer(customer);
            return Ok("Update done");
        }

        [HttpDelete(nameof(DeleteCustomer))]
        public IActionResult DeleteCustomer(int Id)
        {
            _customerService.DeleteCustomer(Id);
            return Ok("Data deleted");
        }
    }
}
