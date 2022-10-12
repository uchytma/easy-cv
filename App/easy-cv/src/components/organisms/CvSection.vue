<template>
  <section class="section-wrapper">
    <div class="header-and-first-item-wrapper">
      <CvSectionHeader :sectionHeader="props.section.header"></CvSectionHeader>
      <CvItem v-if="props.section.items.length > 0" :item="props.section.items[0]" />
    </div>
    <template v-for="(item, index) in props.section.items" :key="item.guid">
      <CvItem v-if="index != 0" :item="item" />
    </template>
  </section>
</template>

<script lang="ts" setup>
import type { CvModelSection } from "@/services/cvModel/cvModel";
import CvSectionHeader from "../molecules/CvSectionHeader.vue";
import CvItem from "../molecules/CvItem.vue";

const props = defineProps<{
  section: CvModelSection;
}>();
</script>

<style lang="css" scoped>
.section-wrapper {
  display: flex;
  flex-direction: column;
  background-color: var(--color-light-background);
  border: 1px solid var(--color-lines);
  border-radius: var(--border-radius-base);
}

.section-wrapper > *:not(:last-child),
.header-and-first-item-wrapper > *:not(:last-child) {
  border-bottom: 1px solid var(--color-lines);
}
</style>
