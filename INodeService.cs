using NodeManagementAPI.Core.Dtos;
using NodeManagementAPI.Core.Dtos.NodeDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeManagementAPI.Services.Contract.INodeContracts
{
    public interface INodeService
    {
        public Task<ResultDto> AddNode(AddNodeDTO addNodeDTO);
        public Task<ResultDto> UpdateNode(UpdateNodeDTO updateNode);
        public Task<ResultDto> DeleteNode(int Id);
        public Task<List<NodeResponseDTO>> GetAllNodes();
        public Task<NodeResponseDTO> GetNodeById(int Id);
        public Task<UpdateNodeDTO> GetNodeByName(string Name);
        public Task<List<NodeResponseDTO>> GetChildrenByParentId(int parentId);
        public Task<List<NodeResponseDTO>> GetAllDescendantsByParentId(int parentId);
        // add root node for tenant to help get tenant children
        public Task<NodeIdResponseDTO> AddRootNode(AddNodeDTO nodeDTO);
        public Task<ResultDto> UpdateRootStatusNode(UpdateNodeDTO updateNode);
        //get the id of last added node 
        public Task<int?> GetLastAddedNodeId();
        public Task<double> CalculateNodePercentage(int NodeId);
    }
}
