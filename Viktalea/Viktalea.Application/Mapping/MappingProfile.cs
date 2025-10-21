using AutoMapper;
using Viktalea.Application.Dtos;
using Viktalea.Application.Features.Clients.Commands.Create;
using Viktalea.Application.Features.Clients.Commands.Update;
using Viktalea.Domain.Entities;

namespace Viktalea.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Client, ClientDto>().ReverseMap();
            CreateMap<CreateClientCommand, Client>().ReverseMap();
            CreateMap<UpdateClientCommand, Client>().ReverseMap();
        }
    }
}
