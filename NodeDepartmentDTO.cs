using NodeManagementAPI.Core.Dtos.PagingDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeManagementAPI.Core.Dtos.NodeDTO
{
    public class NodeDepartmentDTO : IPagingParent
    {
        public int Id { get; set; }
        public string NameEn { get; set; }
        public double Percentage { get; set; }
        public int ChildrenCount { get; set; }
    }

}
