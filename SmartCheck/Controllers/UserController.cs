
using System.Web.Http;

namespace SmartChef.Controllers
{
    /// <summary>
    /// User Controller
    /// </summary>
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        /// <summary>
        /// Gets the Username
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetUserName")]
        public IHttpActionResult GetUsername(string userName)
        {
            if(userName=="1")
            throw new System.Exception("An error has occured");
            return Ok("Hi");
        }
    }
}