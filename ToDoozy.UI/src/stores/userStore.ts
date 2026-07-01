import { defineStore } from 'pinia'
import { ref } from 'vue'
import { Mutex } from 'async-mutex';
import axios from 'axios'
import type { AuthState } from '@/types/auth.ts'

export const useUserStore = defineStore('user', () => {
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
        errorMessage.value = null;
        try {
            if (await login(email, password) || (await register(email, password) && await login(email, password))) {
                // Success
                return;
            }
            if (!errorMessage.value) {
                errorMessage.value = "Unable to login or register"
            }
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

        errorMessage.value = null
        try {
            const response = await axios.post('https://127.0.0.1:7081/refresh', { refreshToken: authState.value.refreshToken })
            console.log(`Refresh response: [${response.status}] ${response.statusText}`)
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
            if (axios.isAxiosError(err)) {
                console.error(`Refresh failed: [${err.response?.status}] ${err.response?.statusText}\n${JSON.stringify(err.response?.data)}`)
            } else {
                console.error('Refresh failed, non-axios:', err);
            }
            errorMessage.value = "Token refresh failed"
            clearTimer();
            setUnauthenticated(authState.value.userEmail ?? "")
        }
    }

    async function login(email: string, password: string): Promise<boolean> {
        try {
            const response = await axios.post('https://127.0.0.1:7081/login', { email: email, password: password })
            console.log(`Login response: [${response.status}] ${response.statusText}`)
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
            if (axios.isAxiosError(err)) {
                console.error(`Login failed: [${err.response?.status}] ${err.response?.statusText}\n${JSON.stringify(err.response?.data)}`)
            } else {
                console.error('Login failed, non-axios:', err);
            }
            return false;
        }
    }

    async function register(email: string, password: string): Promise<boolean> {
        try {
            var response = await axios.post('https://127.0.0.1:7081/register', { email: email, password: password })
            console.log(`Register response: [${response.status}] ${response.statusText}`)
            return true
        } catch (err) {
            if (axios.isAxiosError(err)) {
                console.error(`Register failed: [${err.response?.status}] ${err.response?.statusText}\n${JSON.stringify(err.response?.data)}`)
                if (err.response?.status == 400 && err.response?.data.errors) {
                    let errors: string[] = []
                    Object.keys(err.response.data.errors).forEach((key) => {
                        const value = err.response?.data.errors[key]
                        errors = Array.isArray(value) ? [...errors, ...value] : errors
                    });
                    errorMessage.value = errors.join('\n')
                }
            } else {
                console.error('Register failed, non-axios:', err);
            }
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
