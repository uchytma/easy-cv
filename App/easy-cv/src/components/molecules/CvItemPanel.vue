<template>
  <article class="article-wrapper">
    <div v-if="props.item.imageUrl" class="g-img">
      <img :src="props.item.imageUrl" />
    </div>
    <div class="g-text">
      <div class="title-wrapper">
        <BaseTextFragment v-if="props.item.title" :text-fragment="props.item.title"></BaseTextFragment>
        <BaseRatingBar v-if="props.item.rating" :rating="props.item.rating" :max="5"></BaseRatingBar>
      </div>

      <BaseTextFragment
        class="g-description"
        v-if="props.item.description"
        :text-fragment="props.item.description"
      ></BaseTextFragment>
      <BaseTextFragment
        class="g-subtitle"
        :allow-html="true"
        v-if="props.item.subtitle"
        :text-fragment="props.item.subtitle"
      ></BaseTextFragment>
      <BaseTextFragment
        class="g-longText"
        :allow-html="true"
        v-if="props.item.longText"
        :text-fragment="props.item.longText"
      ></BaseTextFragment>
    </div>
  </article>
</template>

<script lang="ts" setup>
import type { CvModelItemPanel } from "@/services/cvModel/cvModel";
import BaseTextFragment from "../atoms/BaseTextFragment.vue";
import BaseRatingBar from "../atoms/BaseRatingBar.vue";

const props = defineProps<{
  item: CvModelItemPanel;
}>();
</script>

<style lang="css" scoped>
.article-wrapper {
  padding: var(--base-gap);
  display: grid;
  grid: auto / min-content auto;
  grid-template-areas: "g-img g-text";
}

.g-img {
  width: 105px;
  height: 105px;
  grid-area: g-img;
  align-self: center;
  display: grid;
  align-items: center;
}

.g-img > img {
  max-width: 90px;
  max-height: 90px;
  margin-right: var(--base-gap);
}

.g-text {
  grid-area: g-text;
  margin-bottom: calc(var(--base-gap) * 0.5);
  display: grid;
  grid: min-content min-content min-content auto / auto;
  gap: 5px;
}

.title-wrapper {
  gap: 10px;
  display: flex;
}

.g-longText {
  border-top: 1px dotted var(--color-lines);
  padding-top: calc(var(--base-gap) * 0.5);
  margin-top: calc(var(--base-gap) * 0.5);
}
</style>
