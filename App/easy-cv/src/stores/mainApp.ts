import { ref, nextTick, watch } from "vue";
import { defineStore } from "pinia";
import { getBackgrounds } from "@/services/background/backgroundService";
import { getDefaultCv } from "@/services/cvModel/cvModelService";
import type { CvModel, CvModelItem, CvModelSection } from "@/services/cvModel/cvModel";
import { getAbsolutePosition } from "@/services/domUtils/domUtils";
import * as arrayUtils from "@/services/utils/arrayUtils";
export type SelectedItem = {
  item: CvModelItem;
  section: CvModelSection;
};

export const useMainAppStore = defineStore("mainApp", () => {
  const cvModel = ref<CvModel>({ sections: [] });
  const selectedBackground = ref(getBackgrounds()[0]);
  const selectedItem = ref<SelectedItem | null>(null);

  const asidePositionTop = ref<number | null>(0);

  async function loadDefaultModel(): Promise<CvModel> {
    const model = await getDefaultCv();
    cvModel.value = model;
    return model;
  }

  watch(selectedItem, () => {
    recomputeAsidePositionTop();
  });

  window.addEventListener("resize", () => {
    recomputeAsidePositionTop();
  });

  function recomputeAsidePositionTop() {
    if (window.innerWidth < 1120) {
      asidePositionTop.value = null;
      return;
    }
    if (!selectedItem.value) return;
    const htmlElement = document.getElementById(`item_${selectedItem.value.item.guid}`);
    if (!htmlElement) return;
    const pos = getAbsolutePosition(htmlElement, window);
    asidePositionTop.value = pos.top;
  }

  function sectionRemove(section: CvModelSection): void {
    cvModel.value.sections = cvModel.value.sections.filter((s) => s !== section);
    selectedItem.value = null;
  }

  function itemRemove(item: SelectedItem): void {
    item.section.items = item.section.items.filter((i) => i !== item.item);
    selectedItem.value = null;
  }

  function callFuncAndRecalcAsidePositionTop(func: () => void) {
    func();
    nextTick(() => {
      recomputeAsidePositionTop();
    });
  }

  function itemMoveUp(item: SelectedItem): void {
    callFuncAndRecalcAsidePositionTop(() => arrayUtils.moveUp(item.section.items, item.item));
  }

  function itemMoveDown(item: SelectedItem): void {
    callFuncAndRecalcAsidePositionTop(() => arrayUtils.moveDown(item.section.items, item.item));
  }

  function sectionMoveUp(section: CvModelSection): void {
    callFuncAndRecalcAsidePositionTop(() => arrayUtils.moveUp(cvModel.value.sections, section));
  }

  function sectionMoveDown(section: CvModelSection): void {
    callFuncAndRecalcAsidePositionTop(() => arrayUtils.moveDown(cvModel.value.sections, section));
  }

  return {
    selectedBackground,
    cvModel,
    loadDefaultModel,
    selectedItem,
    sectionRemove,
    itemRemove,
    sectionMoveUp,
    sectionMoveDown,
    itemMoveUp,
    itemMoveDown,
    asidePositionTop,
  };
});
