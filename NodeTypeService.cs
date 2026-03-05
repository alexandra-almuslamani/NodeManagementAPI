using AutoMapper;
using NodeManagementAPI.Core.Dtos;
using NodeManagementAPI.Core.Dtos.ExamDTO;
using NodeManagementAPI.Core.Dtos.NodeDTO;
using NodeManagementAPI.Core.Dtos.NodeTypeDTO;
using NodeManagementAPI.Core.Entities.ExamEntities;
using NodeManagementAPI.Core.Entities.OrgManagementEntities;
using NodeManagementAPI.Core.IRepositories;
using NodeManagementAPI.Services.Contract.INodeTypeContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeManagementAPI.Services.Implementation.NodeTypeImplementations
{
    public class NodeTypeService : INodeTypeService
    {
        private IRepository<NodeType> _nodeTypeRepo;
        private readonly IMapper _mapper;

        public NodeTypeService(IRepository<NodeType> nodeTypeRepo, IMapper mapper)
        {
            _nodeTypeRepo = nodeTypeRepo;
            _mapper = mapper;
        }
        async Task<ResultDto> INodeTypeService.AddNodeType(AddNodeTypeDTO addNodeTypeDTO)
        {
            try
            {
                var nodeType = _mapper.Map<NodeType>(addNodeTypeDTO);
                var result = await _nodeTypeRepo.AddAsync(nodeType);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        async Task<ResultDto> INodeTypeService.DeleteNodeType(int Id)
        {
            try
            {
                var nodeType = await _nodeTypeRepo.GetByIdAsync(Id);
                if (nodeType != null)
                {
                    var result = await _nodeTypeRepo.RemoveAsync(Id);

                    return result;
                }
                return new ResultDto { Succeeded = false, Message = "Node Type not found." };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        async Task<List<NodeTypeResponseDTO>> INodeTypeService.GetAllNodeTypes()
        {
            try
            {
                var nodeTypes = await _nodeTypeRepo.GetAllAsync();
                var dtoList = nodeTypes.Select(nodeType => _mapper.Map<NodeTypeResponseDTO>(nodeType));
                return dtoList.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        async Task<NodeTypeResponseDTO> INodeTypeService.GetNodeTypeById(int Id)
        {
            try
            {
                var nodeType = await _nodeTypeRepo.GetByIdAsync(Id);
                if (nodeType == null)
                {
                    throw new Exception("Node Type not found");
                }

                var nodeTypeDto = _mapper.Map<NodeTypeResponseDTO>(nodeType);

                return nodeTypeDto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        async Task<ResultDto> INodeTypeService.UpdateNodeType(NodeTypeResponseDTO updateNodeType)
        {
            try
            {
                var nodeType = await _nodeTypeRepo.GetByIdAsync(updateNodeType.Id);
                if (nodeType == null)
                {
                    return new ResultDto { Succeeded = false, Message = "Node Type not found." };
                }
                nodeType.TypeOfNode = updateNodeType.TypeOfNode;
                var result = await _nodeTypeRepo.UpdateAsync(nodeType);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
