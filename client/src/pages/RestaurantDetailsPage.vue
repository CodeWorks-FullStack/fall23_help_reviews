<template>
  <div class="container-fluid">
    <section v-if="restaurant" class="row">
      <div class="col-12">
        <h1>{{ restaurant.name }}</h1>
      </div>
    </section>
    <section v-else class="row">
      Loading...
    </section>
  </div>
</template>


<script>
import { useRoute } from 'vue-router';
import { restaurantsService } from '../services/RestaurantsService.js';
import Pop from '../utils/Pop.js';
import { computed, onMounted, watch } from 'vue';
import { AppState } from '../AppState.js'

export default {
  setup() {
    const route = useRoute()
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
      restaurant: computed(() => AppState.activeRestaurant)
    }
  }
}
</script>


<style lang="scss" scoped></style>