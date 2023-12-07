<template>
  <div class="card">
    <img :src="restaurantProp.imgUrl" class="card-img-top" alt="...">
    <div class="card-body">
      <router-link :to="{ name: 'RestaurantDetails', params: { restaurantId: restaurantProp.id } }">
        <p class="card-title fs-5 text-success">{{ restaurantProp.name }}</p>
      </router-link>
      <p class="card-text">{{ restaurantProp.description }}</p>
      <p class="d-flex justify-content-between">
        <span class="fs-5" :title="`${restaurantProp.name} has ${restaurantProp.visits} visits`">
          <i class="mdi mdi-account-multiple fs-3 text-success"></i>
          {{ restaurantProp.visits }}
        </span>
        <span class="fs-5" :title="`${restaurantProp.name} has ${restaurantProp.reportCount} reports`">
          <i class="mdi mdi-file-multiple fs-3 text-success"></i>
          {{ restaurantProp.reportCount }}
        </span>
      </p>
    </div>
  </div>
</template>


<script>
import { Restaurant } from '../models/Restaurant.js';

export default {
  props: {
    restaurantProp: { type: Restaurant, required: true }
  },
  setup() {
    return {}
  }
}
</script>


<style lang="scss" scoped>
img {
  height: 40vh;
  object-fit: cover;
}
</style>