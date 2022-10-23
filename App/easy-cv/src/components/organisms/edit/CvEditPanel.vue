<template>
  <CvEditWrapper>
    <CvEditGroup>
      <CvEditTextFragment
        checkboxLabel="Zobrazit text"
        @removeTextFragment="item.title = null"
        @createTextFragment="item.title = getDefaultTextFragment()"
        id="fragment_text"
        :textFragment="item.title"
      ></CvEditTextFragment>
      <NullableSelectList :options="ratingOptions" v-model="ratingString" title="Hodnocení (1-5)" id="rating" />
    </CvEditGroup>
    <CvEditGroup>
      <CvEditTextFragment
        checkboxLabel="Zobrazit popisek"
        @removeTextFragment="item.description = null"
        @createTextFragment="item.description = getDefaultTextFragment()"
        id="fragment_description"
        :textFragment="item.description"
      ></CvEditTextFragment>
    </CvEditGroup>
    <CvEditGroup>
      <CvEditTextFragment
        checkboxLabel="Zobrazit doplňkový text"
        @removeTextFragment="item.subtitle = null"
        @createTextFragment="item.subtitle = getDefaultTextFragment()"
        id="fragment_subtitle"
        :textFragment="item.subtitle"
      ></CvEditTextFragment>
    </CvEditGroup>
    <CvEditGroup>
      <CvEditTextFragment
        checkboxLabel="Zobrazit dlouhý text"
        @removeTextFragment="item.longText = null"
        @createTextFragment="item.longText = getDefaultTextFragment()"
        id="fragment_longText"
        :textFragment="item.longText"
      ></CvEditTextFragment>
    </CvEditGroup>
    <CvEditGroup>
      <NullableTextInput v-model="item.imageUrl" title="URL obrázku:" id="imageUrl" />
    </CvEditGroup>
    <template #controls>
      <a @click="removeItem" href="javascript:void(0)"><BaseIcon :icon="Icon.Trash" /></a>
    </template>
  </CvEditWrapper>
</template>
<script lang="ts" setup>
import type { SelectedItem } from "@/stores/mainApp";
import { computed, ref, watch } from "vue";
import CvEditWrapper from "./CvEditWrapper.vue";
import NullableSelectList from "../../molecules/inputs/NullableSelectList.vue";
import BaseIcon from "../../atoms/BaseIcon.vue";
import { Icon } from "@/services/commonTypes/icons";
import { useMainAppStore } from "@/stores/mainApp";
import type { CvModelItemPanel } from "@/services/cvModel/cvModel";
import CvEditGroup from "./CvEditGroup.vue";
import NullableTextInput from "../../molecules/inputs/NullableTextInput.vue";
import { getDefaultTextFragment } from "@/services/commonTypes/textFragment";

import CvEditTextFragment from "./CvEditTextFragment.vue";
const store = useMainAppStore();

const props = defineProps<{
  selectedItem: SelectedItem;
}>();

const item = computed(() => props.selectedItem.item as CvModelItemPanel);

function removeItem(): void {
  store.removeItem(props.selectedItem.section, item.value);
  store.selectedItem = null;
}

const ratingString = ref(item.value.rating?.toString() ?? null);

watch(
  () => item.value.rating,
  (newRating) => {
    ratingString.value = newRating?.toString() ?? null;
  }
);

watch(ratingString, (newRating) => {
  item.value.rating = newRating ? parseInt(newRating) : null;
});

const ratingOptions = [
  { value: "1", text: "1" },
  { value: "2", text: "2" },
  { value: "3", text: "3" },
  { value: "4", text: "4" },
  { value: "5", text: "5" },
];
</script>
