<template>
  <div class="container">
    <section v-if="restaurant" class="row mt-3">
      <div class="col-12">
        <div class="d-flex justify-content-between">
          <h1 class="text-success">{{ restaurant.name }}</h1>
          <p v-if="restaurant.isShutDown" class="fs-1 bg-danger text-light px-3 mb-0"><i class="mdi mdi-close-circle"></i>
            CURRENTLY SHUTDOWN</p>

        </div>
        <img :src="restaurant.imgUrl" class="img-fluid mb-3" alt="Picture of the restaurant">
        <p class="mb-5">{{ restaurant.description }}</p>
      </div>
      <div class="col-md-6">
        <p>{{ restaurant.visits }} recent visits</p>
      </div>
      <div v-if="restaurant.creatorId == account.id" class="col-md-6 text-end">
        <button @click="updateRestaurant()" class="btn btn-success" type="button">
          <i class="mdi mdi-door-open"></i>
          {{ restaurant.isShutDown ? 'Open' : 'Close' }}
        </button>
        <button @click="destroyRestaurant()" class="btn btn-danger ms-3" type="button"><i class="mdi mdi-delete"></i>
          Delete</button>
      </div>
    </section>
    <section v-else class="row">
      <div class="col-12">
        Loading...
      </div>
    </section>
  </div>
</template>


<script>
import { useRoute, useRouter } from 'vue-router';
import { restaurantsService } from '../services/RestaurantsService.js';
import Pop from '../utils/Pop.js';
import { computed, onMounted, watch } from 'vue';
import { AppState } from '../AppState.js'
import { logger } from '../utils/Logger.js';

export default {
  setup() {
    const route = useRoute()
    const router = useRouter()
    const watchableRestaurantId = computed(() => route.params.restaurantId)
    async function getRestaurantById() {
      try {
        const restaurantId = route.params.restaurantId
        await restaurantsService.getRestaurantById(restaurantId)
      } catch (error) {
        Pop.error(error)
      }
    }

    // onMounted(() => {
    //   getRestaurantById()
    // })

    watch(watchableRestaurantId, () => {
      getRestaurantById()
    }, { immediate: true })

    return {
      restaurant: computed(() => AppState.activeRestaurant),
      account: computed(() => AppState.account),
      async updateRestaurant() {
        try {
          const restaurant = AppState.activeRestaurant
          const restaurantData = { isShutDown: !restaurant.isShutDown }
          // logger.log(restaurantData)
          await restaurantsService.updateRestaurant(restaurant.id, restaurantData)
        } catch (error) {
          Pop.error(error)
        }
      },
      async destroyRestaurant() {
        try {
          const restaurant = AppState.activeRestaurant
          const wantsToDelete = await Pop.confirm(`Are you sure you want to delete ${restaurant.name}?`)
          if (!wantsToDelete) { return }

          await restaurantsService.destroyRestaurant(restaurant.id)
          Pop.success(`${restaurant.name} has been destroyed!`)
          router.push({ name: 'Home' })
        } catch (error) {
          Pop.error(error)
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped>
img {
  height: 40vh;
  width: 100%;
  object-fit: cover;
}
</style>