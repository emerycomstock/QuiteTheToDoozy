export interface AuthState {
    userEmail: string;
    accessToken: string;
    refreshToken: string;
    expiresIn: number;
    isAuthenticated: boolean;
}
