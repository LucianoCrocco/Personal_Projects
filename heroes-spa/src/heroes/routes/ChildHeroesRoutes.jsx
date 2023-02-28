import { DC, Hero, Marvel, Search, Welcome } from '../index';

export const ChildHeroesRoutes = [
    {
        path: '/',
        element: <Welcome />,
    },
    {
        path: 'marvel',
        element: <Marvel />,
    },
    {
        path: 'dc',
        element: <DC />,
    },
    {
        path: 'search',
        element: <Search />,
    },
    {
        path: 'hero/:id',
        element: <Hero />,
    },
];
