using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ASPCore2 {

    [Route("[controller]/[action]")]
    public class AboutController{
        public string Phone(){
            return "89-000-1234";
        }
        public string Address(){
            return "AtHome";
        }
    }
}