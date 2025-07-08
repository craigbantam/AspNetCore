import { Routes } from '@angular/router';

export const routes: Routes = [
    {
        path: 'create',
        loadComponent: () => import('./features/home-items/components/home-item-capture/home-item-capture-component').then(m => m.HomeItemCaptureComponent),
        pathMatch: 'full'
    },
    {
        path: 'edit/:itemId',
        loadComponent: () => import('./features/home-items/components/home-item-edit/home-item-edit-component').then(m => m.HomeItemEditComponent),
        
    }, 
    {
        path: '',
        loadComponent: () => import('./features/home-items/components/home-item-list/home-item-list-component').then(m => m.HomeItemListComponentComponent),
        pathMatch: 'full'
    }
];
