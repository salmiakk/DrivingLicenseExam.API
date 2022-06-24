using DrivingLicenseExam.Infrastructure.Repository;

namespace DrivingLicenseExam.Core.Services;

public class ImageService : IImageService
{
    private readonly IImageRepository _imageRepository;

    public ImageService(IImageRepository imageRepository)
    {
        _imageRepository = imageRepository;
    }
}