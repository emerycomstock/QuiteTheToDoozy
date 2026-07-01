<script setup lang="ts">
import { ref, computed } from 'vue'
import BaseButton from './BaseButton.vue'
import CreateModal from './CreateModal.vue'

// Temp items for testing
const items = ref(Array.from({ length: 50 }, (_, i) => ({ id: i + 1, title: `ToDo ${i + 1}`, status: 'In Progress' })))
const currentPage = ref(1)
const itemsPerPage = ref(10)

const totalPages = computed(() => Math.ceil(items.value.length / itemsPerPage.value))
const paginatedItems = computed(() => {
  const start = (currentPage.value - 1) * itemsPerPage.value
  return items.value.slice(start, start + itemsPerPage.value)
})

function changePage(page: number) {
  if (page >= 1 && page <= totalPages.value) currentPage.value = page
}

// Control modal visibility
const isCreateModalOpen = ref(false)
const isEditModalOpen = ref(false)

// Modal open functions
const openCreateModal = () => {
    isCreateModalOpen.value = true
}
const openEditModal = () => {

}

const refresh = () => {

}
</script>

<template>
    <div class="wrapper">
        <div class="upper-control-row">
            <BaseButton @click="refresh()">Refresh</BaseButton>
            <BaseButton @click="openCreateModal()">Create</BaseButton>
        </div>

        <div class="content-row-container">
            <ul>
                <li v-for="item in paginatedItems" :key="item.id">
                    [{{ item.status }}] {{ item.title }}
                </li>
            </ul>
        </div>

        <div class="lower-control-row">
            <BaseButton @click="changePage(currentPage - 1)" :disabled="currentPage === 1">Prev</BaseButton>
            <p class="page-number">{{ currentPage }}</p>
            <BaseButton @click="changePage(currentPage + 1)" :disabled="currentPage === totalPages">Next</BaseButton>
        </div>
    </div>

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