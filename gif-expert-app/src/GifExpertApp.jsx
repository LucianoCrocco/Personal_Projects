import { useState } from 'react';
import { AddCategory, GifGrid } from './components';

export const GifExpertApp = () => {
    const [categories, setCategories] = useState([]);

    const onAddCategory = (category) => {
        if (!categories.includes(category)) {
            setCategories([category, ...categories]);
        }
    };

    return (
        <>
            <h1 className="titulo-app">Simple Explanation</h1>
            <p className="explanation">
                This is my first React App, it's a simple introduction to hooks,
                ReactDOM, how React works, etc.
            </p>
            <hr />
            <h1>GifExpertApp</h1>

            <AddCategory onNewCategory={onAddCategory} />

            {categories.map((category) => (
                <GifGrid key={category} category={category} />
            ))}
        </>
    );
};
