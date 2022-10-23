<template>
  <CvEditWrapper>
    <CvEditGroup>
      <TextareaInput v-model="item.text" title="Text (HTML):" id="title" />
    </CvEditGroup>

    <template #controls>
      <a @click="removeItem" href="javascript:void(0)"><BaseIcon :icon="Icon.Trash" /></a>
    </template>
  </CvEditWrapper>
</template>
<script lang="ts" setup>
import type { SelectedItem } from "@/stores/mainApp";
import { computed } from "vue";
import CvEditWrapper from "./CvEditWrapper.vue";
import BaseIcon from "../../atoms/BaseIcon.vue";
import { Icon } from "@/services/commonTypes/icons";
import { useMainAppStore } from "@/stores/mainApp";
import type { CvModelItemTextarea } from "@/services/cvModel/cvModel";
import CvEditGroup from "./CvEditGroup.vue";
import TextareaInput from "../../molecules/inputs/TextareaInput.vue";

const store = useMainAppStore();

const props = defineProps<{
  selectedItem: SelectedItem;
}>();

const item = computed(() => props.selectedItem.item as CvModelItemTextarea);

function removeItem(): void {
  store.removeItem(props.selectedItem.section, item.value);
  store.selectedItem = null;
}
</script>
