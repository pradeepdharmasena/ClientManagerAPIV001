using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientManagerAPIV001.Dtos.Requests.Customer;
using ClientManagerAPIV001.Dtos.Responses;
using ClientManagerAPIV001.Models;

namespace ClientManagerAPIV001.Services
{
    public interface ICustomerService
    {
        public AppRes<CustomerRes> Create(CustomerCreateReq customerCreateReqDTO);
        public AppRes<CustomerRes> Update(CustomerUpdateReq customerUpdateDTO);
        public AppRes<CustomerRes> GetByCD(string cd);
        public AppRes<List<CustomerRes>> GetAll(int pageNumber, int pageSize);
        public AppRes<CustomerRes> SoftDelete(string cd);
        public AppRes<CustomerRes> DeleteCustomer(string cd);

        public AppRes<List<CustomerNoteRes>> GetAllNoteByCustomerID(string customerCD);
        public AppRes<CustomerNoteRes> Create(CustomerNoteCreateReq customerExtField);
        public AppRes<CustomerNoteRes> Update(CustomerNoteUpdateReq customerExtField);
        public AppRes<CustomerNoteRes> DeleteCustomerNote(string customerCD , int noteID);

        public AppRes<List<CustomerFieldDefRes>> GetAllCustomerFieldDef();
        public AppRes<CustomerFieldDefRes> Create(CustomerFieldDefCreateReq customerFieldDefCreateReq);
        public AppRes<CustomerFieldDefRes> Update(CustomerFieldDefUpdateReq customerFieldDefUpdateReq);
        public AppRes<CustomerFieldDefRes> DeleteCustomerFieldDef(int fieldDefinitionID);

        public AppRes<List<CustomerFieldValueRes>> GetAllCustomerFieldValueByCustomer(string customerCD);
        public AppRes<CustomerFieldValueRes> Create(CustomerFieldValueCreateReq customerFieldDefCreateReq);
        public AppRes<CustomerFieldValueRes> Update(CustomerFieldValueUpdateReq customerFieldDefUpdateReq);
        public AppRes<CustomerFieldValueRes> DeleteCustomerFieldValue(string CustomerCD, int fieldID);
    }
}
