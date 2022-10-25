<template>
  <div class="main-layout" :style="MainLayoutStyles">
    <nav class="nav"><AppNav /></nav>
    <main class="main"><AppMain /></main>
    <aside v-if="store.selectedItem" class="aside"><AppAside :style="computedStyle" /></aside>
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

const computedStyle = computed<CSSProperties>(() => {
  const ret: CSSProperties = {};
  const posTop = store.asidePositionTop;
  if (posTop) {
    ret["top"] = `${posTop}px`;
  }
  return ret;
});
</script>

<style lang="css" scoped>
.main-layout {
  display: grid;
  grid: min-content auto / 1fr minmax(auto, 700px) 1fr;
  grid-template-areas:
    "nav nav nav"
    "empty1 main empty2";
  min-height: 100vh;
}

.nav {
  grid-area: nav;
}

.main {
  grid-area: main;
  margin: var(--base-gap);
}

.aside {
  position: fixed; /* Stay in place */
  z-index: 1; /* Sit on top */
  left: 0;
  top: 0;
  width: 100%; /* Full width */
  height: 100%; /* Full height */
  overflow: auto; /* Enable scroll if needed */
  background-color: rgb(0, 0, 0); /* Fallback color */
  background-color: rgba(0, 0, 0, 0.4); /* Black w/ opacity */
}

.aside > * {
  left: calc(50% - 200px);
  top: var(--base-gap);
  position: absolute;
}

@media (min-width: 1120px) {
  .main-layout {
    grid: min-content auto / 700px 420px auto;
    grid-template-areas:
      "nav nav nav"
      "main aside empty";
  }

  .aside {
    grid-area: aside;
    margin-top: var(--base-gap);
    position: initial;
    background-color: unset;
  }

  .aside > * {
    left: unset;
  }

  .main-layout > .aside {
    display: block;
  }
}

@media (min-width: 1300px) {
  .main-layout {
    grid: auto / auto 700px 420px;
    grid-template-areas: "nav main aside";
  }
  .aside {
    margin-right: var(--base-gap);
  }
}

@media (min-width: 1520px) {
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
