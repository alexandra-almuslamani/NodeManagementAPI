using AutoMapper;
using NodeManagementAPI.Core.Dtos;
using NodeManagementAPI.Core.Dtos.NodeDTO;
using NodeManagementAPI.Core.Entities.CoursesEntities;
using NodeManagementAPI.Core.Entities.OrgManagementEntities;
using NodeManagementAPI.Core.Entities.StatusEntities;
using NodeManagementAPI.Core.IRepositories;
using NodeManagementAPI.Services.Contract.IILOContract;
using NodeManagementAPI.Services.Contract.INodeContracts;
using NodeManagementAPI.Services.Implementation.ILOImplementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NodeManagementAPI.Services.Implementation.NodeImplementations
{
    public class NodeService : INodeService
    {
        private IRepository<Node> _nodeRepo;
        private readonly IMapper _mapper;
        private readonly IILOServices _iloService;

        public NodeService(IILOServices iloService,IRepository<Node> repository , IMapper mapper)
        {
            _nodeRepo = repository;
            _mapper = mapper;
            _iloService = iloService;
        }

        public async Task<ResultDto> AddNode(AddNodeDTO addNodeDTO)
        {
            try
            {
                var existingNode = await _nodeRepo.GetByConditionAsync(
                    t => t.ParentId == addNodeDTO.ParentId &&
                    (t.NameAr == addNodeDTO.NameAr || t.NameEn == addNodeDTO.NameEn));
                var existNode = existingNode?.FirstOrDefault();

                if (existNode != null)
                {
                    // restore node in deleted status to active
                    if (existNode != null && existNode.StatusId == 4 && existNode.NameAr == addNodeDTO.NameAr 
                        && existNode?.NameEn.ToLower() == addNodeDTO.NameEn.ToLower())
                    {
                        existNode.StatusId = 1;
                        await _nodeRepo.UpdateAsync(existNode);

                        return new ResultDto
                        {
                            Succeeded = true,
                            Message = "Node restored successfully."
                        };
                    }
                    else
                    {
                        return new ResultDto
                        {
                            Succeeded = false,
                            Message = "English or arabic name already exists."
                        };
                    }
                }
                var node = _mapper.Map<Node>(addNodeDTO);
                var result = await _nodeRepo.AddAsync(node);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<NodeIdResponseDTO> AddRootNode(AddNodeDTO nodeDTO)
        {
            try
            {
                var rootNode = new AddNodeDTO
                {
                    NameAr = nodeDTO.NameAr,
                    NameEn = nodeDTO.NameEn,
                    DescriptionAr = nodeDTO.DescriptionAr,
                    DescriptionEn = nodeDTO.DescriptionEn,
                    NodeTypeId = nodeDTO.NodeTypeId,
                    ParentId = nodeDTO.ParentId
                };
                var nodeResponseDTO = _mapper.Map<Node>(rootNode);
                await _nodeRepo.AddAsync(nodeResponseDTO); // add root node
                var nodeIdResponseDTO = _mapper.Map<NodeIdResponseDTO>(nodeResponseDTO);
                return nodeIdResponseDTO; // return root node id
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ResultDto> UpdateRootStatusNode(UpdateNodeDTO updateNode)
        {
            try
            {
                var node = await _nodeRepo.GetByIdAsync(updateNode.Id);
                if (node == null)
                {
                    return new ResultDto { Succeeded = false, Message = "Node not found." };
                }
                node.StatusId = updateNode.StatusId;
                var result = await _nodeRepo.UpdateAsync(node);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResultDto> UpdateNode(UpdateNodeDTO updateNode)
        {
            try
            {
                var node = await _nodeRepo.GetByIdAsync(updateNode.Id);
                if(node == null)
                {
                    return new ResultDto { Succeeded = false, Message = "Node not found." };
                }
                // check exist English & Arabic name under the same parent
                var existingNode = await _nodeRepo.GetByConditionAsync(
                    t => t.ParentId == updateNode.ParentId && t.Id != node.Id &&
                    t.StatusId != 4 &&
                    (t.NameAr == updateNode.NameAr || t.NameEn == updateNode.NameEn));
                if (updateNode.ParentId == null)
                {
                    node.StatusId = updateNode.StatusId;
                }
                if (existingNode.Any() && updateNode.ParentId != null)
                {
                    return new ResultDto
                    {
                        Succeeded = false,
                        Message = "Name already exists."
                    };
                }
                node.NameAr = updateNode.NameAr;
                node.NameEn = updateNode.NameEn;
                node.DescriptionAr = updateNode.DescriptionAr;
                node.DescriptionEn = updateNode.DescriptionEn;
                node.NodeTypeId = updateNode.NodeTypeId;
                node.ParentId = updateNode.ParentId;
                var result = await _nodeRepo.UpdateAsync(node);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResultDto> DeleteNode(int Id)
        {
            try
            {
                var nodeToDelete = await _nodeRepo.GetByIdAsync(Id);
                if (nodeToDelete != null)
                {
                    var children = await _nodeRepo.GetChildrenAsync(Id); 
                    if (children != null && children.Any())
                    {
                        return new ResultDto { Succeeded = false, Message = "Cannot delete Node because it has children. Please delete the children first." };
                    }

                    var result = await _nodeRepo.RemoveAsync(Id);
                    return result;
                }
                return new ResultDto { Succeeded = false, Message = "Node not found." };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<NodeResponseDTO>> GetAllNodes()
        {
            try
            {
                var nodes = await _nodeRepo.GetAllAsync();
                if (nodes == null)
                {
                    return new List<NodeResponseDTO>();
                }
                var AllNodesDto = _mapper.Map<List<NodeResponseDTO>>(nodes);

                return AllNodesDto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<NodeResponseDTO> GetNodeById(int Id)
        {
            try
            {
                var node = await _nodeRepo.GetByIdAsync(Id);
                if (node == null)
                {
                    throw new Exception("Node not found");
                }

                var nodeDto = _mapper.Map<NodeResponseDTO>(node);

                return nodeDto;
            }

            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UpdateNodeDTO> GetNodeByName(string Name)
        {
            try
            {
                var nodes = await _nodeRepo.GetByConditionAsync(n => n.NameAr == Name || n.NameEn == Name);

                if (nodes == null || !nodes.Any())
                {
                    return null;
                }

                var node = nodes.FirstOrDefault();

                var nodeDto = _mapper.Map<UpdateNodeDTO>(node);

                return nodeDto;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<NodeResponseDTO>> GetChildrenByParentId(int parentId)
        {
            try
            {
                var nodes = await _nodeRepo.GetChildrenAsync(parentId);
                if (nodes == null)
                {
                    return new List<NodeResponseDTO>();
                }
                var AllNodesDto = _mapper.Map<List<NodeResponseDTO>>(nodes);

                return AllNodesDto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<NodeResponseDTO>> GetAllDescendantsByParentId(int parentId)
        {
            try
            {
                var allNodesDto = new List<NodeResponseDTO>();
                var nodes =  (await _nodeRepo.GetChildrenAsync(parentId)).ToList();

                if (nodes != null)
                {
                    var currentLevelNodesDto = _mapper.Map<List<NodeResponseDTO>>(nodes);
                    allNodesDto.AddRange(currentLevelNodesDto);

                    // Recursively get children for each node at the current level
                    foreach (var node in nodes)
                    {
                        var childNodes = await GetAllDescendantsByParentId(node.Id);
                        allNodesDto.AddRange(childNodes);
                    }
                }

                return allNodesDto;

            }
            catch(Exception ex)
            {
                   throw ex;
            }
        }

        // Get the Id of last added node 
        public async Task<int?> GetLastAddedNodeId()
        {
            try
            {
                var lastNode = await _nodeRepo.GetAllAsync();
                var lastAddedNode = lastNode.OrderByDescending(n => n.Id).FirstOrDefault();

                return lastAddedNode.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<double> CalculateNodePercentage(int NodeId)
        {
            var ILO = await _iloService.GetILOByNodeId(NodeId);

            if (!ILO.Any())
            {
                return 0;
            }

            double totalNodePercentage = ILO.Count();

            if (totalNodePercentage < 0)
            {
                totalNodePercentage = 0;
            }

            return totalNodePercentage;
        }
    }
}
