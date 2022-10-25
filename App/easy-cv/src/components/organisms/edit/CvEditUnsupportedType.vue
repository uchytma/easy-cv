<template>
  <CvEditWrapper :remove="null" :move-up="null" :move-down="null">
    <CvEditGroup>
      <p>Editace dané položky není podporována.</p>
    </CvEditGroup>
  </CvEditWrapper>
</template>

<script lang="ts" setup>
import CvEditGroup from "./CvEditGroup.vue";
import CvEditWrapper from "./CvEditWrapper.vue";
</script>
