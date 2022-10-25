<template>
  <article
    class="article cv-item-padding text-justify"
    v-html="props.item.text"
    :id="`item_${props.item.guid}`"
  ></article>
</template>

<script lang="ts" setup>
import type { CvModelItemTextarea } from "@/services/cvModel/cvModel";

const props = defineProps<{
  item: CvModelItemTextarea;
}>();
</script>
