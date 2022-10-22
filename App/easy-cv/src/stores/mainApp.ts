import { ref } from "vue";
import { defineStore } from "pinia";
import { getBackgrounds } from "@/services/background/backgroundService";
import { getDefaultCv } from "@/services/cvModel/cvModelService";
import type { CvModel, CvModelItem, CvModelSection } from "@/services/cvModel/cvModel";
import type { Position } from "@/services/domUtils/position";

export type SelectedItem = {
  callerPosition: Position;
  item: CvModelItem;
  section: CvModelSection;
};

export const useMainAppStore = defineStore("mainApp", () => {
  const cvModel = ref<CvModel>({ sections: [] });
  const selectedBackground = ref(getBackgrounds()[0]);
  const selectedItem = ref<SelectedItem | null>(null);

  async function loadDefaultModel(): Promise<CvModel> {
    const model = await getDefaultCv();
    cvModel.value = model;
    return model;
  }

  function removeSection(section: CvModelSection): void {
    cvModel.value.sections = cvModel.value.sections.filter((s) => s !== section);
  }

  function removeItem(section: CvModelSection, item: CvModelItem): void {
    section.items = section.items.filter((i) => i !== item);
  }

  return { selectedBackground, cvModel, loadDefaultModel, selectedItem, removeSection, removeItem };
});
