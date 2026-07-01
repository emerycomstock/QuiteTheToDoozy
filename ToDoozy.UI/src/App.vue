<script setup lang="ts">
import { ref } from 'vue'
import { userStore } from '@/stores/userStore.ts'
import { storeToRefs } from 'pinia'
import ToDoList from './components/ToDoList.vue'

// Control modal visibility
const isAuthModalOpen = ref(false)

const store = userStore()
const { authState, errorMessage } = storeToRefs(store)

// Modal open function
const openAuthModal = () => {

}

</script>

<template>
  <header>
    <div>
      <h1>Quite the ToDoozy!</h1>
    </div>
  </header>

  <main>
    <ToDoList />
  </main>
</template>

<style scoped>
header {
  line-height: 1.5;
  display: flex;
  justify-content: center;
  align-items: stretch
}

main {
  display: flex;
  flex: 1;
  align-items: stretch
}

.logo {
  display: block;
  margin: 0 auto 2rem;
}
</style>
