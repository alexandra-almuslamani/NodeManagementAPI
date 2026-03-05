using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NodeManagementAPI.Core.Dtos.ExamDTO;
using NodeManagementAPI.Core.Dtos.NodeDTO;
using NodeManagementAPI.Services.Contract.IExamContract;
using NodeManagementAPI.Services.Contract.INodeContracts;

namespace NodeManagementAPI.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NodeController : ControllerBase
    {
        private INodeService _nodeService;
        public NodeController(INodeService nodeService)
        {
            _nodeService = nodeService;
        }

        [HttpPost("AddNode")]
        public async Task<IActionResult> AddNode(AddNodeDTO addNode)
        {
            var result = await _nodeService.AddNode(addNode);

            if (result.Succeeded)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("AddRootNode")]
        public async Task<IActionResult> AddRootNode(AddNodeDTO addNode)
        {
            var result = await _nodeService.AddRootNode(addNode);

                return Ok(result);

        }


        [HttpDelete("DeleteNode{Id}")]
        public async Task<IActionResult> DeleteNode(int Id)
        {
            var result = await _nodeService.DeleteNode(Id);

            if (result.Succeeded)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetAllNodes")]
        public async Task<ActionResult<List<NodeResponseDTO>>> GetAllNodes()
        {
            var result = await _nodeService.GetAllNodes();

            if (result.Count != 0)
            {
                return result.ToList();
            }
            return BadRequest("Nodes List is Empty!");
        }

        [HttpGet("GetNodeById/{Id}")]
        public async Task<ActionResult<NodeResponseDTO>> GetNodeById(int Id)
        {
            var result = await _nodeService.GetNodeById(Id);

            if (result != null)
            {
                return result;
            }
            return BadRequest("Node Not Found!");
        }

        [HttpGet("GetNodeByName")]
        public async Task<ActionResult<UpdateNodeDTO>> GetNodeByName(string name)
        {
            var result = await _nodeService.GetNodeByName(name);

            if (result != null)
            {
                return result;
            }
            return BadRequest("Node Not Found!");
        }

        [HttpPut("UpdateNode")]
        public async Task<IActionResult> UpdateNode(UpdateNodeDTO updateNode)
        {
            var result = await _nodeService.UpdateNode(updateNode);
            if (result.Succeeded)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet("GetChildrenByParentId/{parentId}")]
        public async Task<ActionResult<List<NodeResponseDTO>>> GetChildrenByParentId(int parentId)
        {
            var result = await _nodeService.GetChildrenByParentId(parentId);
            if (result.Count != 0)
            {
                return result.ToList();
            }
            return BadRequest("There is no children for this node!");
        }

        [HttpGet("GetAllDescendantsByParentId/{parentId}")]
        public async Task<ActionResult<List<NodeResponseDTO>>> GetAllDescendantsByParentId(int parentId)
        {
            var result = await _nodeService.GetAllDescendantsByParentId(parentId);
            if (result.Count != 0)
            {
                return result.ToList();
            }
            return BadRequest("There is no children for this node!");
        }
    }
}
