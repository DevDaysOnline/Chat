<template>
  <nav class="navbar" role="navigation" aria-label="main navigation">
    <div class="navbar-brand">
      <a class="navbar-item" href="/">
        <img
          src="https://www.dev-days-online.de/dev-days-online-logo.png"
          alt="Logo Dev-Days-Online"
        />
      </a>

      <a
        role="button"
        class="navbar-burger burger"
        aria-label="menu"
        aria-expanded="false"
        data-target="navbarBasicExample"
      >
        <span aria-hidden="true"></span>
        <span aria-hidden="true"></span>
        <span aria-hidden="true"></span>
      </a>
    </div>

    <div id="navbarBasicExample" class="navbar-menu">
      <div class="navbar-start">
        <a class="navbar-item">
          Chat
        </a>

        <a class="navbar-item">
          LiveStream
        </a>
      </div>

      <div class="navbar-end">
        <div class="navbar-item">
          <a class="navbar-item">
            {{ userName }}
          </a>
          <div v-if="showLogin" class="buttons">
            <a class="button is-light" href="/security/login">
              Log in
            </a>
          </div>
        </div>
      </div>
    </div>
  </nav>
</template>

<script lang="ts">
import { defineComponent, ref, computed } from "vue";

export default defineComponent({
  name: "Header",

  setup() {
    const userName = ref("");
    const showLogin = computed(()=> !userName.value);
    return {
      showLogin,
      userName
    }
  },
  async mounted() {
    const response = await fetch("/security/user");
    const data = await response.json();
    this.userName = data.name;
  }
});
</script>
