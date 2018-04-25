import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';


import { AppComponent } from './app.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { MainComponent } from './components/main/main.component';
import { WelcomeComponent } from './components/welcome/welcome.component';
import { MenuLargeIconsComponent } from './components/menu-large-icons/menu-large-icons.component';
import { SurveyListComponent } from './components/survey-list/survey-list.component';

const appRoutes: Routes = [
  { path: '', component: WelcomeComponent },
  { path: 'main', component: MainComponent },
  { path: 'surveys', component: SurveyListComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    MainComponent,
    WelcomeComponent,
    MenuLargeIconsComponent,
    SurveyListComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
