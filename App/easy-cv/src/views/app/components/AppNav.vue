<template>
  <div class="nav-container">
    <div class="nav-wrapper">
      <a class="hoverable" href="javascript:void(0)" @click="() => router.push('/')">Zavřít editor</a>
      <a class="hoverable" href="javascript:void(0)" @click="print">Tisknout</a>
      <div class="input-wrapper">
        <label for="bg">Pozadí:</label>
        <select id="bg" class="select-bg" v-model="store.selectedBackground">
          <option :key="bg.id" v-for="bg in allBackgrounds" :value="bg">
            {{ bg.name }}
          </option>
        </select>
      </div>
    </div>
  </div>
</template>

<script lang="ts" setup>
import { useRouter } from "vue-router";
import { getBackgrounds } from "@/services/background/backgroundService";
import { useMainAppStore } from "@/stores/mainApp";

const router = useRouter();
const allBackgrounds = getBackgrounds();
const store = useMainAppStore();

function print(): void {
  window.print();
}
</script>

<style lang="css" scoped>
.nav-wrapper {
  display: flex;
  flex-direction: row;
  background-color: var(--color-light-background);
  border-bottom: 1px solid var(--color-lines);
  align-items: center;
}

.nav-wrapper > * {
  padding: calc(var(--base-gap) * 0.5);
}

.input-wrapper {
  display: flex;
  gap: calc(var(--base-gap) * 0.25);
  align-items: center;
}
.select-bg {
  padding: calc(var(--base-gap) * 0.25);
}

@media (min-width: 1300px) {
  .nav-container {
    position: sticky;
    display: flex;
    top: var(--base-gap);
    justify-content: flex-end;
  }

  .nav-wrapper {
    display: flex;
    flex-direction: column;
    border: 1px solid var(--color-lines);
    width: 150px;
    gap: 0;
    padding: 0;
    border-radius: var(--border-radius-base);
    align-items: stretch;
  }

  .nav-wrapper > * {
    padding: 0.4rem;
    display: block;
    text-align: center;
  }

  .nav-wrapper > *:not(:last-child) {
    border-bottom: 1px solid var(--color-lines);
  }
}
</style>
