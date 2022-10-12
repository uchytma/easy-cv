<template>
  <font-awesome-icon :icon="iconClass" />
</template>

<script lang="ts" setup>
import type { Icon } from "@/services/commonTypes/icons";
import { computed } from "vue";

const props = defineProps<{
  icon: Icon;
}>();

const iconClass = computed(() => {
  switch (props.icon) {
    case "phone":
      return "fa-solid fa-phone-square";
    case "email":
      return "fa-solid fa-mail-bulk";
    case "location":
      return "fa-solid fa-map-marked";
    case "github":
      return "fa-brands fa-github";
    case "linkedin":
      return "fa-brands fa-linkedin";
    default:
      return null;
  }
});
</script>
