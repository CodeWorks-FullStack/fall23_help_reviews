namespace help_reviews.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RestaurantsController : ControllerBase
{

  private readonly RestaurantsService _restaurantsService;
  private readonly Auth0Provider _auth0Provider;
  public RestaurantsController(RestaurantsService restaurantsService, Auth0Provider auth0Provider)
  {
    _restaurantsService = restaurantsService;
    _auth0Provider = auth0Provider;
  }

  [HttpGet]
  public async Task<ActionResult<List<Restaurant>>> GetRestaurants(string name)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      List<Restaurant> restaurants = _restaurantsService.GetRestaurants(name, userInfo?.Id);
      return Ok(restaurants);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }



  [HttpGet("{restaurantId}")]
  public ActionResult<Restaurant> GetRestaurantById(int restaurantId)
  {
    try
    {
      Restaurant restaurant = _restaurantsService.GetRestaurantById(restaurantId);
      return Ok(restaurant);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }



  [Authorize]
  [HttpPost]
  public async Task<ActionResult<Restaurant>> CreateRestaurant([FromBody] Restaurant restaurantData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      restaurantData.CreatorId = userInfo.Id;
      Restaurant restaurant = _restaurantsService.CreateRestaurant(restaurantData);
      return Ok(restaurant);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [Authorize]
  [HttpPut("{restaurantId}")]
  public async Task<ActionResult<Restaurant>> UpdateRestaurant(int restaurantId, [FromBody] Restaurant restaurantData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      Restaurant restaurant = _restaurantsService.UpdateRestaurant(restaurantId, userInfo.Id, restaurantData);
      return Ok(restaurant);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [Authorize]
  [HttpDelete("{restaurantId}")]
  public async Task<ActionResult<string>> DestroyRestaurant(int restaurantId)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      string message = _restaurantsService.DestroyRestaurant(restaurantId, userInfo.Id);
      return Ok(message);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

}