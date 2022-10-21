<template>
  <div class="wrapper">
    <div><slot></slot></div>
    <div>
      <a href="javascript:void(0)" @click="emits('onClose')">
        <BaseIcon icon="close"></BaseIcon>
      </a>
    </div>
  </div>
</template>

<script lang="ts" setup>
import BaseIcon from "../atoms/BaseIcon.vue";
const emits = defineEmits<{
  (e: "onClose"): void;
}>();
</script>

<style lang="css" scoped>
.wrapper {
  display: flex;
  flex-direction: row;
  justify-content: space-between;
}
</style>
