import { defineStore } from 'pinia'
import { ref } from 'vue'
import { Mutex } from 'async-mutex';
import axios from 'axios'
import type { AuthState } from '@/types/auth.ts'

export const userStore = defineStore('user', () => {
    // State
    const timerId = ref<number|null>(null)
    const authState = ref<AuthState>({
        userEmail: "",
        accessToken: "",
        refreshToken: "",
        expiresIn: 0,
        isAuthenticated: false
    })
    const isLoading = ref<boolean>(false)
    const errorMessage = ref<string|null>(null)

    // Mutexes
    const timerMutex = new Mutex()

    // Getters (none)

    // Actions
    async function loginOrRegister(email: string, password: string): Promise<void> {
        isLoading.value = true;
        errorMessage.value = "";
        try {
            if (await login(email, password) || (await register(email, password) && await login(email, password))) {
                // Success
                return;
            }
            errorMessage.value = "Incorrect password"
            setUnauthenticated(authState.value.userEmail ?? "")
        } finally {
            isLoading.value = false;
        }
    }

    async function logout(): Promise<void> {
        clearTimer();
        setUnauthenticated("");
    }

    async function setTimer() {
        // Prevent duplicate timers if one is already running
        const release = await timerMutex.acquire();

        try {
            if (timerId.value) {
                clearInterval(timerId.value)
            }

            timerId.value = setInterval(() => {
                refreshToken()
            }, authState.value.expiresIn * 1000 * 0.7)
        } finally {
            release()
        }
    }

    async function clearTimer() {
        // Prevent duplicate timers if one is already running
        const release = await timerMutex.acquire();

        try {
            if (timerId.value) {
                clearInterval(timerId.value)
                timerId.value = null
            }
        } finally {
            release()
        }
    }

    async function refreshToken(): Promise<void> {
        if (!authState.value.isAuthenticated) {
            return; // No-op, not authenticated
        }

        try {
            const response = await axios.post('https://localhost:7081/refresh', { refreshToken: authState.value.refreshToken })
            authState.value = {
                userEmail: authState.value.userEmail,
                accessToken: response.data.accessToken,
                refreshToken: response.data.refreshToken,
                expiresIn: response.data.expiresIn,
                isAuthenticated: true
            }
            setTimer();
        } catch (err) {
            // Failure, set to unauthenticated
            console.error(err)
            errorMessage.value = "Token refresh failed"
            clearTimer();
            setUnauthenticated(authState.value.userEmail ?? "")
        }
    }

    async function login(email: string, password: string): Promise<boolean> {
        try {
            const response = await axios.post('https://localhost:7081/login', { email: email, password: password })
            authState.value = {
                userEmail: email,
                accessToken: response.data.accessToken,
                refreshToken: response.data.refreshToken,
                expiresIn: response.data.expiresIn,
                isAuthenticated: true
            }
            setTimer();
            return true
        } catch (err) {
            console.error(err)
            return false;
        }
    }

    async function register(email: string, password: string): Promise<boolean> {
        try {
            await axios.post('https://localhost:7081/register', { email: email, password: password })
            return true
        } catch (err) {
            console.error(err)
            return false;
        }
    }

    async function setUnauthenticated(email: string) {
        authState.value = {
            userEmail: email,
            accessToken: "",
            refreshToken: "",
            expiresIn: 0,
            isAuthenticated: false
        }
    }

    return { authState, isLoading, errorMessage, loginOrRegister, logout }
})
