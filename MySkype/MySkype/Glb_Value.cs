using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySkype
{
    public static class Glb_Value
    {
        public static string Account { get; set; }//当前登录者的账号
        public static string ServerIp { get; set; }//166.111.140.14
        public static int ServerPort { get; set; }//8000
        public static bool login_cls { get; set; }

        public static string Chat_Frd { get; set; }
    }
}
