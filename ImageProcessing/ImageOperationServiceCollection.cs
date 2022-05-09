namespace ImageProcessing
{
    public class ImageOperationServiceCollection: IImageOperationServiceCollection
    {
        private readonly IConfiguration _config;
        private IEnumerable<IImageOperationService> _injectedImageOperationServices;
        private IEnumerable<string> _mgageEffectServicesPlugIn;
        public ImageOperationServiceCollection(IConfiguration config, IEnumerable<IImageOperationService> ImageOperationServices)
        {
            _config = config;
            _injectedImageOperationServices = ImageOperationServices;
            _mgageEffectServicesPlugIn = GetAppsettingValues("ImgageEffectServicesPlugIn");
        }

        public async Task<ImageEntity> PerformOperations(ImageEntity imageEntity)
        {
            if (imageEntity != null && imageEntity.Effects != null && _mgageEffectServicesPlugIn != null)
            {
                foreach (var serviceType in imageEntity.Effects)
                {
                    if (_mgageEffectServicesPlugIn.Contains(serviceType))
                    {
                        var service = _injectedImageOperationServices.Where(x => x.ServiceType == serviceType).FirstOrDefault();
                        if (service != null)
                        {
                            imageEntity = await service.PerformOperationAysnc(imageEntity);
                        }

                    }
                }
            }
            return imageEntity;
        }

        public IEnumerable<string> GetAppsettingValues(string key)
        {
            var result = _config.GetValue<string>(key);
            return result.ToString().Split("||");
        }

    }
}
