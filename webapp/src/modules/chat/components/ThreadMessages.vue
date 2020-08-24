<template>
  <div>
    <h2 class="title is-2">Thread Messages</h2>
    <message author="Albert" message="Alles Supper, toll" />
    <message author="Gregor" message="Nichts ist toll" />
    <message author="JvPeek" message="Keiner hat recht" />
    <message author="Heiner" message="Was?" />
  </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import Message from "./Message.vue";
export default defineComponent({
  components: {
    Message
  }
});
</script>

<style lang="scss">
</style>
