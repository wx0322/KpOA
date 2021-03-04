import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { AppRouteGuard } from '@shared/auth/auth-route-guard';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { UsersComponent } from './users/users.component';
import { TenantsComponent } from './tenants/tenants.component';
import { RolesComponent } from 'app/roles/roles.component';
import { ChangePasswordComponent } from './users/change-password/change-password.component';
import { DailyWorkComponent } from './daily-work/daily-work.component';
import { CreateDailyWorkComponent } from './daily-work/create-daily-work/create-daily-work.component';
import { EditDailyWorkComponent } from './daily-work/edit-daily-work/edit-daily-work.component';
import { ShareLogComponent } from './share-log/share-log.component';

@NgModule({
  imports: [
    RouterModule.forChild([
      {
        path: '',
        component: AppComponent,
        children: [
          { path: 'home', component: ShareLogComponent, canActivate: [AppRouteGuard] },
          { path: 'users', component: UsersComponent, data: { permission: 'Pages.Users' }, canActivate: [AppRouteGuard] },
          { path: 'roles', component: RolesComponent, data: { permission: 'Pages.Roles' }, canActivate: [AppRouteGuard] },
          { path: 'tenants', component: TenantsComponent, data: { permission: 'Pages.Tenants' }, canActivate: [AppRouteGuard] },
          {
            path: 'daily-work',
            children: [
              { path: '', component: DailyWorkComponent, data: { permission: 'Pages.DailyWork' }, canActivate: [AppRouteGuard] },
              { path: 'create', component: CreateDailyWorkComponent, data: { permission: 'Pages.DailyWork' }, canActivate: [AppRouteGuard] },
              { path: 'edit', component: EditDailyWorkComponent, data: { permission: 'Pages.DailyWork' }, canActivate: [AppRouteGuard] },
            ]
          },
          { path: 'share-log', component: ShareLogComponent },
          { path: 'about', component: AboutComponent },
          { path: 'update-password', component: ChangePasswordComponent }
        ]
      }
    ])
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
