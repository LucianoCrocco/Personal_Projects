import { useMemo } from "react";
import { getHeroesByPublisher, HeroCard } from "../index";

export const HeroList = ({ publisher }) => {
    try {
        const heroes = useMemo(
            () => getHeroesByPublisher(publisher),
            [publisher]
        );
        return (
            <div className="row rows-cols-1 row-cols-md-3 g-3">
                {heroes.map((heroe) => (
                    <HeroCard key={heroe.id} {...heroe} />
                ))}
            </div>
        );
    } catch (err) {
        return (
            <h1 className="alert alert-danger mx-auto text-center">
                {err.message}
            </h1>
        );
    }
};
