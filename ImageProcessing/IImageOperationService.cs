namespace ImageProcessing
{
    public interface IImageOperationService
    {
        public string ServiceType { get; set; }


        public Task<ImageEntity> PerformOperationAysnc(ImageEntity imageEntity);
    }
}
