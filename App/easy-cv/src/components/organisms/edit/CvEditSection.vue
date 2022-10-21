<template>
  <p class="edit-wrapper">{{ props.selectedItem.item.guid }}</p>
</template>

<script lang="ts" setup>
import type { SelectedItem } from "@/stores/mainApp";

const props = defineProps<{
  selectedItem: SelectedItem;
}>();
</script>

<style lang="css" scoped>
.edit-wrapper {
  padding: var(--base-gap);
}
</style>
