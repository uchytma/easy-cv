<template>
  <article class="article">
    {{ props.item.text?.text }}
  </article>
</template>

<script lang="ts" setup>
import type { CvModelItemText } from "@/services/cvModel/cvModel";

const props = defineProps<{
  item: CvModelItemText;
}>();
</script>

<style lang="css" scoped>
.article {
  padding: 0.8rem 0.6rem;
}
</style>
