namespace DrivingLicenseExam.Core.DTO;

public class ImageBasicRequestDto
{
    public byte[] Data { get; set; }

    public ImageBasicRequestDto(byte[] data)
    {
        Data = data;
    }
}