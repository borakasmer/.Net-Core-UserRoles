using System;
using System.Collections.Generic;

namespace DB.Entities
{
    public partial class Roles
    {
        public int Id { get; set; }
        public long? RoleId { get; set; }
        public string RoleName { get; set; }
        public int? GroupId { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual RoleGroups Group { get; set; }
    }
}
