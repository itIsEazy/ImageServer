namespace ImageServer.Controllers
{
    using System;
    using System.Diagnostics;
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
            var watch = new Stopwatch();
            watch.Start();

            bool first = await this.pathFinder.PathExistsRecursive(parts, nodeService.GetRootNode());
            bool second = await this.pathFinder.PathExistsWhileLoop(parts, nodeService.GetRootNode());

            if (second == true)
            {
                byte[] b = System.IO.File.ReadAllBytes(@"C:\Users\35989\Desktop\image.jpg");   // You can use your own method over here.

                watch.Stop();
                Console.WriteLine("Controller timewatch : " + watch.ElapsedMilliseconds);
                return File(b, "image/jpeg");
            }
            return Ok();

            // while(true){fetch('https://localhost:5001/image/hotwheels-premium-24')}
        }
    }
}
