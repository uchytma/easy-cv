import { ref } from "vue";
import { defineStore } from "pinia";
import { getBackgrounds } from "@/services/background/backgroundService";
import { getDefaultCv } from "@/services/cvModel/cvModelService";
import type { CvModel } from "@/services/cvModel/cvModel";

export const useMainAppStore = defineStore("mainApp", () => {
  const cvModel = ref<CvModel>(getDefaultCv());
  const selectedBackground = ref(getBackgrounds()[0]);

  return { selectedBackground, cvModel };
});
