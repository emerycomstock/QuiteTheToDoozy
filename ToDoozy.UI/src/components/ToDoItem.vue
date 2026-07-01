<script setup lang="ts">
import { ref } from 'vue'
import { useUserStore } from '@/stores/userStore.ts'
import { storeToRefs } from 'pinia'
import Check from '@primevue/icons/check'
import Ban from '@primevue/icons/ban'
import Trash from '@primevue/icons/trash'
import ArrowUp from '@primevue/icons/arrowup'
import axios from 'axios'
import UpdateModal from './UpdateModal.vue'

const store = useUserStore()
const { authState } = storeToRefs(store)

const props = defineProps({
    id: {type: Number, required: true},
    title: {type: String, requred: true},
    status: {type: String, required: true}
})

// Control modal visibility
const description = defineModel<string>('description', { default: "" })
const isEditModalOpen = ref(false)

// Define structured event payloads emitted on close
const emit = defineEmits<{
  updateSuccess: []
}>()

const handleUpdateSuccess = () => {
  emit('updateSuccess')
}

// Modal open function
const openEditModal = async () => {
    try {
        var response = await axios.get(`https://127.0.0.1:7081/todo/${props.id}`, 
        {
            headers: { 'Authorization': `Bearer ${authState.value.accessToken}` }
        })
        console.log(`Update ToDo Status result: ${JSON.stringify(response.data)}`)
        
        description.value = response.data.description;
        isEditModalOpen.value = true
    } catch (err) {
        if (axios.isAxiosError(err)) {
            console.error(`Update ToDo Status failed: [${err.response?.status}] ${err.response?.statusText}\n${JSON.stringify(err.response?.data)}`)
        } else {
            console.error('Update ToDo Status failed, non-axios:', err);
        }
    }
}

// Quick update functions
const setToDoStatus = async (status: string) => {
  try {
    var response = await axios.patch(`https://127.0.0.1:7081/todo/${props.id}`, {
      status: status
    }, 
    {
        headers: { 'Authorization': `Bearer ${authState.value.accessToken}` }
    })
    console.log(`Update ToDo Status result: ${JSON.stringify(response.data)}`)
    emit('updateSuccess')
  } catch (err) {
      if (axios.isAxiosError(err)) {
          console.error(`Update ToDo Status failed: [${err.response?.status}] ${err.response?.statusText}\n${JSON.stringify(err.response?.data)}`)
      } else {
          console.error('Update ToDo Status failed, non-axios:', err);
      }
  }
}

const deleteToDo = async () => {
    try {
        var response = await axios.delete(`https://127.0.0.1:7081/todo/${props.id}`,
        {
            headers: { 'Authorization': `Bearer ${authState.value.accessToken}` }
        })
        console.log(`Delete ToDo result: ${JSON.stringify(response.data)}`)
        emit('updateSuccess')
    } catch (err) {
        if (axios.isAxiosError(err)) {
            console.error(`Delete ToDo failed: [${err.response?.status}] ${err.response?.statusText}\n${JSON.stringify(err.response?.data)}`)
        } else {
            console.error('Delete ToDo failed, non-axios:', err);
        }
    }
}
</script>

<template>
    <div class="todo-item">
        <div class="todo-left">
            <Check v-if="status == 'InProgress'" class="icon" @click="setToDoStatus('Completed')" />
            <ArrowUp v-if="status == 'NotStarted'" class="icon" @click="setToDoStatus('InProgress')" />
            <a @click="openEditModal()" class="todo-title">{{ title }}</a>
        </div>
        <div class="todo-right">
            <div :class="status">{{ status }}</div>
            <Ban v-if="status == 'NotStarted' || status == 'InProgress'" class="icon" @click="setToDoStatus('Abandoned')" />
            <Trash class="icon" @click="deleteToDo()"/>
        </div>
    </div>

    <UpdateModal
        v-model:isOpen="isEditModalOpen"
        :id="id"
        :title="title"
        :description="description"
        :status="status"
        @updateSuccess="handleUpdateSuccess()" />
</template>

<style scoped>
.todo-item {
    background-color: #8c918f;
    color: white;
    padding: 6px 18px;
    margin: 2px;
    border: none;
    border-radius: 4px;
    font-size: 14px;
    cursor: pointer;
    transition: background 0.2s ease;
    display: flex;
    justify-content: space-between
}

.todo-left {
    display: flex;
    justify-content: flex-start;
    align-items: center;
}

.todo-right {
    display: flex;
    justify-content: flex-end;
    align-items: center;
}

/* Hover style */
.todo-item:hover {
  background-color: #42b883;
}

.todo-title {
    padding: 0px 10px;
    color: white;
}

.todo-title:hover {
    color:  #35495e; /* Vue Dark Gray */
}

.icon {
    padding: 0px 10px;
}

.NotStarted {
    padding: 6px 18px;
    margin: 2px 6px;
    border: none;
    border-radius: 4px;
    background-color: #35495e; /* Vue Dark Gray */
    color: white;
}

.InProgress {
    padding: 6px 18px;
    margin: 2px 6px;
    border: none;
    border-radius: 4px;
    background-color: #35495e; /* Vue Dark Gray */
    color: yellow;
}

.Completed {
    padding: 6px 18px;
    margin: 2px 6px;
    border: none;
    border-radius: 4px;
    background-color: #35495e; /* Vue Dark Gray */
    color: green;
}

.Abandoned {
    padding: 6px 18px;
    margin: 2px 6px;
    border: none;
    border-radius: 4px;
    background-color: #35495e; /* Vue Dark Gray */
    color: orangered;
}
</style>