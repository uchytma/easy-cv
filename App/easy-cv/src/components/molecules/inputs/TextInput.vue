<template>
  <div class="input-wrapper">
    <label :for="props.id">{{ props.title }}</label>
    <input
      :id="props.id"
      type="text"
      :value="modelValue"
      @input="emits('update:modelValue', ($event.target as HTMLInputElement).value)"
    />
  </div>
</template>

<script lang="ts" setup>
const props = defineProps<{
  id: string;
  modelValue: string;
  title: string;
}>();

const emits = defineEmits<{
  (e: "update:modelValue", target: string): void;
}>();
</script>

<style lang="css" scoped>
.input-wrapper {
  display: flex;
  flex-direction: column;
  gap: calc(var(--base-gap) * 0.25);
}
</style>
