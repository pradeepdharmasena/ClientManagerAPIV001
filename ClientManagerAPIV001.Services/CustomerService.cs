using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClientManagerAPIV001.Dtos.Requests.Customer;
using ClientManagerAPIV001.Dtos.Responses;
using ClientManagerAPIV001.Models;
using ClientManagerAPIV001.Repositories;
using ClientManagerAPIV001.Services.Utils;

namespace ClientManagerAPIV001.Services
{
    public class CustomerService(ICustomerRepository customerRepository, IMapper mapper) : ICustomerService
    {
        public AppRes<CustomerRes> Create(CustomerCreateReq customerCreateReqDTO)
        {
            Customer customer = mapper.Map<Customer>(customerCreateReqDTO);
            Customer? createdCustomer = customerRepository.Create(customer);
            if (createdCustomer == null) return ErrorManager.Error<CustomerRes>("Unable to create the customer");
            return ResWrapper.Res<CustomerRes>(mapper.Map<CustomerRes>(createdCustomer));
        }

        public AppRes<CustomerNoteRes> Create(CustomerNoteCreateReq customerNoteCreateReq)
        {
            Customer? customer = customerRepository.GetByCD(customerNoteCreateReq.CustomerCD);
            if (customer == null) return ErrorManager.Error<CustomerNoteRes>("Unable to find the customer");
            CustomerNote? customerNote = mapper.Map<CustomerNote>(customerNoteCreateReq);
            customerNote.CustomerID  = customer.CustomerId;
            if (customerNote == null) return ErrorManager.Error<CustomerNoteRes>("Unable to cast the customer note request in to customer note");
            customerNote = customerRepository.Create(customerNote);
            if (customerNote == null) return ErrorManager.Error<CustomerNoteRes>("Unable to save the customer note");
            return ResWrapper.Res<CustomerNoteRes>(mapper.Map<CustomerNoteRes>(customerNote));
        }

        public AppRes<CustomerFieldDefRes> Create(CustomerFieldDefCreateReq customerFieldDefCreateReq)
        {
            CustomerFieldDefinition? customerFieldDefinition = mapper.Map<CustomerFieldDefinition>(customerFieldDefCreateReq);
            customerFieldDefinition = customerRepository.Create(customerFieldDefinition);
            if (customerFieldDefinition == null) return ErrorManager.Error<CustomerFieldDefRes>("Unable to save the customer Field definition");
            return ResWrapper.Res<CustomerFieldDefRes>(mapper.Map<CustomerFieldDefRes>(customerFieldDefinition));
        }

        public AppRes<CustomerRes> DeleteCustomer(Guid cd)
        {
            Customer? customer = customerRepository.GetByCD(cd);
            if (customer == null) return ErrorManager.Error<CustomerRes>("Unable to find the customer");

            customer = customerRepository.Delete(customer);
            if (customer == null) return ErrorManager.Error<CustomerRes>("Unable to delete the customer");

            return ResWrapper.Res<CustomerRes>(mapper.Map<CustomerRes>(customer));
        }

        public AppRes<List<CustomerRes>> GetAll()
        {
            List<Customer>? customers = customerRepository.GetAllCustomers();
            return ResWrapper.Res<List<CustomerRes>>(mapper.Map<List<CustomerRes>>(customers));
        }

        public AppRes<List<CustomerNoteRes>> GetAllNoteByCustomerID(Guid customerCD)
        {
            Customer? customer = customerRepository.GetByCD(customerCD);
            if (customer == null) return ErrorManager.Error<List<CustomerNoteRes>>("Unable to find the customer");

            List<CustomerNote>? customerNotes = customerRepository.GetAllNotes(customer.CustomerId);
            if (customerNotes == null) return ErrorManager.Error<List<CustomerNoteRes>>("Unable to get customer notes");

            List<CustomerNoteRes> result = mapper.Map<List<CustomerNoteRes>>(customerNotes);
            return ResWrapper.Res<List<CustomerNoteRes>>(mapper.Map<List<CustomerNoteRes>>(result));

        }

