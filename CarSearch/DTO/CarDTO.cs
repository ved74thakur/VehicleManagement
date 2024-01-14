namespace CarSearch.DTO
{
    public record GetCarFilterDto(string CarColor, string CarEngineCapacity, string CarFuelType, string CarManuFacYear, int? CarSeating, int? CarTypeId, int? CompanyId, decimal? MinPrice, decimal? MaxPrice);
    public record CarFilterResultDto(string CarName, string CarColor, string CarEngineCapacity, string CarFuelType, string CarManuFacYear, int? CarSeating, int? CarTypeId, string CarTypeName, int? CompanyId, string CarCompanyName, string CarModelName, decimal? MinPrice, decimal? MaxPrice);
}
