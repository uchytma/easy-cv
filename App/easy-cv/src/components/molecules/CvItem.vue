<template>
  <div class="item-wrapper hoverable">
    <CvItemText v-if="props.item.type === CvModelItemType.Text" :item="(props.item as CvModelItemText)"></CvItemText>
    <CvItemTextarea
      v-if="props.item.type === CvModelItemType.Textarea"
      :item="(props.item as CvModelItemTextarea)"
    ></CvItemTextarea>
    <CvItemPanel
      v-if="props.item.type === CvModelItemType.Panel"
      :item="(props.item as CvModelItemPanel)"
    ></CvItemPanel>
  </div>
</template>

<script lang="ts" setup>
import type { CvModelItem, CvModelItemPanel, CvModelItemText, CvModelItemTextarea } from "@/services/cvModel/cvModel";
import CvItemText from "./CvItemText.vue";
import CvItemTextarea from "./CvItemTextarea.vue";
import CvItemPanel from "./CvItemPanel.vue";
import { CvModelItemType } from "@/services/cvModel/cvModel";

const props = defineProps<{
  item: CvModelItem;
}>();
</script>
