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

  async getRestaurantById(restaurantId) {
    const res = await api.get(`api/restaurants/${restaurantId}`)
    logger.log('GOT RESTY', res.data)
    const newRestaurant = new Restaurant(res.data)
    AppState.activeRestaurant = newRestaurant
  }

  async updateRestaurant(restaurantId, restaurantData) {
    const res = await api.put(`api/restaurants/${restaurantId}`, restaurantData)
    logger.log('UPDATED RESTY', res.data)
    const newRestaurant = new Restaurant(res.data)
    AppState.activeRestaurant = newRestaurant
  }

  async destroyRestaurant(restaurantId) {
    const res = await api.delete(`api/restaurants/${restaurantId}`)
    logger.log('DESTROYED RESTY', res.data)
    AppState.activeRestaurant = null
  }
}

export const restaurantsService = new RestaurantsService()