import { AppState } from "../AppState.js";
import { Restaurant } from "../models/Restaurant.js";
import { logger } from "../utils/Logger.js";
import { api } from "./AxiosService.js"

class RestaurantsService {
  async getRestaurants() {
    const res = await api.get('api/restaurants')
    logger.log('GOT RESTYS', res.data);
    const newRestaurants = res.data.map(pojo => new Restaurant(pojo))
    AppState.restaurants = newRestaurants
  }
}

export const restaurantsService = new RestaurantsService()