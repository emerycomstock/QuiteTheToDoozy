<script setup lang="ts">
import BaseButton from './BaseButton.vue'
import { useUserStore } from '@/stores/userStore.ts'
import { storeToRefs } from 'pinia'

const store = useUserStore()
const { authState, errorMessage, isLoading } = storeToRefs(store)

// Form control bindings
const email = defineModel<string>('email')
const password = defineModel<string>('password')

const handleLoginRegister = () => {
    // TODO: Validate email and password
    store.loginOrRegister(email.value ?? '', password.value ?? '')
}
</script>

<template>
  <Teleport to="body">
    <div v-if="!authState.isAuthenticated" class="modal-backdrop">
      <div class="modal-content" @click.stop>
        <h3 class="dark-text">Login or Register</h3>
        <div v-if="!isLoading && errorMessage" class="error-box">
          <p style="white-space: pre-line;">{{ errorMessage }}</p>
        </div>
        <p><i class="dark-text">Email</i></p>
        <input tpye="email" v-model="email" placeholder="my.email@host.com"/>
        <p><i class="dark-text">Password</i></p>
        <input type="password" v-model="password" placeholder="P@s$w0rd"/>
        
        <div class="modal-actions">
          <BaseButton @click="handleLoginRegister()">Submit</BaseButton>
        </div>
      </div>
    </div>
  </Teleport>
</template>

<style scoped>
input {
  width: 100%;
}

textarea {
  width: 100%;
}

.modal-backdrop {
  position: fixed;
  top: 0; left: 0; width: 100vw; height: 100vh;
  background: rgba(0, 0, 0, 0.5);
  display: flex; justify-content: center; align-items: center;
}

.modal-content {
  background: white; padding: 20px; border-radius: 8px; min-width: 300px;
}

.modal-actions {
  display: flex;
  justify-content: flex-end;
}

.dark-text {
  color: #35495e;
}

.error-box {
  background-color: #ff6b6b;
  color: #920000;
  padding: 6px 18px;
  margin: 2px 6px;
  border: none;
  border-radius: 4px;
}
</style>