import { Injectable } from '@angular/core';
import { BookModel } from 'src/app/Models/Book/book-model';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class BookrepositoryService {

  public list: BookModel[];
  public ViwMode = "Create New Book";
  public ViwModeDisabled = false;
   //difene states
    
  //rool url api
  readonly rootUrl="http://localhost:27808/api/Book";
  // Declare form for user data manage
  form: FormGroup = new FormGroup({
      ID: new FormControl(null),
      Title :new FormControl('',Validators.required),
      Description :new FormControl(''),
      PageCount :new FormControl(1,Validators.required),
      PublishDate :new FormControl('',[Validators.required]),
      Excerpt :new FormControl('',[Validators.required])
  }); 
  

  constructor(private http: HttpClient) { }
  //#region Public Method
  
  // Persit Book
  CreateBook(formData: BookModel){
    
    if(formData.ID==null) formData.ID=0;
    return this.http.post(this.rootUrl,formData)
  }
  //update Book
  UpdateBook(formData: BookModel){
    return this.http.put(this.rootUrl+"/"+formData.ID,formData);
  }
  // Delete Book
  DeleteBook(id: number){
  debugger;
    return this.http.delete(this.rootUrl+"/"+id);
  }
  //Refress List 
  refressList() : Observable<BookModel[]>  {
    
    return this.http.get(this.rootUrl).pipe(
      
       map(res=> this.list=res as  BookModel [])
   
    )
   //#endregion
  }
  GetBookById(Id:number) : Observable<BookModel>  {
    
    return this.http.get(this.rootUrl+"/"+Id).pipe(
      
       map(res=> res as  BookModel)
   
    )
   //#endregion
  }

  

  initializeForm(){
    this.form.setValue({
      ID: null,
      Title :'',
      Description :'',
      PageCount :0,
      Excerpt :'',
      PublishDate :'',
      
    })
  } 
}
