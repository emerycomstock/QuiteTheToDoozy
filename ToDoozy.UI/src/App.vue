<script setup lang="ts">
import { ref } from 'vue'
import { useUserStore } from '@/stores/userStore.ts'
import { storeToRefs } from 'pinia'
import Times from '@primevue/icons/times'
import ToDoList from './components/ToDoList.vue'
import LoginRegisterModal from './components/LoginRegisterModal.vue'

const store = useUserStore()
const { authState } = storeToRefs(store)
</script>

<template>
  <header>
    <div></div>
    <div>
      <h1>Quite the ToDoozy!</h1>
    </div>
    <div>
      <i>{{ authState.userEmail }}</i>
      <Times @click="store.logout()" />
    </div>
  </header>

  <main>
    <ToDoList />
  </main>

  <LoginRegisterModal/>
</template>

<style scoped>
header {
  line-height: 1.5;
  display: flex;
  justify-content: space-between;
  align-items: stretch;
}

main {
  display: flex;
  flex: 1;
  align-items: stretch;
}

.logo {
  display: block;
  margin: 0 auto 2rem;
}
</style>
