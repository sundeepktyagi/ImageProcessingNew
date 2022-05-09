namespace ImageProcessing
{
    public class Effect1OperationService : IImageOperationService
    {

        public string ServiceType { get; set; }

        public Effect1OperationService()
        {
            ServiceType = "Effect1";
        }

        public async Task<ImageEntity> PerformOperationAysnc(ImageEntity imageEntity)
        {
            // Perform operation on image and return the updated image object
            imageEntity.Name = imageEntity.Name + "+" + this.ServiceType;

            return imageEntity;
        }

    }
}
