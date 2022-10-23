<template>
  <CvEditWrapper>
    <CvEditGroup>
      <CvEditTextFragment
        checkboxLabel="Zobrazit text"
        @removeTextFragment="item.text = null"
        @createTextFragment="item.text = getDefaultTextFragment()"
        id="fragment_text"
        :textFragment="item.text"
      ></CvEditTextFragment>
    </CvEditGroup>
    <CvEditGroup>
      <CvEditTextFragment
        checkboxLabel="Zobrazit doplňkový text"
        @removeTextFragment="item.subtext = null"
        @createTextFragment="item.subtext = getDefaultTextFragment()"
        id="fragment_subtext"
        :textFragment="item.subtext"
      ></CvEditTextFragment>
    </CvEditGroup>
    <CvEditGroup>
      <NullableSelectList :options="iconOptions" v-model="item.icon" title="Ikona" id="icon" />
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
import NullableSelectList from "../../molecules/inputs/NullableSelectList.vue";
import BaseIcon from "../../atoms/BaseIcon.vue";
import { Icon, iconOptions } from "@/services/commonTypes/icons";
import { useMainAppStore } from "@/stores/mainApp";
import type { CvModelItemText } from "@/services/cvModel/cvModel";
import CvEditGroup from "./CvEditGroup.vue";
import CvEditTextFragment from "./CvEditTextFragment.vue";
import { getDefaultTextFragment } from "@/services/commonTypes/textFragment";

const store = useMainAppStore();

const props = defineProps<{
  selectedItem: SelectedItem;
}>();

const item = computed(() => props.selectedItem.item as CvModelItemText);

function removeItem(): void {
  store.removeItem(props.selectedItem.section, item.value);
  store.selectedItem = null;
}
</script>
