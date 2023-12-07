<template>
  <div>
    {{ reportProp.title }}
  </div>
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


<style lang="scss" scoped></style>