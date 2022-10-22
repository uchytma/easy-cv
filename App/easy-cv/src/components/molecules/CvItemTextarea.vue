<template>
  <article class="article cv-item-padding text-justify" v-html="props.item.text"></article>
</template>

<script lang="ts" setup>
import type { CvModelItemTextarea } from "@/services/cvModel/cvModel";

const props = defineProps<{
  item: CvModelItemTextarea;
}>();
</script>
