import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContatosComponent } from './components/contatos/contatos.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { PalestrantesComponent } from './components/palestrantes/palestrantes.component';
import { LoginComponent } from './components/user/login/login.component';
import { PerfilComponent } from './components/user/perfil/perfil.component'
import { RegistrationComponent } from './components/user/registration/registration.component';
import { UserComponent } from './components/user/user.component';
import { EventosComponent } from './eventos/eventos.component';
import { ModalComponent } from './eventos/modal/modal.component';


const routes: Routes = [
  { path: 'user', component:UserComponent,
  children:[
    {path: 'login', component:LoginComponent},
    {path: 'registration', component:RegistrationComponent},
  ]},
  { path: 'user/perfil', component:PerfilComponent},
  { path: 'eventos', component:EventosComponent},
  { path: 'dashboard', component:DashboardComponent},
  { path: 'contatos', component:ContatosComponent},
  { path: 'palestrantes', component:PalestrantesComponent},
  { path: '', redirectTo: 'dashboard', pathMatch: 'full'},
  { path: '**', redirectTo: 'dashboard', pathMatch: 'full'}


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
