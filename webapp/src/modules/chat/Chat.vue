<template>
  <div class="columns">
    <div class="column is-one-fifth">
      <channels/>
    </div>
    <div class="column">
      Content
    </div>
  </div>
</template>

<script lang="ts">
import {defineComponent} from "vue";
import Channels from "./components/Channels.vue"
export default defineComponent({
  components: { Channels }
});
</script>
