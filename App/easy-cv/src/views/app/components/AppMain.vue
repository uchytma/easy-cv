<template>
  <div class="main-wrapper">
    <div v-for="section in store.cvModel.sections" :key="section.guid">
      <CvSection :section="section"></CvSection>
    </div>
  </div>
</template>

<script lang="ts" setup>
import { useMainAppStore } from "@/stores/mainApp";
import CvSection from "@/components/organisms/CvSection.vue";
const store = useMainAppStore();
</script>

<style lang="css" scoped>
.main-wrapper {
  margin-top: 0.6rem;
}
</style>
