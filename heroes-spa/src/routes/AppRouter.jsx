import { createBrowserRouter } from 'react-router-dom';
import { LoginPage } from '../auth';
import { HeroesRoutes, ChildHeroesRoutes } from '../heroes';
import { PrivateRoute } from './PrivateRoute';
import { PublicRoute } from './PublicRoute';
import { Error } from '../ui';

export const router = createBrowserRouter([
    //HEROES
    {
        path: '/',
        element: (
            <PrivateRoute>
                <HeroesRoutes />
            </PrivateRoute>
        ),
        children: ChildHeroesRoutes,
        errorElement: <Error />,
    },
    //LOGIN
    {
        path: 'login',
        element: (
            <PublicRoute>
                <LoginPage />
            </PublicRoute>
        ),
        errorElement: <Error />,
    },
]);
