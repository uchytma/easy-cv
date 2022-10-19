<template>
  <div class="main-layout" :style="MainLayoutStyles">
    <nav class="nav"><AppNav /></nav>
    <main class="main"><AppMain /></main>
    <aside class="aside"><AppAside /></aside>
  </div>
</template>

<script lang="ts" setup>
import AppAside from "./components/AppAside.vue";
import AppMain from "./components/AppMain.vue";
import AppNav from "./components/AppNav.vue";
import { useMainAppStore } from "@/stores/mainApp";
import { computed } from "vue";
import type { CSSProperties } from "vue";

const store = useMainAppStore();

const MainLayoutStyles = computed(() => {
  const ret: CSSProperties = {};
  if (store.selectedBackground.imgSrcUrl) {
    ret["background-image"] = `url(${store.selectedBackground.imgSrcUrl})`;
  }
  return ret;
});
</script>

<style lang="css" scoped>
:root {
  --width-nav: 100px;
  --width-main: 700px;
  --width-aside: 400px;
}

.main-layout {
  display: grid;
  grid: min-content auto / 700px auto;
  grid-template-areas:
    "nav nav"
    "main empty";
  min-height: 100vh;
}

.main-layout > .aside {
  display: none;
}

.nav {
  grid-area: nav;
}

.main {
  grid-area: main;
  margin: var(--base-gap);
}

.aside {
  grid-area: aside;
}

@media (min-width: 1100px) {
  .main-layout {
    grid: min-content auto / 700px 400px auto;
    grid-template-areas:
      "nav nav nav"
      "main aside empty";
  }

  .main-layout > .aside {
    display: block;
  }
}

@media (min-width: 1300px) {
  .main-layout {
    grid: auto / auto 700px 400px;
    grid-template-areas: "nav main aside";
  }
}

@media (min-width: 1500px) {
  .main-layout {
    grid: auto / 1fr 700px 1fr;
    grid-template-areas: "nav main aside";
  }
}

@media print {
  .main-layout {
    grid: auto / auto;
    grid-template-areas: "main";
  }

  .nav,
  .aside {
    display: none;
  }
}
</style>
