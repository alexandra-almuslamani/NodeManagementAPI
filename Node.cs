using NodeManagementAPI.Core.Entities.StatusEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeManagementAPI.Core.Entities.OrgManagementEntities
{
    public class Node : StatusDetailsLog
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }
        public int? ParentId { get; set; }
        public int NodeTypeId { get; set; }
        public Node? Parent { get; set; }
        public NodeType? Type { get; set; }
        public ICollection<Node> Children { get; set; } = new List<Node>();
    }
}
