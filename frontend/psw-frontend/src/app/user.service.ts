import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

const url = 'http://localhost:5000';

@Injectable({
  providedIn: 'root'
})
export class UserService {

 //url: string;

  constructor(private http: HttpClient) 
  { 
    //this.url = "http://" + environment.apiUrl + ":" + environment.port;
  }

  public registration(body: any) : Observable<any>{ 
    return this.http.post(url + `/registration`, body);
  }

  /*public registration(body: any) : Observable<any>{ 
    return this.http.post(url + `/registration`, body);
  }
*/
}
