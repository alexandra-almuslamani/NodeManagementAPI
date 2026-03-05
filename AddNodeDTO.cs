using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeManagementAPI.Core.Dtos.NodeDTO
{
    public class AddNodeDTO
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }
        public int? ParentId { get; set; }
        public int NodeTypeId { get; set; }

    }
}
