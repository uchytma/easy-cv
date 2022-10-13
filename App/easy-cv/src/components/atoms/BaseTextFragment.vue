<template>
  <div :class="textClasses">
    <a v-if="props.textFragment.linkUrl" :href="props.textFragment.linkUrl" target="_blank">
      <span v-if="props.allowHtml" v-html="props.textFragment.text"></span>
      <span v-else>{{ props.textFragment.text }}</span>
    </a>
    <template v-else>
      <span v-if="props.allowHtml" v-html="props.textFragment.text"></span>
      <span v-else>{{ props.textFragment.text }}</span>
    </template>
  </div>
</template>

<script lang="ts" setup>
import type { TextFragment } from "@/services/commonTypes/textFragment";
import { computed } from "vue";
import type { PropType } from "vue";

const props = defineProps({
  textFragment: {
    type: Object as PropType<TextFragment>,
    required: true,
  },
  allowHtml: {
    type: Boolean,
    required: false,
    default: false,
  },
});

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
