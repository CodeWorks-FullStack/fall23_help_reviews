<template>
  <section class="row justify-content-end p-3 align-items-center">
    <div class="col-12 col-md-6">
      <h3 class="text-success text-center">"{{ reportProp.title }}"</h3>
    </div>
    <div class="col-12 col-md-3">
      <div class="d-flex">
        <div>
          <p class="mb-0">{{ reportProp.creator.name }}</p>
          <p class="mb-0">{{ reportProp.createdAt.toLocaleDateString() }}</p>
        </div>
        <img class="img-fluid creator-picture" :src="reportProp.creator.picture"
          :alt="reportProp.creator.name + `'s picture'`">
      </div>
    </div>
    <div class="col-12">
      <div class="text-center">
        <a :href="reportProp.pictureOfDisgust" target="_blank">
          <img class="pic-of-disgust mb-3" v-if="reportProp.pictureOfDisgust" :src="reportProp.pictureOfDisgust"
            alt="picture of disgust">
        </a>
      </div>
      <p>{{ reportProp.body }}</p>
    </div>
  </section>
</template>


<script>
import { Report } from '../models/Report.js';

export default {
  props: {
    reportProp: { type: Report, required: true }
  },
  setup() {
    return {}
  }
}
</script>


<style lang="scss" scoped>
.creator-picture {
  height: 10vh;
  // width: 10vh;
  aspect-ratio: 1/1;
  border-radius: 50%;
}

.pic-of-disgust {
  width: 70%;
  height: 45vh;
  object-fit: cover;
  // object-position: top;
}

section {
  box-shadow: 0 3px 10px rgb(139, 139, 139);
}
</style>