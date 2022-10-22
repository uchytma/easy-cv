<template>
  <div class="input-wrapper">
    <input
      :id="props.id"
      type="checkbox"
      :checked="modelValue"
      @input="emits('update:modelValue', !!($event.target as HTMLInputElement).checked)"
    />
    <label class="label" :for="props.id">{{ props.title }}</label>
  </div>
</template>

<script lang="ts" setup>
const props = defineProps<{
  id: string;
  modelValue: boolean;
  title: string;
}>();

const emits = defineEmits<{
  (e: "update:modelValue", target: boolean): void;
}>();
</script>

<style lang="css" scoped>
.input-wrapper {
  display: flex;
  flex-direction: row;
  gap: calc(var(--base-gap) * 0.25);
  align-items: center;
}

.label {
  font-size: 1rem;
  color: black;
}
</style>
