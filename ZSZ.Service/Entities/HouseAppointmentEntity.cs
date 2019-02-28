using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZSZ.Service.Entities
{
    public class HouseAppointmentEntity : BaseEntity
    {
        public long? UserId{get;set;}
        public virtual User AppointUser { get; set; }
        public string Name { get; set; }
        public string PhoneNum { get; set; }
        public DateTime VisitDate { get; set; }
        public long HouseId { get; set; }

        public virtual HouseEntity House { get; set; }
        public string Status { get; set; }
        public long? FollowAdminUserId { get; set; }
        public AdminUserEntity AdminUser { get; set; }
        public DateTime? FlowDateTime { get; set; }
    }
}
