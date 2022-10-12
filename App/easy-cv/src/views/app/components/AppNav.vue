<template>
  <div class="nav-container">
    <div class="nav-wrapper">
      <a href="javascript:void(0)" @click="() => router.push('/')">Zavřít editor</a>
      <a href="javascript:void(0)">Uložit změny</a>
      <a href="javascript:void(0)">Tisknout</a>
      <div>
        Pozadí:
        <select v-model="store.selectedBackground">
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
</script>

<style lang="css" scoped>
.nav-wrapper {
  display: flex;
  flex-direction: row;
  gap: 0.4rem;
  padding: 0.4rem;
  background-color: var(--color-light-background);
  border-bottom: 1px solid var(--color-lines);
}

@media (min-width: 1300px) {
  .nav-container {
    position: sticky;
    display: flex;
    margin: 0.6rem;
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
  }

  .nav-wrapper > * {
    padding: 0.4rem;
  }

  .nav-wrapper > *:not(:last-child) {
    border-bottom: 1px solid var(--color-lines);
  }
}
</style>
