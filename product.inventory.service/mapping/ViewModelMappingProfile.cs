using AutoMapper;
using product.inventory.data.models;
using product.inventory.dto;

namespace product.inventory.service.mapping
{
    public class ViewModelMappingProfile : Profile
    {
        public ViewModelMappingProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<ProductDto, Product>();
            CreateMap<ProductInventoryDto, ProductInventory>();
            CreateMap<ProductInventoryLogDto, ProductInventoryLog>();

            CreateMap<User, UserDto>();
            CreateMap<Product, ProductDto>();
            CreateMap<ProductInventory, ProductInventoryDto>();
            CreateMap<ProductInventoryLog, ProductInventoryLogDto>();
        }
    }
}