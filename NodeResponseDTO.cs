using NodeManagementAPI.Core.Dtos.PagingDto;
using NodeManagementAPI.Core.Entities.OrgManagementEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeManagementAPI.Core.Dtos.NodeDTO
{
    public class NodeResponseDTO : IPagingParent
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }
        public int? ParentId { get; set; }
        public int NodeTypeId { get; set; }
    }
}
