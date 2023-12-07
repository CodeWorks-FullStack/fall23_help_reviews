



namespace help_reviews.Repositories;
public class ReportsRepository
{
  private readonly IDbConnection _db;

  public ReportsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Report CreateReport(Report reportData)
  {
    string sql = @"
    INSERT INTO 
    reports(title, body, pictureOfDisgust, creatorId, restaurantId)
    VALUES(@Title, @Body, @PictureOfDisgust, @CreatorId, @RestaurantId);
    
    SELECT
    rep.*,
    acc.*
    FROM reports rep
    JOIN accounts acc ON acc.id = rep.creatorId
    WHERE rep.id = LAST_INSERT_ID();";

    // Report report = _db.Query<Report, Profile, Report>(sql, (report, profile) =>
    // {
    //   report.Creator = profile;
    //   return report;
    // }, reportData).FirstOrDefault();
    Report report = _db.Query<Report, Profile, Report>(sql, ReportBuilder, reportData).FirstOrDefault();
    return report;
  }

  internal void DestroyReport(int reportId)
  {
    string sql = "DELETE FROM reports WHERE id = @reportId LIMIT 1;";

    _db.Execute(sql, new { reportId });
  }

  internal Report GetReportById(int reportId)
  {
    string sql = "SELECT * FROM reports WHERE id = @reportId;";

    Report report = _db.Query<Report>(sql, new { reportId }).FirstOrDefault();
    return report;
  }

  internal List<Report> GetReportsByRestaurantId(int restaurantId)
  {
    string sql = @"
    SELECT
    rep.*,
    acc.*
    FROM reports rep
    JOIN accounts acc ON acc.id = rep.creatorId
    WHERE rep.restaurantId = @restaurantId;";

    List<Report> reports = _db.Query<Report, Profile, Report>(sql, ReportBuilder, new { restaurantId }).ToList();
    return reports;
  }

  private Report ReportBuilder(Report report, Profile profile)
  {
    report.Creator = profile;
    return report;
  }
}