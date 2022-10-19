<template>
  <article :class="{ 'article-without-icon': !props.item.icon }" class="article cv-item-padding">
    <BaseIcon v-if="props.item.icon" :icon="props.item.icon"></BaseIcon>
    <BaseTextFragment v-if="props.item.text" :text-fragment="props.item.text"></BaseTextFragment>
    <BaseItemSeparator v-if="props.item.subtext"></BaseItemSeparator>
    <BaseTextFragment v-if="props.item.subtext" :text-fragment="props.item.subtext"></BaseTextFragment>
  </article>
</template>

<script lang="ts" setup>
import type { CvModelItemText } from "@/services/cvModel/cvModel";
import BaseIcon from "../atoms/BaseIcon.vue";
import BaseTextFragment from "../atoms/BaseTextFragment.vue";
import BaseItemSeparator from "../atoms/BaseItemSeparator.vue";

const props = defineProps<{
  item: CvModelItemText;
}>();
</script>

<style lang="css" scoped>
.article {
  display: grid;
  grid-template-columns: 30px max-content max-content auto;
  align-items: center;
}

.article-without-icon {
  grid-template-columns: max-content max-content auto;
}
</style>
