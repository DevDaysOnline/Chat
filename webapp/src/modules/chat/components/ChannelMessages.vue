<template>
  <div>
    <h2 class="title is-2">Channel Messages</h2>
    <message author="Albert" message="Alles Supper, tool" />
    <message author="Gregor" message="Erklär mal was" />
    <message author="JvPeek" message="Ohne LED ist alles blöd." />
    <message author="Heiner" message="foo" />
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
