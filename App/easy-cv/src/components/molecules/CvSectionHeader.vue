<template>
  <header class="section-header">
    <HeaderText :headerText="props.sectionHeader.title" :size="props.sectionHeader.size"></HeaderText>
    <span class="muted">{{ props.sectionHeader.subtitle }}</span>
  </header>
</template>

<script lang="ts" setup>
import type { CvModelSectionHeader } from "@/services/cvModel/cvModel";
import HeaderText from "../atoms/HeaderText.vue";
const props = defineProps<{
  sectionHeader: CvModelSectionHeader;
}>();
</script>

<style lang="css" scoped>
.section-header {
  display: flex;
  flex-direction: row;
  align-items: baseline;
  padding: 1rem 0.6rem;
  gap: 0.8rem;
}
</style>
