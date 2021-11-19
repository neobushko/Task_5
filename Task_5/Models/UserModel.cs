﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Api.Models
{
    public class UserModel
    {
        public Guid id { get; set; }
        public string Name { get; set; }
        public string ContactPhone { get; set; }
        public string Email { get; set; }
        public override bool Equals(object obj)
        {
            if (obj is UserModel)
            {
                var thatObj = obj as UserModel;
                return this.id == thatObj.id
                    && this.Name == thatObj.Name
                    && this.ContactPhone == thatObj.ContactPhone
                    && this.Email == thatObj.Email;
            }
            else return base.Equals(obj);
        }
    }
}
