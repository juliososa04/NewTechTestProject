import { Injectable } from '@angular/core';
import { AuthorModel } from 'src/app/Models/Author/author-model';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthorRepositoryService {

  public list: AuthorModel[];
  public ViwMode = "Create New Author";
   //difene states
    
  //rool url api
  readonly rootUrl="http://localhost:27808/api/Author";
  // Declare form for user data manage
  form: FormGroup = new FormGroup({
      ID: new FormControl(null),
      IDAuthor :new FormControl('',Validators.required),
      FirstName :new FormControl(''),
      LastName :new FormControl(1,Validators.required),
  }); 
  

  constructor(private http: HttpClient) { }
  //#region Public Method
  
  // Persit Author
  CreateAuthor(formData: AuthorModel){
    
    if(formData.ID==null) formData.ID=0;
    return this.http.post(this.rootUrl,formData)
  }
  //update Author
  UpdateAuthor(formData: AuthorModel){
    return this.http.put(this.rootUrl+"/"+formData.ID,formData);
  }
  // Delete Author
  DeleteAuthor(id: number){
    return this.http.delete(this.rootUrl+"/"+id);
  }
  //Refress List 
  refressList(BookId) : Observable<AuthorModel[]>  {
    
    return this.http.get(this.rootUrl+"/GetByBook?id="+BookId).pipe(
      
       map(res=> this.list=res as  AuthorModel [])
   
    )
   //#endregion
  }
  GetAuthorById(Id:number) : Observable<AuthorModel>  {
    
    return this.http.get(this.rootUrl+"/"+Id).pipe(
      
       map(res=> res as  AuthorModel)
   
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
