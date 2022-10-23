<template>
  <div class="wrapper">
    <div class="slot-wrapper"><slot></slot></div>
    <div>
      <a href="javascript:void(0)" @click="emits('onClose')">
        <BaseIcon :icon="Icon.Close"></BaseIcon>
      </a>
    </div>
  </div>
</template>

<script lang="ts" setup>
import BaseIcon from "../atoms/BaseIcon.vue";
import { Icon } from "@/services/commonTypes/icons";

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

.slot-wrapper {
  display: flex;
  gap: calc(var(--base-gap) * 0.5);
}
</style>
