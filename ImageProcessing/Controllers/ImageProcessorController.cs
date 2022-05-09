using Microsoft.AspNetCore.Mvc;

namespace ImageProcessing.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImageProcessorController : ControllerBase
    {
        
        private readonly ILogger<ImageProcessorController> _logger;

        private IImageOperationServiceCollection _imageOperationServiceCollection;

        public ImageProcessorController(ILogger<ImageProcessorController> logger, IImageOperationServiceCollection imageOperationServiceCollection)
        {
            _logger = logger;
            _imageOperationServiceCollection = imageOperationServiceCollection;
        }


        /// <summary>
        /// This method can be processed multiple Imgages with multiple effects
        /// </summary>
        /// <param name="imageProcessingRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ImageProcessingResponse> ProsessImagesAsync([FromBody] ImageProcessingRequest imageProcessingRequest)
        {
            List<Task> tasks = new List<Task>();
            ImageProcessingResponse respone = new ImageProcessingResponse();
            respone.Images = new List<ImageEntity>();

            if (imageProcessingRequest != null && imageProcessingRequest.Images != null)
            {
                foreach (var image in imageProcessingRequest.Images)
                {
                    Task<ImageEntity> result = _imageOperationServiceCollection.PerformOperations(image);
                    tasks.Add(result);
                }

                await Task.WhenAll(tasks);

                foreach (var task in tasks)
                {
                    respone.Images.Add(((Task<ImageEntity>)task).Result);
                }

            }

            return respone;
        }
    }
}