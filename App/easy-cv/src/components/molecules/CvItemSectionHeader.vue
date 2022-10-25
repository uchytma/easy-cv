<template>
  <header class="section-header cv-item-padding" :id="`item_${props.sectionHeader.guid}`">
    <HeaderText :size="props.sectionHeader.size"> {{ props.sectionHeader.title }}</HeaderText>
    <span class="muted">{{ props.sectionHeader.subtitle }}</span>
  </header>
</template>

<script lang="ts" setup>
import type { CvModelSectionHeader } from "@/services/cvModel/cvModel";
import HeaderText from "../atoms/BaseHeaderText.vue";

const props = defineProps<{
  sectionHeader: CvModelSectionHeader;
}>();
</script>

<style lang="css" scoped>
.section-header {
  display: flex;
  flex-direction: row;
  align-items: baseline;
  gap: 0.8rem;
}
</style>
