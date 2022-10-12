<template>
  <component :is="tag"> {{ props.headerText }} </component>
</template>

<script lang="ts" setup>
import type { HeaderSize } from "@/services/commonTypes/headerSize";
import { computed } from "vue";
const props = defineProps<{
  headerText: string;
  size: HeaderSize;
}>();

const tag = computed(() => {
  switch (props.size) {
    case "small":
      return "h3";
    case "normal":
      return "h2";
    case "big":
      return "h1";
    default:
      return "h1";
  }
});
</script>

<style lang="css" scoped>
h1,
h2,
h3 {
  margin: 0;
  padding: 0;
  font-weight: 600;
}
</style>
