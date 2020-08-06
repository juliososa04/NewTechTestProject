import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CustomvalidatorService {

  constructor(private http: HttpClient) { }
  readonly rootUrl="http://localhost:29515/api";
  
  getUserbyUserID(userid: string){
    return this.http.get(this.rootUrl+"/UsersByUserid/"+userid);
  }
}
