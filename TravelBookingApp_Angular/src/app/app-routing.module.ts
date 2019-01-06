import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SearchComponent } from './search/search.component';
import { UserComponent } from './user/user.component';
import { AdduserComponent } from './user/adduser/adduser.component';
import { EdituserComponent } from './user/edituser/edituser.component';
import { DeleteuserComponent } from './user/deleteuser/deleteuser.component';

const routes: Routes = [
  {
    path:'Search',
    component: SearchComponent
  },
  {
    path:'User',
    component: UserComponent
  },
   {
    path: 'User/add',
    component: AdduserComponent
  },
  {
    path: 'user/edit/:id',
    component: EdituserComponent
  },
  {
    path: 'user/delete/:id',
    component: DeleteuserComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
