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
        public AppRes<CustomerRes> GetByCD(Guid cd);
        public AppRes<List<CustomerRes>> GetAll();
        public AppRes<CustomerRes> SoftDelete(Guid cd);
        public AppRes<CustomerRes> DeleteCustomer(Guid cd);

        public AppRes<List<CustomerNoteRes>> GetAllNoteByCustomerID(Guid customerCD);
        public AppRes<CustomerNoteRes> Create(CustomerNoteCreateReq customerExtField);
        public AppRes<CustomerNoteRes> Update(CustomerNoteUpdateReq customerExtField);
        public AppRes<CustomerNoteRes> DeleteCustomerNote(Guid customerCD , int noteID);

        public AppRes<List<CustomerFieldDefRes>> GetAllCustomerFieldDef();
        public AppRes<CustomerFieldDefRes> Create(CustomerFieldDefCreateReq customerFieldDefCreateReq);
        public AppRes<CustomerFieldDefRes> Update(CustomerFieldDefUpdateReq customerFieldDefUpdateReq);
        public AppRes<CustomerFieldDefRes> DeleteCustomerFieldDef(int fieldDefinitionID);

        public AppRes<List<CustomerFieldValueRes>> GetAllCustomerFieldValueByCustomer(Guid customerCD);
        public AppRes<CustomerFieldValueRes> Create(CustomerFieldValueCreateReq customerFieldDefCreateReq);
        public AppRes<CustomerFieldValueRes> Update(CustomerFieldValueUpdateReq customerFieldDefUpdateReq);
        public AppRes<CustomerFieldValueRes> DeleteCustomerFieldValue(Guid CustomerCD, int fieldID);
    }
}
