using DrivingLicenseExam.Infrastructure.Context;
using DrivingLicenseExam.Infrastructure.Entities;

namespace DrivingLicenseExam.Infrastructure.Repository;

public class ImageRepository : IImageRepository
{
    public readonly MainContext _mainContext;

    public ImageRepository(MainContext mainContext)
    {
        _mainContext = mainContext;
    }
    
    public async Task<IEnumerable<Image>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Image> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(Image entity)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(Image entity)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteById(int id)
    {
        throw new NotImplementedException();
    }
}