using AutoMapper;
using POS_Blagajna_Backend.DTOs.CustomerDTOs;
using POS_Blagajna_Backend.DTOs.ProductDTOs;
using POS_Blagajna_Backend.DTOs.ReceiptHeaderDTOs;
using POS_Blagajna_Backend.Entities;

namespace POS_Blagajna_Backend.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();

            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerDTO, Customer>();

            CreateMap<Receipt, ReceiptDTO>();
            CreateMap<ReceiptDTO, Receipt>();
        }
    }
}