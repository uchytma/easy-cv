<template>
  <div class="aside-wrapper" :style="computedStyle">
    <CvEditItem :selectedItem="store.selectedItem"></CvEditItem>
  </div>
</template>

<script lang="ts" setup>
import CvEditItem from "@/components/organisms/edit/CvEditItem.vue";
import { computed, type CSSProperties } from "vue";

import { useMainAppStore } from "@/stores/mainApp";
const store = useMainAppStore();

const computedStyle = computed<CSSProperties>(() => {
  const ret: CSSProperties = {};
  if (store.selectedItem) {
    ret["margin-top"] = `calc(${store.selectedItem.callerPosition.top}px - var(--base-gap))`;
  }
  return ret;
});
</script>

<style lang="css" scoped>
.aside-wrapper {
  max-width: 400px;
}
</style>
