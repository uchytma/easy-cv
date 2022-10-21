<template>
  <div class="edit-wrapper">
    <ControlBar @on-close="store.selectedItem = null"></ControlBar>
    <slot></slot>
  </div>
</template>

<script lang="ts" setup>
import ControlBar from "../../molecules/ControlBar.vue";

import { useMainAppStore } from "@/stores/mainApp";
const store = useMainAppStore();
</script>

<style lang="css" scoped>
.edit-wrapper {
  display: flex;
  flex-direction: column;
}

.edit-wrapper:deep(> *) {
  padding: var(--base-gap);
}

.edit-wrapper:deep(> *:not(:last-child)) {
  border-bottom: 1px solid var(--color-lines);
}
</style>
