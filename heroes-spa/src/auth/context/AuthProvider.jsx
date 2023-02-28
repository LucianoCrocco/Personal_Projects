import { useReducer } from 'react';
import { AuthContext } from './AuthContext';
import { authReducer } from './authReducer';

import { types } from '../types/types';

const init = () => {
    const name = JSON.parse(localStorage.getItem('name'));

    return {
        logged: !!name,
        name,
    };
};

export const AuthProvider = ({ children }) => {
    const [state, dispatch] = useReducer(authReducer, {}, init);

    const login = (name = '') => {
        const action = {
            type: types.login,
            payload: name,
        };
        localStorage.setItem('name', JSON.stringify(action.payload));
        dispatch(action);
    };

    const logout = () => {
        const action = {
            type: types.logout,
        };
        localStorage.removeItem('name');
        dispatch(action);
    };

    return (
        <AuthContext.Provider value={{ state, login, logout }}>
            {children}
        </AuthContext.Provider>
    );
};
