import { RouterProvider } from "react-router-dom";
import { AuthProvider } from "./auth";
import { router } from "./routes/AppRouter";

export const HeroesApp = () => {
    return (
        <AuthProvider>
            <RouterProvider router={router} />
        </AuthProvider>
    );
};
