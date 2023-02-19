using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkusProektAdmin.Models;

namespace VkusProektAdmin
{
    public static class SingleTon
    {
        public static Users User { get; set; }

        public static AppDBContext DB { get; set; }
        static SingleTon()
        {
            DB = new AppDBContext();
        }
    }
}
