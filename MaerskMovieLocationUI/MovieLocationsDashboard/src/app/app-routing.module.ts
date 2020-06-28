import { NgModule, Component } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MLDashBoardComponent } from './mldash-board/mldash-board.component';


const routes: Routes = [
  //{ path: 'MovieLocations', component: MLDashBoardComponent },
  //{ path: '', redirectTo: '/MovieLocations', pathMatch: 'full' }
  { path: '', component: MLDashBoardComponent, pathMatch: "full" },
  { path: "**", component: MLDashBoardComponent, pathMatch: "full" }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
