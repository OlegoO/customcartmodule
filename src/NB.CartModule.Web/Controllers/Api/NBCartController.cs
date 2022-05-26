using NB.CartModule.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace NB.CartModule.Web.Controllers.Api
{
    [Route("api/nbcart")]
    public class NBCartController : Controller
    {
        // GET: api/NB.CartModule
        /// <summary>
        /// Get message
        /// </summary>
        /// <remarks>Return "Hello world!" message</remarks>
        [HttpGet]
        [Route("")]
        [Authorize(ModuleConstants.Security.Permissions.Read)]
        public ActionResult<string> Get()
        {
            return Ok(new { result = "Hello world !!" });
        }
    }
}
