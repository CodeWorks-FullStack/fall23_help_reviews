<template>
  <div class="container-fluid">
    <section class="row mt-3">
      <div v-for="restaurant in restaurants" :key="restaurant.id" class="col-12 col-md-4 mb-3">
        <RestaurantCard :restaurantProp="restaurant" />
      </div>
    </section>
  </div>
</template>

<script>
import Pop from '../utils/Pop.js';
import { restaurantsService } from '../services/RestaurantsService.js'
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState.js'
import RestaurantCard from '../components/RestaurantCard.vue';

export default {
  setup() {
    async function getRestaurants() {
      try {
        await restaurantsService.getRestaurants();
      }
      catch (error) {
        Pop.error(error);
      }
    }
    onMounted(() => {
      getRestaurants();
    });
    return {
      restaurants: computed(() => AppState.restaurants)
    };
  },
  components: { RestaurantCard }
}
</script>

<style scoped lang="scss"></style>
