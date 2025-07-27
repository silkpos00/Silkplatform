using CoreApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        //[Authorize]
        [Authorize(Policy = "AdminOnly")]
        [HttpPost("JWT_Test")]
        public dynamic Test(TestParams param)
        {
            List<TestModel> list = new List<TestModel>();
            TestModel testModel = new TestModel();
            testModel.Book = "EN";
            list.Add(testModel);
            return Ok(list);
        }
    }
}
