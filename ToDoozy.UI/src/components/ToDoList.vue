<script setup lang="ts">
import { ref, computed } from 'vue'
import { useUserStore } from '@/stores/userStore.ts'
import { storeToRefs } from 'pinia'
import type { ToDoPartial } from '@/types/todo.ts'
import Plus from '@primevue/icons/plus'
import Refresh from '@primevue/icons/refresh'
import BaseButton from './BaseButton.vue'
import ToDoItem from './ToDoItem.vue'
import CreateModal from './CreateModal.vue'
import LoginRegisterModal from './LoginRegisterModal.vue'
import axios from 'axios'

const store = useUserStore()
const { authState } = storeToRefs(store)

const items = ref<ToDoPartial[]>([])
const currentPage = ref(1)
const itemsPerPage = ref(10)

function incrementPage() {
    if (items.value.length == itemsPerPage.value) {
        currentPage.value += 1
        refresh()
    }
}

function decrementPage() {
    if (currentPage.value > 1) {
        currentPage.value -= 1
        refresh()
    }
}

// Control modal visibility
const isCreateModalOpen = ref(false)

// Modal open function
const openCreateModal = () => {
    isCreateModalOpen.value = true
}

const refresh = async () => {
    try {
        var url = `https://127.0.0.1:7081/todo?page=${currentPage.value}&limit=${itemsPerPage.value}`;
        var response = await axios.get(url, {
            headers: { 'Authorization': `Bearer ${authState.value.accessToken}` }
        })
        console.log(`Refresh ToDos result: ${JSON.stringify(response.data)}`)
        items.value = response.data.toDos as ToDoPartial[];
    } catch (err) {
        if (axios.isAxiosError(err)) {
            console.error(`Refresh ToDos failed: [${err.response?.status}] ${err.response?.statusText}\n${JSON.stringify(err.response?.data)}`)
        } else {
            console.error('Refresh ToDos failed, non-axios:', err);
        }
    }
}
</script>

<template>
    <div class="wrapper">
        <div class="upper-control-row">
            <BaseButton @click="refresh()"><Refresh /></BaseButton>
            <BaseButton @click="openCreateModal()"><Plus /></BaseButton>
        </div>

        <div class="content-row-container">
            <ToDoItem v-for="item in items" :key="item.id" :id="item.id" :title="item.title" :status="item.status"></ToDoItem>
        </div>

        <div class="lower-control-row">
            <BaseButton @click="decrementPage()" :disabled="currentPage === 1">Prev</BaseButton>
            <p class="page-number">{{ currentPage }}</p>
            <BaseButton @click="incrementPage()" :disabled="items.length != itemsPerPage">Next</BaseButton>
        </div>
    </div>

    <LoginRegisterModal @loginSuccess="refresh"/>
    <CreateModal
      v-model:isOpen="isCreateModalOpen"
      @createSuccess="refresh"
      @updateSuccess="refresh"
    />
</template>

<style scoped>
.wrapper {
    display: flex;
    flex-direction: column;
    flex: 1;
    justify-content: space-between;
    align-items: stretch
}

.upper-control-row {
    display: flex;
    justify-content: flex-end;
}

.content-row-container {
    display: flex;
    flex-direction: column;
    flex: 1;
    justify-content: space-around;
}

.lower-control-row {
    display: flex;
    justify-content: center
}

.page-number {
    padding: 6px 18px;
    margin: 2px 6px;
    font-size: 14px;
}
</style>