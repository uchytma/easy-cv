<template>
  <CvEditWrapper>
    <TextInput v-model="section.header.title" title="Název sekce:" id="title" />
    <NullableTextInput v-model="section.header.subtitle" title="Podnázev:" id="subtitle" />
    <SelectList :options="sizeOptions" v-model="section.header.size" title="Velikost textu:" id="size" />
    <template #controls>
      <a @click="removeSection" href="javascript:void(0)"><BaseIcon icon="trash" /></a>
    </template>
  </CvEditWrapper>
</template>

<script lang="ts" setup>
import type { SelectedItem } from "@/stores/mainApp";
import { computed } from "vue";
import CvEditWrapper from "./CvEditWrapper.vue";
import TextInput from "../../molecules/inputs/TextInput.vue";
import NullableTextInput from "../../molecules/inputs/NullableTextInput.vue";
import SelectList from "../../molecules/inputs/SelectList.vue";
import BaseIcon from "../../atoms/BaseIcon.vue";

import { useMainAppStore } from "@/stores/mainApp";
const store = useMainAppStore();

const props = defineProps<{
  selectedItem: SelectedItem;
}>();

function removeSection(): void {
  store.removeSection(props.selectedItem.section);
  store.selectedItem = null;
}

const section = computed(() => props.selectedItem.section);

const sizeOptions = [
  { value: "small", text: "Malá" },
  { value: "normal", text: "Střední" },
  { value: "big", text: "Velká" },
];
</script>
