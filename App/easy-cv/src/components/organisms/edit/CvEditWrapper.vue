<template>
  <div class="edit-wrapper">
    <ControlBar class="control-bar" @on-close="store.selectedItem = null">
      <a v-if="props.remove" @click="props.remove" href="javascript:void(0)"><BaseIcon :icon="Icon.Trash" /></a>
      <a v-if="props.moveUp" @click="props.moveUp" href="javascript:void(0)"><BaseIcon :icon="Icon.Up" /></a>
      <a v-if="props.moveDown" @click="props.moveDown" href="javascript:void(0)"><BaseIcon :icon="Icon.Down" /></a>
      <slot name="controls"></slot>
    </ControlBar>
    <div class="items-wrapper">
      <slot></slot>
    </div>
  </div>
</template>

<script lang="ts" setup>
import ControlBar from "../../molecules/ControlBar.vue";
import { Icon } from "@/services/commonTypes/icons";
import BaseIcon from "@/components/atoms/BaseIcon.vue";
import { useMainAppStore } from "@/stores/mainApp";
const props = defineProps<{
  remove: (() => void) | null;
  moveUp: (() => void) | null;
  moveDown: (() => void) | null;
}>();

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
