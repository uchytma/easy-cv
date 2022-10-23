<template>
  <CvEditWrapper>
    <CvEditGroup>
      <TextInput v-model="section.header.title" title="Název sekce:" id="title" />
      <NullableTextInput v-model="section.header.subtitle" title="Podnázev:" id="subtitle" />
      <SelectList :options="sizeOptions" v-model="section.header.size" title="Velikost textu:" id="size" />
    </CvEditGroup>
    <template #controls>
      <a @click="removeSection" href="javascript:void(0)"><BaseIcon :icon="Icon.Trash" /></a>
      <a @click="moveUp" href="javascript:void(0)"><BaseIcon :icon="Icon.Up" /></a>
      <a @click="moveDown" href="javascript:void(0)"><BaseIcon :icon="Icon.Down" /></a>
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
import { Icon } from "@/services/commonTypes/icons";
import { sizeOptions } from "@/services/commonTypes/headerSize";
import CvEditGroup from "./CvEditGroup.vue";

import { useMainAppStore } from "@/stores/mainApp";
const store = useMainAppStore();

const props = defineProps<{
  selectedItem: SelectedItem;
}>();

function removeSection(): void {
  store.sectionRemove(props.selectedItem.section);
  store.selectedItem = null;
}

function moveUp(): void {
  store.sectionMoveUp(props.selectedItem.section);
}

function moveDown(): void {
  store.sectionMoveDown(props.selectedItem.section);
}

const section = computed(() => props.selectedItem.section);
</script>
