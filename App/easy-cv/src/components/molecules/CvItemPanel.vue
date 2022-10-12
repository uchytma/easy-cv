<template>
  <article class="article-wrapper">
    <div v-if="props.item.imageUrl" class="g-img">
      <img width="100" :src="props.item.imageUrl" />
    </div>
    <BaseHeaderText class="g-title" v-if="props.item.title" size="small">
      <BaseTextFragment :text-fragment="props.item.title"></BaseTextFragment>
    </BaseHeaderText>
    <BaseTextFragment
      class="g-description"
      v-if="props.item.description"
      :text-fragment="props.item.description"
    ></BaseTextFragment>
    <BaseTextFragment
      class="g-subtitle"
      v-if="props.item.subtitle"
      :text-fragment="props.item.subtitle"
    ></BaseTextFragment>
    <BaseTextFragment
      class="g-longText"
      v-if="props.item.longText"
      :text-fragment="props.item.longText"
    ></BaseTextFragment>
  </article>
</template>

<script lang="ts" setup>
import type { CvModelItemPanel } from "@/services/cvModel/cvModel";
import BaseTextFragment from "../atoms/BaseTextFragment.vue";
import BaseHeaderText from "../atoms/BaseHeaderText.vue";

const props = defineProps<{
  item: CvModelItemPanel;
}>();
</script>

<style lang="css" scoped>
.article-wrapper {
  padding: var(--base-gap);
  display: grid;
  grid: auto auto auto auto / max-content auto;
  grid-template-areas:
    "g-img g-title"
    "g-img g-description"
    "g-img g-subtitle"
    "g-img g-longText";
}

.g-img {
  grid-area: g-img;
}

.g-img > img {
  max-width: 120px;
  max-height: 120px;
  margin-right: var(--base-gap);
}

.g-title {
  grid-area: g-title;
  margin-bottom: calc(var(--base-gap) * 0.5);
}

.g-description {
  grid-area: g-description;
}

.g-longText {
  grid-area: g-longText;
}
</style>