        public AppRes<CustomerRes> GetByCD(Guid cd)
        {
            Customer? customer = customerRepository.GetByCD(cd);
            if (customer == null) return ErrorManager.Error<CustomerRes>("Unable to find the customer");
            return ResWrapper.Res<CustomerRes>(mapper.Map<CustomerRes>(customer));
        }

        public AppRes<CustomerRes> SoftDelete(Guid cd)
        {
            throw new NotImplementedException();
        }

        public AppRes<CustomerRes> Update(CustomerUpdateReq customerUpdateDTO)
        {
            Customer? customer = customerRepository.GetByCD(customerUpdateDTO.CustomerCD);
            if (customer == null) return ErrorManager.Error<CustomerRes>("Unable to find the customer");
            customer = mapper.Map(customerUpdateDTO, customer);
            customer = customerRepository.Update(customer);
            if (customer == null) return ErrorManager.Error<CustomerRes>("Unable to update the customer");
            return ResWrapper.Res<CustomerRes>(mapper.Map<CustomerRes>(customer));
        }

        public AppRes<CustomerFieldDefRes> Update(CustomerFieldDefUpdateReq customerFieldDefUpdateReq)
        {
            CustomerFieldDefinition? customerFieldDefinition = customerRepository.GetFieldDefinition(customerFieldDefUpdateReq.ID);
            if (customerFieldDefinition == null) return ErrorManager.Error<CustomerFieldDefRes>("No such customer field defintion");
            customerFieldDefinition = mapper.Map(customerFieldDefUpdateReq, customerFieldDefinition);
            customerFieldDefinition = customerRepository.Update(customerFieldDefinition);
            if (customerFieldDefinition == null) return ErrorManager.Error<CustomerFieldDefRes>("Unable to update the customer field defintion");
            CustomerFieldDefRes customerFieldDefRes = mapper.Map<CustomerFieldDefRes>(customerFieldDefinition);
            return ResWrapper.Res<CustomerFieldDefRes>(customerFieldDefRes);
        }

        public AppRes<CustomerNoteRes> DeleteCustomerNote(Guid customerCD, int noteID)
        {
            Customer? customer = customerRepository.GetByCD(customerCD);
            if (customer == null) return ErrorManager.Error<CustomerNoteRes>("No such customer");
            CustomerNote? customerNote = customerRepository.GetNote(customer.CustomerId, noteID);
            if (customerNote == null) return ErrorManager.Error<CustomerNoteRes>(null, "Customer note not found"); 
            customerNote = customerRepository.Delete(customerNote);
            if (customerNote == null) return ErrorManager.Error<CustomerNoteRes>("Unable to delete customer note");
            return ResWrapper.Res<CustomerNoteRes>(mapper.Map<CustomerNoteRes>(customerNote));
        }

        public AppRes<List<CustomerFieldDefRes>> GetAllCustomerFieldDef()
        {
            List<CustomerFieldDefinition>? customerFieldDefinitions = customerRepository.GetAllFieldDefinitions();
            if (customerFieldDefinitions == null) return ErrorManager.Error<List<CustomerFieldDefRes>>("Unable to fetch the customer Field Defintion");
            return ResWrapper.Res<List<CustomerFieldDefRes>>(mapper.Map<List<CustomerFieldDefRes>>(customerFieldDefinitions));
        }

        public AppRes<CustomerFieldDefRes> DeleteCustomerFieldDef(int fieldDefinitionID)
        {
            CustomerFieldDefinition? customerFieldDefinition = customerRepository.GetFieldDefinition(fieldDefinitionID);
            if(customerFieldDefinition == null) return ErrorManager.Error<CustomerFieldDefRes>("Unable to fetch the customer Field Defintion");
            customerFieldDefinition = customerRepository.Delete(customerFieldDefinition);
            if (customerFieldDefinition == null) return ErrorManager.Error<CustomerFieldDefRes>("Unable to delete the customer Field Defintion");
            return ResWrapper.Res<CustomerFieldDefRes>(mapper.Map<CustomerFieldDefRes>(customerFieldDefinition));
        }

