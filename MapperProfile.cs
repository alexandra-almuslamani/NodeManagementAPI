using AutoMapper;
using Microsoft.AspNetCore.Identity;
using NodeManagementAPI.Core.Dtos;
using NodeManagementAPI.Core.Entities;
using NodeManagementAPI.Core.Dtos.NodeDTO;
using NodeManagementAPI.Core.Dtos.NodeTypeDTO;

namespace NodeManagementAPI.Infrastructure.MaperProfile
{
	public class MapperProfile : Profile
	{
		public MapperProfile()
		{
       CreateMap<AddNodeDTO, Node>();
       CreateMap<Node, NodeResponseDTO>();
       CreateMap<NodeResponseDTO, Node>();
       CreateMap<Node, NodeIdResponseDTO>();
       CreateMap<Node, UpdateNodeDTO>();
       CreateMap<NodeResponseDTO, UpdateNodeDTO>();

       CreateMap<AddNodeTypeDTO, NodeType>();
       CreateMap<NodeType, NodeTypeResponseDTO>();
    }
  }
}
      
