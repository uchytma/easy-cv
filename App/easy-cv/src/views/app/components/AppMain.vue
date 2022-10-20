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
import { useMainAppStore } from "@/stores/mainApp";
import CvSection from "@/components/organisms/CvSection.vue";
import type { EventItemSelected } from "@/services/domUtils/eventItemSelected";
import type { CvModelSection } from "@/services/cvModel/cvModel";
const store = useMainAppStore();

function onItemSelected(event: EventItemSelected, section: CvModelSection): void {
  console.log("itemSelected", event, section);
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