        public AppRes<List<CustomerFieldValueRes>> GetAllCustomerFieldValueByCustomer(Guid customerCD)
        {
            Customer? customer = customerRepository.GetByCD(customerCD);
            if (customer == null) return ErrorManager.Error<List<CustomerFieldValueRes>>("No such customer");
            List<CustomerFieldValue>? customerFieldValues = customerRepository.GetAllCustomerFieldValue(customer.CustomerId);
            if (customerFieldValues == null) return ErrorManager.Error<List< CustomerFieldValueRes>>("Unable to fetch any customer field value");
            return ResWrapper.Res<List<CustomerFieldValueRes>>(mapper.Map<List<CustomerFieldValueRes>>(customerFieldValues));
        }

        public AppRes<CustomerFieldValueRes> Create(CustomerFieldValueCreateReq customerFieldDefCreateReq)
        {
            CustomerFieldValue? customerFieldValue = mapper.Map<CustomerFieldValue>(customerFieldDefCreateReq);
            customerFieldValue = customerRepository.Create(customerFieldValue);
            if (customerFieldValue == null) return ErrorManager.Error<CustomerFieldValueRes>("Unable to create the customer Field value");
            return ResWrapper.Res<CustomerFieldValueRes>(mapper.Map<CustomerFieldValueRes>(customerFieldValue));
        }

        public AppRes<CustomerFieldValueRes> Update(CustomerFieldValueUpdateReq customerFieldDefUpdateReq)
        {
            Customer? customer = customerRepository.GetByCD(customerFieldDefUpdateReq.CustomerCD);
            if (customer == null) return ErrorManager.Error<CustomerFieldValueRes>("Unable to fetch customer");
            CustomerFieldValue? customerFieldValue = customerRepository.GetCustomerFieldValue(customer.CustomerId, customerFieldDefUpdateReq.FieldID);
            if (customerFieldValue == null) return ErrorManager.Error<CustomerFieldValueRes>("Unable to fetch field value");
            customerFieldValue = mapper.Map(customerFieldDefUpdateReq,customerFieldValue);
            customerFieldValue = customerRepository.Update(customerFieldValue);
            if (customerFieldValue == null) return ErrorManager.Error<CustomerFieldValueRes>("Unable to save the customer field value");
            return ResWrapper.Res<CustomerFieldValueRes>(mapper.Map<CustomerFieldValueRes>(customerFieldValue)); 
        }

        public AppRes<CustomerFieldValueRes> DeleteCustomerFieldValue(Guid CustomerCD, int fieldID)
        {
            Customer? customer = customerRepository.GetByCD(CustomerCD);
            if (customer == null) return ErrorManager.Error<CustomerFieldValueRes>("Unable to fetch customer");
            CustomerFieldValue? customerFieldValue = customerRepository.GetCustomerFieldValue(customer.CustomerId, fieldID);
            if (customerFieldValue == null) return ErrorManager.Error<CustomerFieldValueRes>("Unable to fetch customer field value");
            customerFieldValue = customerRepository.Delete(customerFieldValue);
            if (customerFieldValue == null) return ErrorManager.Error<CustomerFieldValueRes>("Unable to delete customer field value");
            return ResWrapper.Res<CustomerFieldValueRes>(mapper.Map<CustomerFieldValueRes>(customerFieldValue));
        }

        public AppRes<CustomerNoteRes> Update(CustomerNoteUpdateReq customerNoteUpdateReq)
        {
            Customer? customer = customerRepository.GetByCD(customerNoteUpdateReq.CustomerCD);
            if (customer == null) return ErrorManager.Error<CustomerNoteRes>("Unable to fetch customer");
            CustomerNote? customerNote = customerRepository.GetNote(customer.CustomerId, customerNoteUpdateReq.Id);
            if(customerNote == null) return ErrorManager.Error<CustomerNoteRes>("Unable to fetch customer note");
            customerNote = mapper.Map(customerNoteUpdateReq, customerNote);
            customerNote = customerRepository.Update(customerNote);
            if(customerNote == null) return ErrorManager.Error<CustomerNoteRes>("Unable to update customer note");
            return ResWrapper.Res<CustomerNoteRes>(mapper.Map<CustomerNoteRes>(customerNote));
        }
    }
}
