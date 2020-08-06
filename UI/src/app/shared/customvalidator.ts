import { AsyncValidator,AbstractControl,ValidationErrors, NG_ASYNC_VALIDATORS, AsyncValidatorFn } from '@angular/forms';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { CustomvalidatorService } from './customvalidator.service';
import { User } from './user';

// fuctions for custom valited for userid
export function uniqueuser(serivce: CustomvalidatorService):AsyncValidatorFn{
    return (control: AbstractControl): Promise<ValidationErrors | null> | Observable<ValidationErrors| null>=>{
        return serivce.getUserbyUserID(control.value).pipe(
           map(users=>{
               console.log(users);
               return users && (users as User []).length>0  ? {"uniqueuser": true} :null;     
           })      
        );
    }
}
//difine custom validator for the password
export function PasswordCustomValidator(control: AbstractControl): { [key: string]: boolean } | null {
  
    // regular expression for evaluate password value
    var rgularExp = {
      SpecialCharater : /[ !@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]/,
      containsNumber : /\d+/,
      containsAlphabet : /[a-zA-Z]/,
    }
  
  var expMatch = { 
    containsNumber:false,
    containsAlphabet:false,
    containSpecialCharater:false 
  };
  expMatch.containsNumber = rgularExp.containsNumber.test(control.value);
  expMatch.containsAlphabet = rgularExp.containsAlphabet.test(control.value);
  expMatch.containSpecialCharater = rgularExp.SpecialCharater.test(control.value);
    if (control.value !== undefined && (!expMatch.containSpecialCharater || !expMatch.containsNumber || !expMatch.containsAlphabet)) {
        return { 'password': true };
    }
    return null;
  }




