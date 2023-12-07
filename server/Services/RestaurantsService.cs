


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
    Restaurant restaurant = GetRestaurantById(restaurantId, userId);

    if (restaurant.CreatorId != userId)
    {
      throw new Exception("NOT YOUR RESTAURANT");
    }

    _repository.DestroyRestaurant(restaurantId);

    return $"{restaurant.Name} has been deleted!";
  }

  internal Restaurant GetRestaurantById(int restaurantId, string userId)
  {
    Restaurant restaurant = _repository.GetRestaurantById(restaurantId);

    if (restaurant == null)
    {
      throw new Exception($"Invalid Id: {restaurantId}");
    }

    if (restaurant.IsShutDown == true && restaurant.CreatorId != userId)
    {
      throw new Exception("Something went wrong... 😉");
    }

    return restaurant;
  }

  internal Restaurant GetRestaurantByIdAndIncrementVisits(int restaurantId, string userId)
  {
    Restaurant restaurant = GetRestaurantById(restaurantId, userId);
    restaurant.Visits++;
    _repository.UpdateRestaurant(restaurant);
    return restaurant;
  }

  internal List<Restaurant> GetRestaurants(string name, string userId)
  {
    // if (name == null)
    // {
    //   List<Restaurant> restaurants = _repository.GetRestaurants();
    //   restaurants = restaurants.FindAll(restaurant => restaurant.IsShutDown == false || restaurant.CreatorId == userId);
    //   return restaurants;
    // }
    // List<Restaurant> restaurantsWithQuery = _repository.GetRestaurantsWithQuery(name);
    // restaurantsWithQuery = restaurantsWithQuery.FindAll(restaurant => restaurant.IsShutDown == false || restaurant.CreatorId == userId);
    // return restaurantsWithQuery;

    List<Restaurant> restaurants = name == null ? _repository.GetRestaurants() : _repository.GetRestaurantsWithQuery(name);
    restaurants = restaurants.FindAll(restaurant => restaurant.IsShutDown == false || restaurant.CreatorId == userId);
    return restaurants;

  }


  internal Restaurant UpdateRestaurant(int restaurantId, string userId, Restaurant restaurantData)
  {
    Restaurant restaurantToUpdate = GetRestaurantById(restaurantId, userId);

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