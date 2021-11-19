using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Api.Models
{
    public class RecordModel
    {
        public Guid id { get; set; }
        public Guid RoomId { get; set; }
        public RoomModel Room { get; set; }
        public Guid UserId { get; set; }
        public UserModel User { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public override bool Equals(object obj)
        {
            if (obj is RecordModel)
            {
                var thatObj = obj as RecordModel;
                return this.id == thatObj.id
                    && this.RoomId == thatObj.RoomId
                    && this.UserId == thatObj.UserId
                    && this.CheckIn == thatObj.CheckIn
                    && this.CheckOut == thatObj.CheckOut;
            }
            else return base.Equals(obj);
        }
    }
}
