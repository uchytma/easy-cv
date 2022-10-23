<template>
  <div class="edit-item-wrapper" v-if="props.selectedItem">
    <component :is="editComponent" :selectedItem="props.selectedItem"></component>
  </div>
</template>

<script lang="ts" setup>
import type { SelectedItem } from "@/stores/mainApp";
import { computed } from "vue";
import CvEditUnsupportedType from "./CvEditUnsupportedType.vue";
import CvEditSection from "./CvEditSection.vue";
import CvEditText from "./CvEditText.vue";
import CvEditTextarea from "./CvEditTextarea.vue";
import CvEditPanel from "./CvEditPanel.vue";
import { CvModelItemType } from "@/services/cvModel/cvModel";
const props = defineProps<{
  selectedItem: SelectedItem | null;
}>();

const editComponent = computed(() => {
  if (props.selectedItem) {
    switch (props.selectedItem.item.type) {
      case CvModelItemType.Header:
        return CvEditSection;
      case CvModelItemType.Text:
        return CvEditText;
      case CvModelItemType.Textarea:
        return CvEditTextarea;
      case CvModelItemType.Panel:
        return CvEditPanel;
    }
  }
  return CvEditUnsupportedType;
});
</script>

<style lang="css" scoped>
.edit-item-wrapper {
  background-color: var(--color-light-background);
  border: 1px solid var(--color-lines);
  border-radius: var(--border-radius-base);
}
</style>
