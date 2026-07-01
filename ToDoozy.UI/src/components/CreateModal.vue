<script setup lang="ts">
import BaseButton from './BaseButton.vue'

// Visibility control
const isOpen = defineModel<boolean>('isOpen', { default: false })
const createFailed = defineModel<boolean>('createFailed', { default: false })

// Form control bindings
const title = defineModel<string>('title')
const description = defineModel<string>('description')

// Parameters
// interface ModalProps { }
// defineProps<ModalProps>()

// Define structured event payloads emitted on close
const emit = defineEmits<{
  createSuccess: []
}>()

const handleConfirm = () => {
  // TODO: Try create, if success, emit success, else show failure message

  const success = false;
  if (success) {
    emit('createSuccess')
    createFailed.value = false
    isOpen.value = false
  }
  else {
    createFailed.value = true;
  }
}

const handleCancel = () => {
  createFailed.value = false;
  isOpen.value = false;
}
</script>

<template>
  <Teleport to="body">
    <div v-if="isOpen" class="modal-backdrop" @click="handleCancel()">
      <div class="modal-content" @click.stop>
        <h3 class="dark-text">Create ToDo</h3>
        <div v-if="createFailed" class="error-box">
          <p>Failed to create record</p>
        </div>
        <p><i class="dark-text">Title</i></p>
        <input v-model="title" placeholder="My ToDo!"/>
        <p><i class="dark-text">Description</i></p>
        <textarea v-model="description" placeholder="All my details!" rows="3"></textarea>
        
        <div class="modal-actions">
          <BaseButton @click="handleCancel()">Cancel</BaseButton>
          <BaseButton @click="handleConfirm()">Save</BaseButton>
        </div>
      </div>
    </div>
  </Teleport>
</template>

<style scoped>
input {
  width: 100%;
}

textarea {
  width: 100%;
}

.modal-backdrop {
  position: fixed;
  top: 0; left: 0; width: 100vw; height: 100vh;
  background: rgba(0, 0, 0, 0.5);
  display: flex; justify-content: center; align-items: center;
}

.modal-content {
  background: white; padding: 20px; border-radius: 8px; min-width: 300px;
}

.modal-actions {
  display: flex;
  justify-content: flex-end;
}

.dark-text {
  color: #35495e;
}

.error-box {
  background-color: #ff6b6b;
  color: #920000;
  padding: 6px 18px;
  margin: 2px 6px;
  border: none;
  border-radius: 4px;
}
</style>