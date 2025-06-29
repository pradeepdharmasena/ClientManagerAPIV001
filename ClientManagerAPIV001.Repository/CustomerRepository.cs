using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientManagerAPIV001.DataAccess;
using ClientManagerAPIV001.Models;
using ClientManagerAPIV001.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ClientManagerAPIV001.Dtos.Responses;

namespace ClientManagerAPIV001.Repositories
{
    public class CustomerRepository(SQLDBContext sQLDBContext) : ICustomerRepository
    {
        public Customer? Create(Customer customer)
        {
            try
            {
               EntityEntry<Customer> savedCustomer = sQLDBContext.Customers.Add(customer);
                sQLDBContext.SaveChanges();
                return savedCustomer.Entity;
            }
            catch (Exception ex) 
            {
                return null;
            }
        }

        public CustomerNote? Create(CustomerNote customerNote)
        {
            try
            {
                EntityEntry<CustomerNote> savedcustomerNote = sQLDBContext.CustomerNotes.Add(customerNote);
                sQLDBContext.SaveChanges();
                return savedcustomerNote.Entity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public CustomerFieldDefinition? Create(CustomerFieldDefinition customerFieldDefinition)
        {
            try
            {
                EntityEntry<CustomerFieldDefinition> savedCustomerFieldDefinition = sQLDBContext.CustomerFieldDefinitions.Add(customerFieldDefinition);
                sQLDBContext.SaveChanges();
                return savedCustomerFieldDefinition.Entity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public CustomerFieldValue? Create(CustomerFieldValue customerFieldValue)
        {
            try
            {
                EntityEntry<CustomerFieldValue> savedCustomerFieldValue = sQLDBContext.CustomerFieldValues.Add(customerFieldValue);
                sQLDBContext.SaveChanges();
                return savedCustomerFieldValue.Entity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Customer? Delete(Customer customer)
        {
            try
            {
                EntityEntry<Customer> removedCustomer = sQLDBContext.Customers.Remove(customer);
                sQLDBContext.SaveChanges();
                return removedCustomer.Entity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public CustomerNote? Delete(CustomerNote customerNote)
        {
            try
            {
                EntityEntry<CustomerNote> removedcustomerNote = sQLDBContext.CustomerNotes.Remove(customerNote);
                sQLDBContext.SaveChanges();
                return removedcustomerNote.Entity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public CustomerFieldDefinition? Delete(CustomerFieldDefinition customerFieldDefinition)
        {
            try
            {
                EntityEntry<CustomerFieldDefinition> removedCustomerFieldDefinition = sQLDBContext.CustomerFieldDefinitions.Remove(customerFieldDefinition);
                sQLDBContext.SaveChanges();
                return removedCustomerFieldDefinition.Entity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public CustomerFieldValue? Delete(CustomerFieldValue customerFieldValue)
        {
            try
            {
                EntityEntry<CustomerFieldValue> removedCustomerFieldValue = sQLDBContext.CustomerFieldValues.Remove(customerFieldValue);
                sQLDBContext.SaveChanges();
                return removedCustomerFieldValue.Entity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Customer>? GetAllCustomers(int pageNumber, int pageSize, out int totalCount)
        {
            totalCount = sQLDBContext.Customers.Count();

            return sQLDBContext.Customers
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public (List<Customer> Customers, List<CustomerFieldValue> FieldValues, List<CustomerFieldDefinition> customerFieldDefinitions) GetCustomers(int pageNumber, int pageSize, out int totalCount)
        {
            totalCount = sQLDBContext.Customers.Count();

            var customers = sQLDBContext.Customers
                .OrderBy(c => c.CustomerId) 
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var customerIds = customers.Select(c => c.CustomerId).ToList();

            var fieldValues = sQLDBContext.CustomerFieldValues
                .Where(fv => customerIds.Contains(fv.CustomerID))
                .ToList();

            var fieldDefs = sQLDBContext.CustomerFieldDefinitions.ToList();

            return (customers, fieldValues, fieldDefs);
        }

        public List<CustomerFieldValue>? GetAllCustomerFieldValue(long customerId)
        {
            try
            {
                List<CustomerFieldValue> customerFieldValues = [.. sQLDBContext.CustomerFieldValues.Where(t => t.CustomerID == customerId)];
                sQLDBContext.SaveChanges();
                return customerFieldValues;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<CustomerFieldDefinition>? GetAllFieldDefinitions()
        {
            return [..sQLDBContext.CustomerFieldDefinitions];
        }

        public Customer? GetByCD(string customerCD)
        {
            return sQLDBContext.Customers.FirstOrDefault(c => c.CustomerCD == customerCD);
        }

        public List<CustomerNote>? GetAllNotes(long customerId)
        {
            try
            {
                List<CustomerNote> extFields = sQLDBContext.CustomerNotes.Where(c => c.CustomerID == customerId).ToList();
                return extFields;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Customer? Update(Customer customer)
        {
            try
            {
                EntityEntry<Customer> removedCustomer = sQLDBContext.Customers.Update(customer);
                sQLDBContext.SaveChanges();
                return removedCustomer.Entity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public CustomerNote? Update(CustomerNote customerNote)
        {
            try
            {
                EntityEntry<CustomerNote> removedcustomerNote = sQLDBContext.CustomerNotes.Update(customerNote);
                sQLDBContext.SaveChanges();
                return removedcustomerNote.Entity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public CustomerFieldDefinition? Update(CustomerFieldDefinition customerFieldDefinition)
        {
            try
            {
                EntityEntry<CustomerFieldDefinition> updatedCustomerFieldDefinition = sQLDBContext.CustomerFieldDefinitions.Update(customerFieldDefinition);
                sQLDBContext.SaveChanges();
                return updatedCustomerFieldDefinition.Entity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public CustomerFieldValue? Update(CustomerFieldValue customerFieldValue)
        {
            try
            {
                EntityEntry<CustomerFieldValue> updatedCustomerFieldValue = sQLDBContext.CustomerFieldValues.Update(customerFieldValue);
                sQLDBContext.SaveChanges();
                return updatedCustomerFieldValue.Entity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public CustomerNote? GetNote(long customerId, int ID)
        {
            try
            {
                CustomerNote? customerNote = sQLDBContext.CustomerNotes.FirstOrDefault(f => f.CustomerID == customerId && f.ID == ID);
                return customerNote;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public CustomerFieldDefinition? GetFieldDefinition(int ID)
        {
            try
            {
                CustomerFieldDefinition? customerFieldDefinition = sQLDBContext.CustomerFieldDefinitions.FirstOrDefault(f => f.ID == ID);
                return customerFieldDefinition;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public CustomerFieldValue? GetCustomerFieldValue(long customerId, int fieldID)
        {
            try
            {
               CustomerFieldValue? customerFieldValue = sQLDBContext.CustomerFieldValues.FirstOrDefault(f => f.ID == fieldID && f.CustomerID == customerId);
                return customerFieldValue;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
