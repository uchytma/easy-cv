<template>
  <div class="input-wrapper">
    <label :for="props.id">{{ props.title }}</label>

    <editor-content class="tiptap-editor-content" :editor="editor" />
  </div>
</template>

<script lang="ts" setup>
import { useEditor, EditorContent } from "@tiptap/vue-3";
import StarterKit from "@tiptap/starter-kit";

const props = defineProps<{
  id: string;
  modelValue: string;
  title: string;
}>();

const editor = useEditor({
  content: props.modelValue,
  extensions: [StarterKit],
  onUpdate: ({ editor }) => {
    emits("update:modelValue", editor.getHTML());
  },
});

const emits = defineEmits<{
  (e: "update:modelValue", target: string): void;
}>();
</script>

<style lang="css" scoped>
.input-wrapper {
  display: flex;
  flex-direction: column;
  gap: calc(var(--base-gap) * 0.25);
}
</style>

<style lang="css">
.ProseMirror {
  min-height: 200px;
  max-height: 400px;
  overflow-y: scroll;
}
</style>
