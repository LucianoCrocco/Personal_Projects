import { useContext } from 'react';
import { AuthContext } from '../../auth';

export const Welcome = () => {
    const { state } = useContext(AuthContext);
    return (
        <>
            <h1 className="h1">Welcome {state.name}!</h1>
            <h1 className="mt-5 text-info">Simple Explanation</h1>
            <p className="text-info-emphasis">
                This app was created aiming to deploy every hook React has
                available. Usage of State, Effect, Context, Reducer, Memos, etc.
            </p>
            <p className="text-info-emphasis">
                Also this SPA introducted me to the React Router Dom. Public and
                Private routes may not work due to Netlify error handleling, but
                if you head to the source code and run the app you'll see that
                Private and Public routes are working correctly.
            </p>
        </>
    );
};
