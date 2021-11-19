using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Api.Models
{
    public class RoomModel
    {
        public Guid id { get; set; }
        public int Number { get; set; }
        public Guid CategoryId { get; set; }
        public CategoryModel Category { get; set; }
        public string Description { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is RoomModel)
            {
                var thatObj = obj as RoomModel;
                return this.id == thatObj.id
                    && this.Number == thatObj.Number
                    && this.CategoryId == thatObj.CategoryId
                    && this.Description == thatObj.Description;
            }
            else return base.Equals(obj);
        }
    }
}
