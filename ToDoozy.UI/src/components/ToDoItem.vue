<script setup lang="ts">
import { ref } from 'vue'
import Check from '@primevue/icons/check'
import Ban from '@primevue/icons/ban'
import Trash from '@primevue/icons/trash'

const props = defineProps({
    id: {type: Number, required: true},
    title: {type: String, requred: true},
    status: {type: String, required: true}
})

// Control modal visibility
const isEditModalOpen = ref(false)

// Define structured event payloads emitted on close
const emit = defineEmits<{
  updateSuccess: []
}>()

const handleUpdateSuccess = () => {
  emit('updateSuccess')
}

// Modal open function
const openEditModal = () => {

}

// Quick update functions
const completeToDo = () => {

}

const abandonToDo = () => {

}

const deleteToDo = () => {

}
</script>

<template>
    <div class="todo-item" @click="openEditModal()">
        <div class="todo-left">
            <Check class="icon" @click="completeToDo()" />
            <div class="todo-title">{{ title }}</div>
        </div>
        <div class="todo-right">
            <div :class="status">{{ status }}</div>
            <Ban class="icon" @click="abandonToDo()" />
            <Trash class="icon" @click="deleteToDo()"/>
        </div>
    </div>
</template>

<style scoped>
.todo-item {
    background-color: #8c918f;
    color: #ffffff;
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

.Complete {
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