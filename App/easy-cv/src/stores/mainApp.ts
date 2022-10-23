import { ref, nextTick } from "vue";
import { defineStore } from "pinia";
import { getBackgrounds } from "@/services/background/backgroundService";
import { getDefaultCv } from "@/services/cvModel/cvModelService";
import type { CvModel, CvModelItem, CvModelSection } from "@/services/cvModel/cvModel";

export type SelectedItem = {
  item: CvModelItem;
  section: CvModelSection;
  htmlElement: HTMLElement;
};

export const useMainAppStore = defineStore("mainApp", () => {
  const cvModel = ref<CvModel>({ sections: [] });
  const selectedBackground = ref(getBackgrounds()[0]);
  const selectedItem = ref<SelectedItem | null>(null);
  const refreshKeyAsidePosition = ref(0);

  async function loadDefaultModel(): Promise<CvModel> {
    const model = await getDefaultCv();
    cvModel.value = model;
    return model;
  }

  function sectionRemove(section: CvModelSection): void {
    cvModel.value.sections = cvModel.value.sections.filter((s) => s !== section);
  }

  function removeItem(section: CvModelSection, item: CvModelItem): void {
    section.items = section.items.filter((i) => i !== item);
  }

  function sectionMoveUp(section: CvModelSection): void {
    const index = cvModel.value.sections.indexOf(section);
    if (index > 0) {
      swapItems(cvModel.value.sections, index, index - 1);
      nextTick(() => {
        refreshKeyAsidePosition.value++;
      });
    }
  }

  function sectionMoveDown(section: CvModelSection): void {
    const index = cvModel.value.sections.indexOf(section);
    if (index < cvModel.value.sections.length - 1) {
      swapItems(cvModel.value.sections, index, index + 1);
      nextTick(() => {
        refreshKeyAsidePosition.value++;
      });
    }
  }

  function swapItems<T>(array: Array<T>, index1: number, index2: number): Array<T> {
    array.splice(index2, 0, array.splice(index1, 1)[0]);
    return array;
  }

  return {
    selectedBackground,
    cvModel,
    loadDefaultModel,
    selectedItem,
    sectionRemove,
    removeItem,
    sectionMoveUp,
    sectionMoveDown,
    refreshKeyAsidePosition,
  };
});
