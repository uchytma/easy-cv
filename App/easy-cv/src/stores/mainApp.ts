import { ref } from "vue";
import { defineStore } from "pinia";
import { getBackgrounds, type Background } from "@/services/backgroundService";

export const useMainAppStore = defineStore("mainApp", () => {
  const selectedBackground = ref(getBackgrounds()[0]);
  return { selectedBackground };
});
