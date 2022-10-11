<template>
  <main>
    <h1>Easy CV</h1>
    <p>Vytvořte si moderní životopis během pár minut.</p>
    <button @click="() => router.push('/app')">Začít tvořit</button>
  </main>
</template>

<script lang="ts" setup>
import { useRouter } from "vue-router";

const router = useRouter();
</script>
