


namespace help_reviews.Services;

public class RestaurantsService
{
  private readonly RestaurantsRepository _repository;

  public RestaurantsService(RestaurantsRepository repository)
  {
    _repository = repository;
  }

  internal Restaurant CreateRestaurant(Restaurant restaurantData)
  {
    Restaurant restaurant = _repository.CreateRestaurant(restaurantData);
    return restaurant;
  }

  internal string DestroyRestaurant(int restaurantId, string userId)
  {
    Restaurant restaurant = GetRestaurantById(restaurantId);

    if (restaurant.CreatorId != userId)
    {
      throw new Exception("NOT YOUR RESTAURANT");
    }

    _repository.DestroyRestaurant(restaurantId);

    return $"{restaurant.Name} has been deleted!";
  }

  internal Restaurant GetRestaurantById(int restaurantId)
  {
    Restaurant restaurant = _repository.GetRestaurantById(restaurantId);

    if (restaurant == null)
    {
      throw new Exception($"Invalid Id: {restaurantId}");
    }

    return restaurant;
  }

  // TODO query
  internal List<Restaurant> GetRestaurants()
  {
    List<Restaurant> restaurants = _repository.GetRestaurants();
    return restaurants;
  }

  internal Restaurant UpdateRestaurant(int restaurantId, string userId, Restaurant restaurantData)
  {
    Restaurant restaurantToUpdate = GetRestaurantById(restaurantId);

    if (restaurantToUpdate.CreatorId != userId)
    {
      throw new Exception("NOT YOUR RESTAURANT");
    }

    restaurantToUpdate.Name = restaurantData.Name ?? restaurantToUpdate.Name;
    restaurantToUpdate.Description = restaurantData.Description ?? restaurantToUpdate.Description;
    restaurantToUpdate.ImgUrl = restaurantData.ImgUrl ?? restaurantToUpdate.ImgUrl;
    restaurantToUpdate.IsShutDown = restaurantData.IsShutDown ?? restaurantToUpdate.IsShutDown;

    Restaurant restaurant = _repository.UpdateRestaurant(restaurantToUpdate);
    return restaurant;
  }
}