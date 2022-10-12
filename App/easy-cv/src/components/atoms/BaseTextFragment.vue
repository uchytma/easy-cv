<template>
  <div :class="textClasses">
    <a v-if="props.textFragment.linkUrl" :href="props.textFragment.linkUrl" target="_blank">
      {{ props.textFragment.text }}
    </a>
    <template v-else>
      {{ props.textFragment.text }}
    </template>
  </div>
</template>

<script lang="ts" setup>
import type { TextFragment } from "@/services/commonTypes/textFragment";
import { computed } from "vue";

const props = defineProps<{
  textFragment: TextFragment;
}>();

const textClasses = computed(() => {
  let classes = " ";
  if (props.textFragment.bold) {
    classes += "bold ";
  }
  if (props.textFragment.muted) {
    classes += "muted ";
  }
  return classes;
});
</script>
