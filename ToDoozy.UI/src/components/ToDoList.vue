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

const includeNotStarted = defineModel<boolean>('includeNotStarted', { default: true })
const includeInProgress = defineModel<boolean>('includeInProgress', { default: true })
const includeCompleted = defineModel<boolean>('includeCompleted', { default: true })
const includeAbandoned = defineModel<boolean>('includeAbandoend', { default: true })
const searchQuery = defineModel<string>('searchQuery', { default: '' })

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
        var queryParam = searchQuery.value ? `&q=${searchQuery.value}` : ''
        var statuses = []
        if (includeNotStarted.value) statuses.push('NotStarted')
        if (includeInProgress.value) statuses.push('InProgress')
        if (includeCompleted.value) statuses.push('Completed')
        if (includeAbandoned.value) statuses.push('Abandoned')
        var url = `https://127.0.0.1:7081/todo?page=${currentPage.value}&limit=${itemsPerPage.value}&status=${statuses.join(',')}${queryParam}`;
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
            <div class="upper-control-search">
                <input @change="refresh()" class="search-bar" v-model="searchQuery" placeholder="Search..."/>
                <div>
                    <input @change="refresh()" type="checkbox" id="not-started" v-model="includeNotStarted" />
                    <label class="checkbox-label" for="not-started">Not Started</label>
                    <input @change="refresh()" type="checkbox" id="in-progress" v-model="includeInProgress" />
                    <label class="checkbox-label" for="in-progress">In Progress</label>
                    <input @change="refresh()" type="checkbox" id="completed" v-model="includeCompleted" />
                    <label class="checkbox-label" for="completed">Completed</label>
                    <input @change="refresh()" type="checkbox" id="abandoned" v-model="includeAbandoned" />
                    <label class="checkbox-label" for="abandoned">Abandoned</label>
                </div>
            </div>
            <div>
                <BaseButton @click="refresh()"><Refresh /></BaseButton>
                <BaseButton @click="openCreateModal()"><Plus /></BaseButton>
            </div>
        </div>

        <div class="content-row-container">
            <ToDoItem v-for="item in items" :key="item.id" :id="item.id" :title="item.title" :status="item.status" @updateSuccess="refresh"></ToDoItem>
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
    align-items: top;
}

.upper-control-search {
    flex: 1;
    margin-right: 12px;
}

.checkbox-label {
    padding: 6px;
}

.search-bar {
    width: 100%;
    font-size: 14px;
    border: none;
    border-radius: 4px;
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