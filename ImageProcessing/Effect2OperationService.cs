namespace ImageProcessing
{
    public class Effect2OperationService : IImageOperationService
    {
        public string ServiceType { get; set; }

        public Effect2OperationService()
        {
            ServiceType = "Effect2";
        }

        public async Task<ImageEntity> PerformOperationAysnc(ImageEntity imageEntity)
        {
            // Perform operation on image and return the updated image object
            imageEntity.Name = imageEntity.Name + "+" + this.ServiceType;

            return imageEntity;
        }

    }
}
