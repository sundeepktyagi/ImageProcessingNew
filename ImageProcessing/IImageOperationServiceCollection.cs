namespace ImageProcessing
{
    public interface IImageOperationServiceCollection
    {
        public Task<ImageEntity> PerformOperations(ImageEntity imageEntity);

    }
}
