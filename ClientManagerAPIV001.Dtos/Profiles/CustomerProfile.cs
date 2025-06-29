using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClientManagerAPIV001.Dtos.Requests.Customer;
using ClientManagerAPIV001.Dtos.Responses;
using ClientManagerAPIV001.Models;

namespace ClientManagerAPIV001.Dtos.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile() {

            CreateMap<Customer , CustomerRes>();
            CreateMap<CustomerCreateReq , Customer>();
            CreateMap<CustomerUpdateReq, Customer>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CustomerNote, CustomerNoteRes>();
            CreateMap<CustomerNoteCreateReq, CustomerNote>();
            CreateMap<CustomerNoteUpdateReq, CustomerNote>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CustomerFieldDefCreateReq , CustomerFieldDefinition>();
            CreateMap<CustomerFieldDefinition, CustomerFieldDefRes>();
            CreateMap<CustomerFieldDefUpdateReq, CustomerFieldDefinition>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CustomerFieldValue, CustomerFieldValueRes>()
                .ForMember(des => des.ID, opt => opt.MapFrom(src => src.ID));
            CreateMap<CustomerFieldValueCreateReq, CustomerFieldValue>()
                .ForMember(des => des.ID, opt => opt.MapFrom(src => src.FieldID));
            CreateMap<CustomerFieldValueUpdateReq, CustomerFieldValue>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CustomerFieldDefinition, CustomerFieldRes>();
            CreateMap<CustomerFieldValue, CustomerFieldRes>();








        }
        
    }
}
