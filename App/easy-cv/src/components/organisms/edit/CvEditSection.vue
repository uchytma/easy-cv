<template>
  <CvEditWrapper>
    <p>{{ props.selectedItem.item.guid }}</p>
  </CvEditWrapper>
</template>

<script lang="ts" setup>
import type { SelectedItem } from "@/stores/mainApp";

import CvEditWrapper from "./CvEditWrapper.vue";

const props = defineProps<{
  selectedItem: SelectedItem;
}>();
</script>
