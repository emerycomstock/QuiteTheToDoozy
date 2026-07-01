<template>
  <button class="base-button">
    <slot></slot> 
  </button>
</template>

<style scoped>
.base-button {
  background-color: #42b883; /* Vue Green */
  color: #ffffff;
  padding: 6px 18px;
  margin: 2px 6px;
  border: none;
  border-radius: 4px;
  font-size: 14px;
  cursor: pointer;
  transition: background 0.2s ease;
}

/* Hover style */
.base-button:hover {
  background-color: #35495e; /* Vue Dark Gray */
}

/* Disabled style */
.base-button:disabled {
  background-color: #cccccc;
  cursor: not-allowed;
}
</style>