import {HttpClientModule} from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import {NgTinyUrlModule} from 'ng-tiny-url';

import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component'; 
import { ShorturlComponent } from './shorturl/shorturl.component';
import { ShowShorturlComponent } from './shorturl/show-shorturl/show-shorturl.component';
import { AddEditShortUrlComponent } from './shorturl/add-edit-shorturl/add-edit-shorturl.component';
import { ShorturlapiService } from './shorturlapi.service';

@NgModule({
  declarations: [
    AppComponent,

    ShorturlComponent,
    ShowShorturlComponent,
    AddEditShortUrlComponent
  ],
  imports: [
    BrowserModule,
    NgTinyUrlModule,
    AppRoutingModule,

    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [ShorturlapiService ],
  bootstrap: [AppComponent]
})
export class AppModule { }
