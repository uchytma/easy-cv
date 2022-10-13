<template>
  <div class="article-box-stars">
    <span v-for="index in max" :key="index" :class="{ 'square-checked': index <= props.rating }" class="square"></span>
  </div>
</template>

<script lang="ts" setup>
const props = defineProps({
  rating: {
    type: Number,
    required: true,
  },
  max: {
    type: Number,
    required: false,
    default: 5,
  },
});
</script>

<style lang="css" scoped>
.article-box-stars {
  display: flex;
  gap: 5px;
  align-items: center;
  margin-top: 4px;
}

.square {
  background-color: rgba(0, 0, 0, 0.1);
  height: 10px;
  width: 10px;
  print-color-adjust: exact !important;
  -webkit-print-color-adjust: exact !important;
}

.square-checked {
  background-color: rgba(0, 0, 0, 0.5);
}
</style>
