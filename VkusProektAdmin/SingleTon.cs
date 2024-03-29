﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkusProektAdmin.Connections;
using VkusProektAdmin.Models;

namespace VkusProektAdmin
{
    public static class SingleTon
    {
        public static Users User { get; set; }

        public static Order Order { get; set; }
        public static OrderDetail OrderDetail { get; set; }
        public static AppDBContext DB { get; set; }

        public static VkusProektContext DBvkus { get; set; }
        static SingleTon()
        {
            DB = new AppDBContext();
            DBvkus= new VkusProektContext();
        }
    }
}
