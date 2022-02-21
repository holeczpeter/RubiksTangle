import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {

    path: '',
    loadChildren: () => import('./board/board.module').then(module => module.BoardModule),

  },
  {

    path: 'board',
    loadChildren: () => import('./board/board.module').then(module => module.BoardModule),

  },

];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
