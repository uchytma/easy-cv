<template>
  <div class="item-wrapper">
    <CvItemText v-if="props.item.type === 'text'" :item="(props.item as CvModelItemText)"></CvItemText>
    <CvItemTextarea v-if="props.item.type === 'textarea'" :item="(props.item as CvModelItemTextarea)"></CvItemTextarea>
  </div>
</template>

<script lang="ts" setup>
import type { CvModelItem, CvModelItemText, CvModelItemTextarea } from "@/services/cvModel/cvModel";
import CvItemText from "./CvItemText.vue";
import CvItemTextarea from "./CvItemTextarea.vue";

const props = defineProps<{
  item: CvModelItem;
}>();
</script>
