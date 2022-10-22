<template>
  <component :is="tag"> <slot></slot> </component>
</template>

<script lang="ts" setup>
import { HeaderSize } from "@/services/commonTypes/headerSize";
import { computed } from "vue";
const props = defineProps<{
  size: HeaderSize;
}>();

const tag = computed(() => {
  switch (props.size) {
    case HeaderSize.Small:
      return "h3";
    case HeaderSize.Normal:
      return "h2";
    case HeaderSize.Big:
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
