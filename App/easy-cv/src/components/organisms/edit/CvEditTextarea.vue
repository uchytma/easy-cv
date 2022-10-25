<template>
  <CvEditWrapper
    :remove="() => store.itemRemove(props.selectedItem)"
    :move-up="() => store.itemMoveUp(props.selectedItem)"
    :move-down="() => store.itemMoveDown(props.selectedItem)"
  >
    <CvEditGroup>
      <TextareaInput v-model="item.text" title="Text (HTML):" id="title" />
    </CvEditGroup>
  </CvEditWrapper>
</template>
<script lang="ts" setup>
import type { SelectedItem } from "@/stores/mainApp";
import { computed } from "vue";
import CvEditWrapper from "./CvEditWrapper.vue";
import { useMainAppStore } from "@/stores/mainApp";
import type { CvModelItemTextarea } from "@/services/cvModel/cvModel";
import CvEditGroup from "./CvEditGroup.vue";
import TextareaInput from "../../molecules/inputs/TextareaInput.vue";

const store = useMainAppStore();

const props = defineProps<{
  selectedItem: SelectedItem;
}>();

const item = computed(() => props.selectedItem.item as CvModelItemTextarea);
</script>
