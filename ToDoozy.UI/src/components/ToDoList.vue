<script setup lang="ts">
import { ref, reactive } from 'vue'
import BaseModal from './CreateModal.vue'

// Control modal visibility
const isCreateModalOpen = ref(false)
const isEditModalOpen = ref(false)
const isAuthModalOpen = ref(false)

const openCreateModal = () => {
    isCreateModalOpen.value = true
}

const openEditModal = () => {

}

const openAuthModal = () => {

}

const refresh = () => {

}
</script>

<template>
    <div>
        <button @click="openCreateModal()">Create</button>
    </div>

    <BaseModal
      v-model:isOpen="isCreateModalOpen"
      @createSuccess="refresh"
    />
</template>