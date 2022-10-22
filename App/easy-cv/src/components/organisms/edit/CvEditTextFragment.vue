<template>
  <div>
    <CheckboxInput
      class="checkbox"
      @change="swapTextFragment"
      :model-value="!!item"
      :title="checkboxLabel"
      :id="id"
    ></CheckboxInput>
  </div>
  <TextInput v-if="item" v-model="item.text" title="Text:" :id="`text_${id}`" />
  <NullableTextInput v-if="item" v-model="item.linkUrl" title="Odkaz (URL):" :id="`url_${id}`" />
  <CheckboxInput v-if="item" v-model="item.bold" title="Tučně" :id="`bold_${id}`"></CheckboxInput>
  <CheckboxInput v-if="item" v-model="item.muted" title="Nevýrazně" :id="`muted_${id}`"></CheckboxInput>
</template>

<script lang="ts" setup>
import type { TextFragment } from "@/services/commonTypes/textFragment";
import CheckboxInput from "../../molecules/inputs/CheckboxInput.vue";
import { ref, computed } from "vue";
import TextInput from "../../molecules/inputs/TextInput.vue";
import NullableTextInput from "../../molecules/inputs/NullableTextInput.vue";

const props = defineProps<{
  textFragment: TextFragment | null;
  id: string;
  checkboxLabel: string;
}>();

const item = computed(() => {
  return props.textFragment;
});

const emits = defineEmits<{
  (e: "createTextFragment"): void;
  (e: "removeTextFragment", textFragment: TextFragment): void;
}>();

function swapTextFragment(): void {
  if (item.value) {
    emits("removeTextFragment", item.value);
  } else {
    emits("createTextFragment");
  }
}
</script>

<style lang="css" scoped>
.checkbox {
  font-weight: 600;
}
</style>
