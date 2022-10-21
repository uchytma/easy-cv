<template>
  <div class="aside-wrapper">
    <CvEditItem :selectedItem="store.selectedItem"></CvEditItem>
  </div>
</template>

<script lang="ts" setup>
import CvEditItem from "@/components/organisms/edit/CvEditItem.vue";

import { useMainAppStore } from "@/stores/mainApp";
const store = useMainAppStore();
</script>

<style lang="css" scoped>
.aside-wrapper {
  width: 400px;
}
</style>
