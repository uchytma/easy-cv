<template>
  <div class="main-wrapper">
    <CvSection v-for="section in store.cvModel.sections" :key="section.guid" :section="section"></CvSection>
  </div>
</template>

<script lang="ts" setup>
import { useMainAppStore } from "@/stores/mainApp";
import CvSection from "@/components/organisms/CvSection.vue";
const store = useMainAppStore();
</script>

<style lang="css" scoped>
.main-wrapper {
  display: flex;
  flex-direction: column;
  gap: var(--base-gap);
}

@media print {
  .main-wrapper {
    display: block; /* hack required for 'break-inside: avoid' */
  }
}
</style>
