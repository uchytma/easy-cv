<template>
  <main>
    <h1>Easy CV</h1>
    <p>Vytvořte si moderní životopis během pár minut.</p>
    <div>
      <button @click="() => router.push('/app')">Začít tvořit</button>
    </div>
  </main>
</template>

<script lang="ts" setup>
import { useRouter } from "vue-router";

const router = useRouter();
</script>

<style lang="css" scoped>
h1 {
  margin: 0;
}

main {
  padding: var(--base-gap);
  display: flex;
  flex-direction: column;
  gap: var(--base-gap);
}

button {
  padding: var(--base-gap);
  cursor: pointer;
}
</style>
