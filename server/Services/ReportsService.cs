


namespace help_reviews.Services;
public class ReportsService
{
  private readonly ReportsRepository _repository;
  private readonly RestaurantsService _restaurantsService;

  public ReportsService(ReportsRepository repository, RestaurantsService restaurantsService)
  {
    _repository = repository;
    _restaurantsService = restaurantsService;
  }

  internal Report CreateReport(Report reportData)
  {
    _restaurantsService.GetRestaurantById(reportData.RestaurantId, reportData.CreatorId); // NOTE make sure we pass our conditionals in the other service

    Report report = _repository.CreateReport(reportData);
    return report;
  }

  internal Report GetReportById(int reportId)
  {
    Report report = _repository.GetReportById(reportId);
    if (report == null)
    {
      throw new Exception($"Bad id: {reportId}");
    }
    return report;
  }

  internal string DestroyReport(int reportId, string userId)
  {
    Report report = GetReportById(reportId);
    if (report.CreatorId != userId)
    {
      throw new Exception("NOT YOUR REPORT");
    }
    _repository.DestroyReport(reportId);
    return $"{report.Title} has been deleted!";
  }

  internal List<Report> GetReportsByRestaurantId(int restaurantId, string userId)
  {
    _restaurantsService.GetRestaurantById(restaurantId, userId); // NOTE make sure we pass our conditionals in the other service

    List<Report> reports = _repository.GetReportsByRestaurantId(restaurantId);
    return reports;
  }

}
