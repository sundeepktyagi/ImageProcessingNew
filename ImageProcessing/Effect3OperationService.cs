namespace ImageProcessing
{
    public class Effect3OperationService : IImageOperationService
    {
        public string ServiceType { get; set; }

        public Effect3OperationService()
        {
            ServiceType = "Effect3";
        }

        public async Task<ImageEntity> PerformOperationAysnc(ImageEntity imageEntity)
        {
            // Perform operation on image and return the updated image object
            imageEntity.Name = imageEntity.Name + "+" + this.ServiceType;

            return imageEntity;
        }

    }
}
