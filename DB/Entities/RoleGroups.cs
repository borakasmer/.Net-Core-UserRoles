using System;
using System.Collections.Generic;

namespace DB.Entities
{
    public partial class RoleGroups
    {
        public RoleGroups()
        {
            Roles = new HashSet<Roles>();
            UserRoles = new HashSet<UserRoles>();
        }

        public int Id { get; set; }
        public string GroupName { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<Roles> Roles { get; set; }
        public virtual ICollection<UserRoles> UserRoles { get; set; }
    }
}
