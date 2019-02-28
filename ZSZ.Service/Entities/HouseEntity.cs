using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZSZ.Service.Entities
{
    public class HouseEntity : BaseEntity
    {
        public long CommunityId { get; set; }
        public virtual CommunityEntity CommunityEntity { get; set; }
        public long RoomTypeId { get; set; }
        public virtual IdNamesEntity RoomTypeEntity { get; set; }
        public string Address { get; set; }
        public int MonthRent { get; set; }
        public long StatusId { get; set; }
        public virtual IdNamesEntity StatusEntity { get; set; }
        public double Area { get; set; }
        public long DecorateStatusId { get; set; }
        public virtual IdNamesEntity DecorateStatusEntity { get; set; }
        public int TotalFloorCount { get; set; }
        public int FloorIndex { get; set; }
        public long TypeId { get; set; }
        public virtual IdNamesEntity HouseTypeEntity { get; set; }
        public string Direction { get; set; }
        public DateTime LookableDateTime { get; set; }
        public DateTime CheckInDateTime { get; set; }
        public string OwnerName { get; set; }
        public string OwnerPhoneNum { get; set; }
        public string Description { get; set; }

        public virtual ICollection<AttachmentEntity> AttachmentEntities { get; set; } = new List<AttachmentEntity>();
    }
}
