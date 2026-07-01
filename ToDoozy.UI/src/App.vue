<script setup lang="ts">
import ToDoList from './components/ToDoList.vue'
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
}

main {
  overflow-y: auto;
}

.logo {
  display: block;
  margin: 0 auto 2rem;
}

@media (min-width: 1024px) {
  header {
    display: flex;
    place-items: center;
    padding-right: calc(var(--section-gap) / 2);
  }
}
</style>
