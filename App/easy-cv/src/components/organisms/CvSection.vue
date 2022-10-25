<template>
  <section class="section-wrapper">
    <div class="header-and-first-item-wrapper">
      <CvItem
        :selected="actualSelectedItem === props.section.header"
        @click="headerClick(props.section.header, $event)"
        :item="props.section.header"
      />
      <CvItem
        :selected="actualSelectedItem === props.section.items[0]"
        @click="headerClick(props.section.items[0], $event)"
        v-if="props.section.items.length > 0"
        :item="props.section.items[0]"
      />
    </div>
    <template v-for="(item, index) in props.section.items" :key="item.guid">
      <CvItem
        :selected="actualSelectedItem === item"
        @click="headerClick(item, $event)"
        class="item-wrapper"
        v-if="index != 0"
        :item="item"
      />
    </template>
  </section>
</template>

<script lang="ts" setup>
import type { CvModelItem, CvModelSection } from "@/services/cvModel/cvModel";
import CvItem from "../molecules/CvItem.vue";
import type { EventItemSelected } from "@/services/domUtils/eventItemSelected";
const props = defineProps<{
  section: CvModelSection;
  actualSelectedItem: CvModelItem | null;
}>();

const emits = defineEmits<{
  (e: "onItemSelected", event: EventItemSelected): void;
}>();

function headerClick(item: CvModelItem, event: Event): void {
  const target = event.currentTarget as HTMLElement;
  emits("onItemSelected", {
    item: item,
    htmlElement: target,
  });
}
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

@media print {
  .section-wrapper,
  .section-wrapper > *,
  .header-and-first-item-wrapper > * {
    border: none !important;
  }

  .section-wrapper {
    display: block !important; /* hack required for 'break-inside: avoid' */
  }

  .section-wrapper:not(:last-of-type) {
    padding-bottom: 1rem; /* padding do not apply for last item - because it can cause empty last page when print */
  }

  .header-and-first-item-wrapper,
  .item-wrapper {
    break-inside: avoid;
  }
}
</style>
