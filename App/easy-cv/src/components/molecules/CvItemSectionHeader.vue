<template>
  <header class="cv-item-padding section-wrapper" :id="`item_${props.sectionHeader.guid}`">
    <div class="section-header">
      <HeaderText :size="props.sectionHeader.size"> {{ props.sectionHeader.title }}</HeaderText>
      <span class="muted">{{ props.sectionHeader.subtitle }}</span>
    </div>
    <div class="actions-section">
      <a href="javascript:void(0)" @click.stop="toggleMenuVisible">
        <BaseIcon class="icon" :icon="Icon.Plus" />

        <div class="dropdown" :class="{ showed: menuVisible }">
          <div class="dropdown-content">
            <a class="hoverable" href="javascript:void(0)">Přidat sekci nad</a>
            <a class="hoverable" href="javascript:void(0)">Přidat sekci pod</a>
            <a class="hoverable" href="javascript:void(0)">Přidat text</a>
            <a class="hoverable" href="javascript:void(0)">Přidat dlouhý text</a>
            <a class="hoverable" href="javascript:void(0)">Přidat panel</a>
          </div>
        </div>
      </a>
    </div>
  </header>
</template>

<script lang="ts" setup>
import { Icon } from "@/services/commonTypes/icons";
import { ref } from "vue";
import type { CvModelSectionHeader } from "@/services/cvModel/cvModel";
import HeaderText from "../atoms/BaseHeaderText.vue";
import BaseIcon from "../atoms/BaseIcon.vue";

const menuVisible = ref(false);

function toggleMenuVisible(): void {
  menuVisible.value = !menuVisible.value;
}

function closeMenuIfOpened(): void {
  if (menuVisible.value) {
    menuVisible.value = false;
  }
}

window.addEventListener("click", closeMenuIfOpened);

const props = defineProps<{
  sectionHeader: CvModelSectionHeader;
}>();
</script>

<style lang="css" scoped>
.dropdown {
  position: relative;
}

.dropdown > .dropdown-content {
  display: none;
}

.dropdown.showed > .dropdown-content {
  position: absolute;
  background-color: white;
  min-width: 180px;
  right: 0;
  box-shadow: 0px 8px 16px 0px rgba(0, 0, 0, 0.2);
  z-index: 1;
  display: flex;
  flex-direction: column;
  margin-top: 0.5rem;
}

.dropdown-content > * {
  padding: calc(var(--base-gap) * 0.5) calc(var(--base-gap) * 1);
  justify-self: stretch;
  text-align: center;
}

.dropdown-content > *:not(:last-child) {
  border-bottom: 1px solid var(--color-lines);
}

.section-header {
  display: flex;
  flex-direction: row;
  align-items: baseline;
  gap: 0.8rem;
  flex-grow: 1;
}

.section-wrapper {
  display: flex;
  flex-direction: row;
  gap: var(--base-gap);
  align-items: center;
}

.icon {
  font-size: 1.2rem;
}
</style>
