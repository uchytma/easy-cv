<template>
  <div class="input-wrapper">
    <label :for="props.id">{{ props.title }}</label>
    <select :id="props.id" :value="modelValue" @input="emitModelUpdate($event.target)">
      <option value="">Nevybráno</option>
      <option v-for="option in options" :key="option.value" :value="option.value">
        {{ option.text }}
      </option>
    </select>
  </div>
</template>

<script lang="ts" setup>
const props = defineProps<{
  id: string;
  modelValue: string | null;
  title: string;
  options: { value: string; text: string }[];
}>();

const emits = defineEmits<{
  (e: "update:modelValue", target: string | null): void;
}>();

function emitModelUpdate(target: EventTarget | null): void {
  const el = target as HTMLInputElement;
  emits("update:modelValue", el.value ?? null);
}
</script>

<style lang="css" scoped>
.input-wrapper {
  display: flex;
  flex-direction: column;
  gap: calc(var(--base-gap) * 0.25);
}
</style>
