namespace ImageServer.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using ImageServer.Services;

    [ApiController]
    [Route("image/")]
    public class ImageController : ControllerBase
    {
        private readonly IPathFinder pathFinder;
        private readonly INodeService nodeService;

        public ImageController(
            IPathFinder pathFinder,
            INodeService nodeService)
        {
            this.pathFinder = pathFinder;
            this.nodeService = nodeService;
        }

        [HttpGet("{parts}")]
        public async Task<IActionResult> Get(string parts)
        {
            bool first = await this.pathFinder.PathExistsRecursive(parts, nodeService.GetRootNode());
            bool second = await this.pathFinder.PathExistsWhileLoop(parts, nodeService.GetRootNode());

            if (first == true)
            {
                byte[] b = System.IO.File.ReadAllBytes(@"C:\Users\35989\Desktop\image.jpg");   // You can use your own method over here.         
                return File(b, "image/jpeg");
            }
            return null;

            
        }
    }
}
