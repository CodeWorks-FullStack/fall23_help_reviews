




namespace help_reviews.Repositories;

public class RestaurantsRepository
{
  private readonly IDbConnection _db;

  public RestaurantsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Restaurant CreateRestaurant(Restaurant restaurantData)
  {
    string sql = @"
    INSERT INTO 
    restaurants (name, description, imgUrl, creatorId)
    VALUES (@Name, @Description, @ImgUrl, @CreatorId);

    SELECT
    resty.*,
    acc.*
    FROM restaurants resty
    JOIN accounts acc ON acc.id = resty.creatorId
    WHERE resty.id = LAST_INSERT_ID();";

    Restaurant restaurant = _db.Query<Restaurant, Profile, Restaurant>(sql, RestaurantBuilder, restaurantData).FirstOrDefault();

    return restaurant;
  }

  internal void DestroyRestaurant(int restaurantId)
  {
    string sql = "DELETE FROM restaurants WHERE id = @restaurantId LIMIT 1;";
    _db.Execute(sql, new { restaurantId });
  }

  internal Restaurant GetRestaurantById(int restaurantId)
  {
    string sql = @"
    SELECT
    resty.*,
    acc.*
    FROM restaurants resty
    JOIN accounts acc ON acc.id = resty.creatorId
    WHERE resty.id = @restaurantId;";

    Restaurant restaurant = _db.Query<Restaurant, Profile, Restaurant>(sql, RestaurantBuilder, new { restaurantId }).FirstOrDefault();

    return restaurant;
  }

  internal List<Restaurant> GetRestaurants()
  {
    string sql = @"
    SELECT
    resty.*,
    acc.*
    FROM restaurants resty
    JOIN accounts acc ON resty.creatorId = acc.id;";

    // List<Restaurant> restaurants = _db.Query<Restaurant, Profile, Restaurant>(sql, (resty, profile) =>
    // {
    //   resty.Creator = profile;
    //   return resty;
    // }).ToList();
    List<Restaurant> restaurants = _db.Query<Restaurant, Profile, Restaurant>(sql, RestaurantBuilder).ToList();
    return restaurants;
  }

  internal Restaurant UpdateRestaurant(Restaurant restaurantData)
  {
    string sql = @"
    UPDATE restaurants
    SET
    name = @Name,
    description = @Description,
    imgUrl = @ImgUrl,
    isShutDown = @IsShutDown
    WHERE id = @Id LIMIT 1;
    
    SELECT
    resty.*,
    acc.*
    FROM restaurants resty
    JOIN accounts acc ON acc.id = resty.creatorId
    WHERE resty.id = @Id;";

    Restaurant restaurant = _db.Query<Restaurant, Profile, Restaurant>(sql, RestaurantBuilder, restaurantData).FirstOrDefault();

    return restaurant;
  }

  private Restaurant RestaurantBuilder(Restaurant restaurant, Profile profile)
  {
    restaurant.Creator = profile;
    return restaurant;
  }
}