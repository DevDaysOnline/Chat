<template>
  <h1 class="title is-1">Live Chat zur dev-days-online.de</h1>
  <div class="columns">
    <div class="column is-one-fifth has-background-primary">
      <channels/>
    </div>
    <div class="column auto has-background-success">
      <channel-messages/>
    </div>
    <div class="column auto has-background-warning">
      <thread-messages/>
    </div>
  </div>
</template>

<script lang="ts">
import {defineComponent} from "vue";
import Channels from "./components/Channels.vue";
import ChannelMessages from "./components/ChannelMessages.vue";
import ThreadMessages from "./components/ThreadMessages.vue";

export default defineComponent({
  components: {Channels, ChannelMessages, ThreadMessages}
});
</script>
