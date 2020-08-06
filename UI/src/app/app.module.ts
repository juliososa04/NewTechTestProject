import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MaterialModule } from './material/material.module';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { NotificationService } from './shared/notification.service';
import {NgxMaskModule} from 'ngx-mask'
import { CustomvalidatorService } from './shared/customvalidator.service';
import { BookManageComponent } from './book/book-manage/book-manage.component';
import { BookListComponent } from './book/book-list/book-list.component';
import { AuthorListComponent } from './author/author-list/author-list.component';
import { AuthorManageComponent } from './author/author-manage/author-manage.component';
import { BookCrudComponent } from './book/book-crud/book-crud.component';



@NgModule({
  declarations: [
    AppComponent,
    BookManageComponent,
    BookListComponent,
    AuthorListComponent,
    AuthorManageComponent,
    BookCrudComponent,
  
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    ReactiveFormsModule,
    HttpClientModule,
    NgxMaskModule.forRoot()
  ],
  providers: [NotificationService,CustomvalidatorService],
  bootstrap: [AppComponent],
  entryComponents:[BookCrudComponent]
})
export class AppModule { }
