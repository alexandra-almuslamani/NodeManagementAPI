# Web Application Project Overview
---
- The full web application project was developed with a team; this repo showcases my Backend (APIs, DTOs, services, controllers, and methods that I personally implemented) only.
- In addition to backend development, I contributed to building the user interface using HTML, CSS, JavaScript, and Bootstrap within the MVC views.

### Tech Stack
- ASP.NET Core Web API
- ASP.NET MVC
- Onion Architecture (`Core Layer(Domain)` | `Infrastructure Layer` | `Service Layer` | `Presentation Layer(API)` | `Web Layer(UI)`)
- Entity Framework Core
- AutoMapper

## Node & Structure Management
### ✅ Node
Helps to create nodes that form the hierarchical structure of something.

#### 📌 What I completed :  
| Endpoint | Route | Method | Description |
|----------|-------|--------|-------------|
| Add Node | `/api/node/AddNode` | POST | Adds a new node |
| Add Root Node | `/api/node/AddRootNode` | POST | Adds a new root node without any parent |
| Update Node | `/api/node/UpdateNode` | PUT | Updates the details of an existing node |
| Delete Node | `/api/node/DeleteNode{Id}` | DELETE | Remove a node |
| Get All Nodes | `/api/node/GetAllNodes` | GET | Retrieves a list of all nodes in the system |
| Get Node By Id | `/api/node/GetNodeById/{Id}` | GET | Fetches a specific node by its ID |
| Get Node By Name | `/api/node/GetNodeByName` | GET | Fetches a node based on its name |
| Get Children By Parent Id | `/api/node/GetChildrenByParentId/{parentId}` | GET | Retrieves the direct children of a node |
| Get All Descendants By Parent Id | `/api/node/GetAllDescendantsByParentId/{parentId}` | GET | Retrieves all descendants (children, grandchildren, etc.) of a node |


#### 🔎 Related Classes :  
  - `Node.cs` - 🔗 [code](https://github.com/alexandra-almuslamani/NodeManagementAPI/blob/df14ca6a9139963b88f3d1707260431772c4e919/Node.cs)  
  - `AddNodeDTO.cs` - 🔗 [code](https://github.com/alexandra-almuslamani/NodeManagementAPI/blob/df14ca6a9139963b88f3d1707260431772c4e919/AddNodeDTO.cs)
  - `NodeIdResponseDTO.cs` - 🔗 [code](https://github.com/alexandra-almuslamani/NodeManagementAPI/blob/df14ca6a9139963b88f3d1707260431772c4e919/NodeIdResponseDTO.cs)
  - `NodeResponseDTO.cs` - 🔗 [code](https://github.com/alexandra-almuslamani/NodeManagementAPI/blob/df14ca6a9139963b88f3d1707260431772c4e919/NodeResponseDTO.cs)
  - `UpdateNodeDTO.cs` - 🔗 [code](https://github.com/alexandra-almuslamani/NodeManagementAPI/blob/df14ca6a9139963b88f3d1707260431772c4e919/UpdateNodeDTO.cs)  
  - `NodeDepartmentDTO.cs` - 🔗 [code](https://github.com/alexandra-almuslamani/NodeManagementAPI/blob/df14ca6a9139963b88f3d1707260431772c4e919/NodeDepartmentDTO.cs)
  - `INodeService.cs` - 🔗 [code](https://github.com/alexandra-almuslamani/NodeManagementAPI/blob/df14ca6a9139963b88f3d1707260431772c4e919/INodeService.cs)  
  - `NodeService.cs` - 🔗 [code](https://github.com/alexandra-almuslamani/NodeManagementAPI/blob/df14ca6a9139963b88f3d1707260431772c4e919/NodeService.cs)
  - `NodeController.cs` - 🔗 [code](https://github.com/alexandra-almuslamani/NodeManagementAPI/blob/df14ca6a9139963b88f3d1707260431772c4e919/NodeController.cs)  

<hr>

### ✅ Type of Node
Define different node categories based on their roles or purposes within the hierarchical structure.

#### 📌 What I completed :  
| Endpoint | Route | Method | Description |
|----------|-------|--------|-------------|
| Add Node Type | `/api/nodetype/AddNodeType` | POST | Adds a new node type |
| Update Node Type | `/api/nodetype/UpdateNodeType` | PUT | Updates the details of an existing node type |
| Delete Node Type | `/api/nodetype/DeleteNodeType{Id}` | DELETE | Remove a node type |
| Get All Node Types | `/api/nodetype/GetAllNodeType` | GET | Retrieves a list of all existing node types |
| Get Node Type By Id | `/api/nodetype/GetNodeTypeById{Id}` | GET | Retrieves the details of a node type |


#### 🔎 Related Classes :  
  - `NodeType.cs` - 🔗 [code](https://github.com/alexandra-almuslamani/NodeManagementAPI/blob/df14ca6a9139963b88f3d1707260431772c4e919/NodeType.cs)
  - `NodeTypeResponseDTO.cs` - 🔗 [code](https://github.com/alexandra-almuslamani/NodeManagementAPI/blob/df14ca6a9139963b88f3d1707260431772c4e919/NodeTypeResponseDTO.cs)
  - `AddNodeTypeDTO.cs` - 🔗 [code](https://github.com/alexandra-almuslamani/NodeManagementAPI/blob/df14ca6a9139963b88f3d1707260431772c4e919/AddNodeTypeDTO.cs)  
  - `INodeTypeService.cs` - 🔗 [code](https://github.com/alexandra-almuslamani/NodeManagementAPI/blob/df14ca6a9139963b88f3d1707260431772c4e919/INodeTypeService.cs)
  - `NodeTypeService.cs` - 🔗 [code](https://github.com/alexandra-almuslamani/NodeManagementAPI/blob/df14ca6a9139963b88f3d1707260431772c4e919/NodeTypeService.cs)
  - `NodeTypeController.cs` - 🔗 [code](https://github.com/alexandra-almuslamani/NodeManagementAPI/blob/df14ca6a9139963b88f3d1707260431772c4e919/NodeTypeController.cs)  

<hr>

#### Other classes:
  - `IRepository.cs` - 🔗 [code](https://github.com/alexandra-almuslamani/NodeManagementAPI/blob/df14ca6a9139963b88f3d1707260431772c4e919/IRepository.cs)  
  - `GenericRepository.cs` - 🔗 [code](https://github.com/alexandra-almuslamani/NodeManagementAPI/blob/df14ca6a9139963b88f3d1707260431772c4e919/GenericRepository.cs)  
  - `MapperProfile.cs` - 🔗 [code](https://github.com/alexandra-almuslamani/NodeManagementAPI/blob/df14ca6a9139963b88f3d1707260431772c4e919/MapperProfile.cs)  
  - `Program.cs` - 🔗 [code](https://github.com/alexandra-almuslamani/NodeManagementAPI/blob/df14ca6a9139963b88f3d1707260431772c4e919/Program.cs)  


🔸 My contributions include:
- Designed and implemented Node API endpoints, services, DTOs, and hierarchical node logic (parent/children relationships).
- Developed MVC views for the frontend, integrating backend APIs seamlessly.
- Built and styled UI components: forms, tables, modals, and interactive elements using HTML, CSS, Bootstrap, and JavaScript.
