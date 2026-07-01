<script setup lang="ts">
// Visibility control
const isOpen = defineModel<boolean>('isOpen', { default: false })
const createFailed = defineModel<boolean>('createFailed', {default: false})

// Parameters
// interface ModalProps { }
// defineProps<ModalProps>()

// Define structured event payloads emitted on close
const emit = defineEmits<{
  createSuccess: []
}>()

const handleConfirm = () => {
  // TODO: Try create, if success, emit success, else show failure message

  const success = true;
  if (success) {
    emit('createSuccess')
    isOpen.value = false
  }
  else {
    createFailed.value = true;
  }
}
</script>

<template>
  <Teleport to="body">
    <div v-if="isOpen" class="modal-backdrop" @click="isOpen = false">
      <div class="modal-content" @click.stop>
        <div v-if="createFailed">
          <p>Failed to create record</p>
        </div>

        <h3>Create ToDo</h3>
        <p>Title</p>
        <p>Description</p>
        
        <div class="modal-actions">
          <button @click="isOpen = false">Cancel</button>
          <button @click="handleConfirm">Save</button>
        </div>
      </div>
    </div>
  </Teleport>
</template>

<style scoped>
.modal-backdrop {
  position: fixed;
  top: 0; left: 0; width: 100vw; height: 100vh;
  background: rgba(0, 0, 0, 0.5);
  display: flex; justify-content: center; align-items: center;
}
.modal-content {
  background: white; padding: 20px; border-radius: 8px; min-width: 300px;
}
</style>