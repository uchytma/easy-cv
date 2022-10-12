<template>
  <article class="article" v-html="props.item.text?.text"></article>
</template>

<script lang="ts" setup>
import type { CvModelItemTextarea } from "@/services/cvModel/cvModel";

const props = defineProps<{
  item: CvModelItemTextarea;
}>();
</script>

<style lang="css" scoped>
.article {
  padding: var(--base-gap);
  text-align: justify;
}
</style>
