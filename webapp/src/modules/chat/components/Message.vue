<template>
  <div class="columns">
    <div class="author column is-one-fifth">
      {{ author }}
    </div>
    <div class="msg column">
      {{ message }}
    </div>
  </div>
</template>

<script lang="ts">
import {defineComponent} from "vue";

export default defineComponent({
  props: {
    author: String,
    message: String
  }
});
</script>

<style lang="scss">

</style>
