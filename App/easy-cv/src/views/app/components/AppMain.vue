<template>
  <div class="main-wrapper">
    <CvSection
      @onItemSelected="(event) => onItemSelected(event, section)"
      v-for="section in store.cvModel.sections"
      :key="section.guid"
      :section="section"
    ></CvSection>
  </div>
</template>

<script lang="ts" setup>
import CvSection from "@/components/organisms/CvSection.vue";
import type { EventItemSelected } from "@/services/domUtils/eventItemSelected";
import type { CvModelSection } from "@/services/cvModel/cvModel";

import { useMainAppStore } from "@/stores/mainApp";
const store = useMainAppStore();

function onItemSelected(event: EventItemSelected, section: CvModelSection): void {
  store.selectedItem = { item: event.item, callerPosition: event.callerPosition, section: section };
}
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
