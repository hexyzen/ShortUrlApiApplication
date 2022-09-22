import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ShorturlapiService {

  readonly shorturlAPIUrl = "https://localhost:7139/api";

  constructor(private http:HttpClient) { }

  getShorturlList():Observable<any[]> {
    return this.http.get<any>(this.shorturlAPIUrl + '/links');
  }

  getShorturlLink(id:number| string) {
    return this.http.get(this.shorturlAPIUrl + `/links${id}`);
  }



  addShortLink(data:any)
  {
    return this.http.post(this.shorturlAPIUrl + '/links', data);
  }
  

deleteShortLink(id:number| string)
{
  return this.http.delete(this.shorturlAPIUrl + `/links/${id}`)
}


}

