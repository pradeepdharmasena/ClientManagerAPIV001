using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientManagerAPIV001.Models;

namespace ClientManagerAPIV001.Repositories
{
    public interface ICustomerRepository
    {
        public Customer? Create(Customer customer);
        public Customer? GetByCD(Guid customerCD);
        public List<Customer>? GetAllCustomers();
        public Customer? Update(Customer customer);
        public Customer? Delete(Customer customer);

        public CustomerNote? Create(CustomerNote customerNote);
        public List<CustomerNote>? GetAllNotes(long customerId);
        public CustomerNote? GetNote(long customerId, int ID);
        public CustomerNote? Update(CustomerNote customerNote);
        public CustomerNote? Delete(CustomerNote customerNote);

        public CustomerFieldDefinition? Create(CustomerFieldDefinition customerFieldDefinition);
        public List<CustomerFieldDefinition>? GetAllFieldDefinitions();
        public CustomerFieldDefinition? GetFieldDefinition(int ID);
        public CustomerFieldDefinition? Update(CustomerFieldDefinition customerFieldDefinition);
        public CustomerFieldDefinition? Delete(CustomerFieldDefinition customerFieldDefinition);

        public CustomerFieldValue? Create(CustomerFieldValue customerFieldValue);
        public List<CustomerFieldValue>? GetAllCustomerFieldValue(long customerId);
        public CustomerFieldValue? GetCustomerFieldValue(long customerId, int fieldID);
        public CustomerFieldValue? Update(CustomerFieldValue customerFieldValue);
        public CustomerFieldValue? Delete(CustomerFieldValue customerFieldValue);


    }
}
