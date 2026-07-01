<script setup lang="ts">
import { useUserStore } from '@/stores/userStore.ts'
import { storeToRefs } from 'pinia'
import BaseButton from './BaseButton.vue'
import axios from 'axios'
import { ref } from 'vue'

const store = useUserStore()
const { authState } = storeToRefs(store)

const props = defineProps({
    id: {type: Number, required: true},
    title: {type: String, requred: true},
    description: {type: String, required: false},
    status: {type: String, required: true}
})

// Visibility control
const isOpen = defineModel<boolean>('isOpen', { default: false })
const updateFailed = defineModel<boolean>('updateFailed', { default: false })

// Form control bindings
const title = defineModel<string>('title')
const description = defineModel<string>('description')
const status = defineModel<string>('status')

const statuses = ref([
  { id: 1, text: 'Not Started', value: 'NotStarted' },
  { id: 2, text: 'In Progress', value: 'InProgress' },
  { id: 3, text: 'Completed', value: 'Completed' },
  { id: 4, text: 'Abandoned', value: 'Abandoned' }
])

title.value = props.title
description.value = props.description
status.value = props.status

// Define structured event payloads emitted on close
const emit = defineEmits<{
  updateSuccess: []
}>()

const handleConfirm = async () => {
  try {
    var response = await axios.patch(`https://127.0.0.1:7081/todo/${props.id}`, {
      title: title.value,
      description: description.value,
      status: status.value
    }, 
    {
        headers: { 'Authorization': `Bearer ${authState.value.accessToken}` }
    })
    console.log(`Update ToDo result: ${JSON.stringify(response.data)}`)
    emit('updateSuccess')
    updateFailed.value = false
    isOpen.value = false
  } catch (err) {
      if (axios.isAxiosError(err)) {
          console.error(`Create ToDo failed: [${err.response?.status}] ${err.response?.statusText}\n${JSON.stringify(err.response?.data)}`)
      } else {
          console.error('Create ToDo failed, non-axios:', err);
      }
      updateFailed.value = true;
  }
}

const handleCancel = () => {
  updateFailed.value = false;
  isOpen.value = false;
}
</script>

<template>
  <Teleport to="body">
    <div v-if="isOpen" class="modal-backdrop" @click="handleCancel()">
      <div class="modal-content" @click.stop>
        <h3 class="dark-text">Create ToDo</h3>
        <div v-if="updateFailed" class="error-box">
          <p>Failed to update record</p>
        </div>
        <p><i class="dark-text">Title</i></p>
        <input v-model="title" placeholder="My ToDo!"/>
        <p><i class="dark-text">Description</i></p>
        <textarea v-model="description" placeholder="All my details!" rows="3"></textarea>
        <select v-model="status">
            <option v-for="item in statuses" :key="item.id" :value="item.value">
                {{ item.text }}
            </option>
        </select>
        
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