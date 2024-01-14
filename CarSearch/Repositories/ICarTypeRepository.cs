using CarSearch.Model;

namespace CarSearch.Repositories
{
    public interface ICarTypeRepository
    {
        Task<IReadOnlyCollection<CarType>> GetCarTypesAsync();
    }
}
