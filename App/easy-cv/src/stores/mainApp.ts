import { ref } from "vue";
import { defineStore } from "pinia";
import { getBackgrounds } from "@/services/background/backgroundService";
import { getDefaultCv } from "@/services/cvModel/cvModelService";
import type { CvModel } from "@/services/cvModel/cvModel";

export const useMainAppStore = defineStore("mainApp", () => {
  const cvModel = ref<CvModel>({ sections: [] });
  console.log(cvModel);
  const selectedBackground = ref(getBackgrounds()[0]);

  async function loadDefaultModel(): Promise<CvModel> {
    const model = await getDefaultCv();
    cvModel.value = model;
    return model;
  }

  return { selectedBackground, cvModel, loadDefaultModel };
});
