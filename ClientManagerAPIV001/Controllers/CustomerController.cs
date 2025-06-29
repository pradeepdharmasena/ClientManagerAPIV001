using ClientManagerAPIV001.Dtos.Requests.Customer;
using ClientManagerAPIV001.Dtos.Responses;
using ClientManagerAPIV001.Models;
using ClientManagerAPIV001.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientManagerAPIV001.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController(ICustomerService customerService) : ControllerBase
    {
        [HttpGet("all")]
        public IActionResult GetAll(int pageNumber, int pageSize)
        {
            if (GetUser() == null) return BadRequest("User is null. May Token invalid.");
            AppRes<List<CustomerRes>> result = customerService.GetAll(pageNumber, pageSize);
            if (result.Error != null) return BadRequest(result);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetByCD(string customerCD)
        {
            if (GetUser() == null) return BadRequest("User is null. May Token invalid.");
            AppRes<CustomerRes> result = customerService.GetByCD(customerCD);
            if (result.Error != null) return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("note")]
        public IActionResult GetNote(string customerCD)
        {
            if (GetUser() == null) return BadRequest("User is null. May Token invalid.");
            AppRes<List<CustomerNoteRes>> result = customerService.GetAllNoteByCustomerID(customerCD);
            if (result.Error != null) return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("fielddef")]
        public IActionResult GetFieldDef()
        {
            if (GetUser() == null) return BadRequest("User is null. May Token invalid.");
            AppRes<List<CustomerFieldDefRes>> result = customerService.GetAllCustomerFieldDef();
            if (result.Error != null) return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("fieldval")]
        public IActionResult GetFieldVal(string customerCD)
        {
            if (GetUser() == null) return BadRequest("User is null. May Token invalid.");
            AppRes<List<CustomerFieldValueRes>> result = customerService.GetAllCustomerFieldValueByCustomer(customerCD);
            if (result.Error != null) return BadRequest(result);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create(CustomerCreateReq customerCreateReqDTO)
        {
            if (GetUser() == null) return BadRequest("User is null. May Token invalid.");
            AppRes<CustomerRes> result = customerService.Create(customerCreateReqDTO);
            if (result.Error != null) return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("fielddef")]
        public IActionResult CreateCustomerFieldDef(CustomerFieldDefCreateReq customerFieldDefCreateReq)
        {
            if (GetUser() == null) return BadRequest("User is null. May Token invalid.");
            AppRes<CustomerFieldDefRes>? result = customerService.Create(customerFieldDefCreateReq);
            if (result.Error != null) return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("fieldval")]
        public IActionResult CreateCustomerFieldVal(CustomerFieldValueCreateReq customerFieldValueCreateReq)
        {
            if (GetUser() == null) return BadRequest("User is null. May Token invalid.");
            AppRes<CustomerFieldValueRes> result = customerService.Create(customerFieldValueCreateReq);
            if (result.Error != null) return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("note")]
        public IActionResult CreateCustomerNote(CustomerNoteCreateReq customerNoteCreateReq)
        {
            if (GetUser() == null) return BadRequest("User is null. May Token invalid.");
            AppRes<CustomerNoteRes> result = customerService.Create(customerNoteCreateReq);
            if (result.Error != null) return BadRequest(result);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update(CustomerUpdateReq customerUpdateDTO)
        {
            if (GetUser() == null) return BadRequest("User is null. May Token invalid.");
            AppRes<CustomerRes> result = customerService.Update(customerUpdateDTO);
            if (result.Error != null) return BadRequest(result);
            return Ok(result);
        }

        [HttpPut("fielddef")]
        public IActionResult Update(CustomerFieldDefUpdateReq customerFieldDefUpdateReq)
        {
            if (GetUser() == null) return BadRequest("User is null. May Token invalid.");
            AppRes<CustomerFieldDefRes> result = customerService.Update(customerFieldDefUpdateReq);
            if (result.Error != null) return BadRequest(result);
            return Ok(result);
        }

        [HttpPut("fieldval")]
        public IActionResult Update(CustomerFieldValueUpdateReq customerFieldValueUpdateReq)
        {
            if (GetUser() == null) return BadRequest("User is null. May Token invalid.");
            AppRes<CustomerFieldValueRes> result = customerService.Update(customerFieldValueUpdateReq);
            if (result.Error != null) return BadRequest(result);
            return Ok(result);
        }

        [HttpPut("note")]
        public IActionResult Update(CustomerNoteUpdateReq customerNoteUpdateReq)
        {
            if (GetUser() == null) return BadRequest("User is null. May Token invalid.");
            AppRes<CustomerNoteRes> result = customerService.Update(customerNoteUpdateReq);
            if (result.Error != null) return BadRequest(result);
            return Ok(result);
        }

        private string? GetUser()
        {
            return User.Claims.FirstOrDefault(c => c.Type == "UserCD")?.Value;
        }
    }
}
