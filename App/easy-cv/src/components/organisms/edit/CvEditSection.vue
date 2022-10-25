<template>
  <CvEditWrapper
    :remove="() => store.sectionRemove(props.selectedItem.section)"
    :move-up="() => store.sectionMoveUp(props.selectedItem.section)"
    :move-down="() => store.sectionMoveDown(props.selectedItem.section)"
  >
    <CvEditGroup>
      <TextInput v-model="section.header.title" title="Název sekce:" id="title" />
      <NullableTextInput v-model="section.header.subtitle" title="Podnázev:" id="subtitle" />
      <SelectList :options="sizeOptions" v-model="section.header.size" title="Velikost textu:" id="size" />
    </CvEditGroup>
  </CvEditWrapper>
</template>

<script lang="ts" setup>
import type { SelectedItem } from "@/stores/mainApp";
import { computed } from "vue";
import CvEditWrapper from "./CvEditWrapper.vue";
import TextInput from "../../molecules/inputs/TextInput.vue";
import NullableTextInput from "../../molecules/inputs/NullableTextInput.vue";
import SelectList from "../../molecules/inputs/SelectList.vue";
import { sizeOptions } from "@/services/commonTypes/headerSize";
import CvEditGroup from "./CvEditGroup.vue";

import { useMainAppStore } from "@/stores/mainApp";
const store = useMainAppStore();

const props = defineProps<{
  selectedItem: SelectedItem;
}>();

const section = computed(() => props.selectedItem.section);
</script>
