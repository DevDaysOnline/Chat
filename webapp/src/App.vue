<template>
  <Header />
  <div class="container">
    <router-view/>
  </div>
</template>
<script lang="ts">
import {defineComponent} from "vue";
import Header from "@/components/Header.vue";

export default defineComponent({
  components: {Header}
})
</script>
<style lang="scss">
@import "mysite";

</style>
