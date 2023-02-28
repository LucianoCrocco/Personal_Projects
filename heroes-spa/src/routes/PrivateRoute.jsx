import { useContext, useEffect } from 'react';
import { Navigate, useLocation } from 'react-router-dom';
import { AuthContext } from '../auth';

export const PrivateRoute = ({ children }) => {
    const { state } = useContext(AuthContext);

    if (!state.logged) {
        return <Navigate to="/login" />;
    }

    const { pathname, search } = useLocation();

    useEffect(() => {
        const lastPath = pathname + search;
        localStorage.setItem('lastpath', lastPath);
    }, [pathname, search]);

    return children;
};
