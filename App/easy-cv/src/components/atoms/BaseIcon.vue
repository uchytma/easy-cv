<template>
  <font-awesome-icon :icon="iconClass" />
</template>

<script lang="ts" setup>
import { Icon } from "@/services/commonTypes/icons";
import { computed } from "vue";

const props = defineProps<{
  icon: Icon;
}>();

const iconClass = computed(() => {
  switch (props.icon) {
    case Icon.Phone:
      return "fa-solid fa-phone-square";
    case Icon.Email:
      return "fa-solid fa-mail-bulk";
    case Icon.Location:
      return "fa-solid fa-map-marked";
    case Icon.Github:
      return "fa-brands fa-github";
    case Icon.Linkedin:
      return "fa-brands fa-linkedin";
    case Icon.Close:
      return "fa-solid fa-xmark";
    case Icon.Trash:
      return "fa-solid fa-trash-can";
    default:
      return null;
  }
});
</script>
