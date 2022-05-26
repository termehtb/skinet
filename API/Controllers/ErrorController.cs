using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Errors;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace API.Controllers
{
    [Route("errors/{code}")]
    public class ErrorController: BaseApiController
    {
        public ActionResult Error (int code){
            return  new ObjectResult(new ApiResponse(code));
        }
        
    }
}