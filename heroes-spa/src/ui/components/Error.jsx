import { useRouteError } from "react-router-dom";
import { Navbar } from "./NavBar";

export const Error = () => {
    const error = useRouteError();
    return (
        <>
            <Navbar />
            <h1 className="alert alert-danger text-center">
                {`${error.status} - ${error.statusText}`}
            </h1>
        </>
    );
};
