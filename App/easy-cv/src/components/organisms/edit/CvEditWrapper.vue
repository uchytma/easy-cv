<template>
  <div class="edit-wrapper">
    <ControlBar class="control-bar" @on-close="store.selectedItem = null">
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

.control-bar {
  padding: var(--base-gap);
  border-bottom: 1px solid var(--color-lines);
}

.items-wrapper {
  display: flex;
  flex-direction: column;
}

.items-wrapper:deep(> *:not(:last-child)) {
  border-bottom: 1px solid var(--color-lines);
}
</style>
