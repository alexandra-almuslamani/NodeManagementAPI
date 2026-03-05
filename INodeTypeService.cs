using NodeManagementAPI.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodeManagementAPI.Core.Dtos.NodeTypeDTO;

namespace NodeManagementAPI.Services.Contract.INodeTypeContracts
{
    public interface INodeTypeService
    {
        public Task<ResultDto> AddNodeType(AddNodeTypeDTO addNodeTypeDTO);
        public Task<ResultDto> UpdateNodeType(NodeTypeResponseDTO updateNodeType);
        public Task<ResultDto> DeleteNodeType(int Id);
        public Task<List<NodeTypeResponseDTO>> GetAllNodeTypes();
        public Task<NodeTypeResponseDTO> GetNodeTypeById(int Id);
    }
}
