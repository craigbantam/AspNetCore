import { Routes } from '@angular/router';
import { HomeItemListComponentComponent } from './features/home-items/components/home-item-list/home-item-list-component';

export const routes: Routes = [{
    path: '',
    component: HomeItemListComponentComponent,
    pathMatch: 'full'
}];
