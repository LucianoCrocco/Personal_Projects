import { useContext } from 'react';
import { useNavigate } from 'react-router-dom';
import { useForm } from '../../hooks/useForm';
import { AuthContext } from '../context';

export const LoginPage = () => {
    const navigate = useNavigate();
    const { login } = useContext(AuthContext);
    const { name, onInputChange } = useForm({ name: '' });

    const onLogin = (e) => {
        e.preventDefault();
        const text = name.trim();
        if (text.length <= 3) return;

        const goTo = localStorage.getItem('lastpath') || '/';
        login(text);
        navigate(goTo, {
            replace: true,
        });
    };

    return (
        <div className="container mt-5">
            <h1>Login</h1>
            <hr />
            <form onSubmit={onLogin}>
                <label htmlFor="name" className="form-label">
                    Please enter your name
                </label>
                <input
                    type="text"
                    name="name"
                    className="form-control"
                    onChange={onInputChange}
                />
                <button className="btn btn-primary mt-2">Login</button>
            </form>
        </div>
    );
};
