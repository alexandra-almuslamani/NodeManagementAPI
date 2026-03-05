using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NodeManagementAPI.Core.Dtos.NodeTypeDTO;
using NodeManagementAPI.Services.Contract.INodeTypeContracts;

namespace NodeManagementAPI.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NodeTypeController : ControllerBase
    {
        private INodeTypeService _nodeTypeService;
        public NodeTypeController(INodeTypeService nodeTypeService)
        {
            _nodeTypeService = nodeTypeService;
        }

        [HttpPost("AddNodeType")]
        public async Task<IActionResult> AddNode(AddNodeTypeDTO addNode)
        {
            var result = await _nodeTypeService.AddNodeType(addNode);

            if (result.Succeeded)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("DeleteNodeType{Id}")]
        public async Task<IActionResult> DeleteNode(int Id)
        {
            var result = await _nodeTypeService.DeleteNodeType(Id);

            if (result.Succeeded)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetAllNodeType")]
        public async Task<ActionResult<List<NodeTypeResponseDTO>>> GetAllNodes()
        {
            var result = await _nodeTypeService.GetAllNodeTypes();

            if (result.Count != 0)
            {
                return result.ToList();
            }
            return BadRequest("Node Types List is Empty!");
        }

        [HttpGet("GetNodeTypeById{Id}")]
        public async Task<ActionResult<NodeTypeResponseDTO>> GetNodeById(int Id)
        {
            var result = await _nodeTypeService.GetNodeTypeById(Id);

            if (result != null)
            {
                return result;
            }
            return BadRequest("Node Type Not Found!");
        }

        [HttpPut("UpdateNodeType")]
        public async Task<IActionResult> UpdateNode(NodeTypeResponseDTO updateNode)
        {
            var result = await _nodeTypeService.UpdateNodeType(updateNode);
            if (result.Succeeded)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
