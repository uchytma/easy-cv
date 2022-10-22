<template>
  <div class="wrapper">
    <h3 v-if="props.groupName">{{ props.groupName }}</h3>
    <div class="items-wrapper">
      <slot></slot>
    </div>
  </div>
</template>

<script lang="ts" setup>
const props = defineProps({
  groupName: { type: String, required: false },
});
</script>

<style lang="css" scoped>
.wrapper {
  display: flex;
  flex-direction: column;
  padding: var(--base-gap);
  gap: calc(var(--base-gap) * 0.5);
}

.items-wrapper {
  display: flex;
  flex-direction: column;
  gap: var(--base-gap);
}
</style>
