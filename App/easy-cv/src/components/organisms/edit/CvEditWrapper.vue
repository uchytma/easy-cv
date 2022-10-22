<template>
  <div class="edit-wrapper">
    <ControlBar @on-close="store.selectedItem = null">
      <slot name="controls"></slot>
    </ControlBar>
    <div class="items-wrapper">
      <slot></slot>
    </div>
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

.items-wrapper {
  display: flex;
  flex-direction: column;
  gap: calc(var(--base-gap) * 0.5);
}
</style>
