import { Injectable } from '@angular/core';
import { HttpClient,HttpClientModule, HttpResponse, HttpRequest, HttpHeaders } from '@angular/common/http';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import { Observable } from 'rxjs';
import 'rxjs/add/observable/fromEvent';
import 'rxjs/add/operator/timeout';
import 'rxjs/Observable';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/timeoutWith';
//import { map } from 'rxjs/operators';
import 'rxjs/Rx';
import { map, filter, switchMap } from 'rxjs/operators';
/*
  Generated class for the DataservicesProvider provider.

  See https://angular.io/guide/dependency-injection for more info on providers
  and Angular DI.
*/
@Injectable({
  providedIn: 'root'
})
export class DataservicesProvider {

  constructor(public http: HttpClient) {
  }

  getData(url: string) {
    let headers = new HttpHeaders();
    headers.append("Access-Control-Allow-Origin", "*");
    headers.append('Content-Type', 'application/json');
    let options = {
      headers: headers
   };
    // let options = new RequestOptions({ headers: headers });
    return this.http.get(url, options)
      .pipe(map((response: any) => response.json()));
      
    //// .pipe(
    //  .map(res => res)
    //  .catch(this.handleError);
    ////  );
  }

  PostData(url: string, data: any) {
    
    var items = this.http.post(url, data)
         .map(res => res)
      .catch(this.handleError);
    //  .pipe(map((response: any) => response.json()));
    //console.log(items);
    return items;
      //.catch(this.handleError);
  }


  //PostDataWithHeader(url: string, model: any): Observable<any> {
  //  let body = JSON.stringify(model);
  //  let headers = new HttpHeaders();
  //  headers.append("Access-Control-Allow-Origin", "*");
  //  headers.append('Content-Type', 'application/json');
  //  let options = {
  //    headers: headers
  // };
  //  return this.http.post(url, body, options)
  //    .timeoutWith(30000, Observable.throw(new Error("Error message")))
  //    .map((response: Response) => <any>response.json())
  //    .catch(this.handleError);
  //}

  // PostData(url: string, data: any) {
  //   return this.http.post(url, data)
  //     .timeoutWith(30000, Observable.throw(new Error("Error message")))
  //     .map(res => res.json())
  //     .catch(this.handleError);
  // }
  // PostDataWithHeader(url: string, model: any): Observable<any> {
  //   let body = JSON.stringify(model);
  //   let headers = new HttpHeaders();
  //   headers.append("Access-Control-Allow-Origin", "*");
  //   headers.append('Content-Type', 'application/json');
  //   let options = {
  //     headers: headers
  //  };
  //   return this.http.post(url, body, options)
  //    // .timeoutWith(30000, Observable.throw(new Error("Error message")))
  //     .map((response: Response) => <any>response.json())
  //     .catch(this.handleError);
  // }

  private handleError(error: Response | any) {
    // In a real world app, we might use a remote logging infrastructure  
    let errMsg: string;
    if (error instanceof Response) {
      const body = error.json() || '';
      const err = JSON.stringify(body);
      errMsg = `${error.status} - ${error.statusText || ''} ${err}`;
    } else {
      errMsg = error.message ? error.message : error.toString();
    }
    console.error(errMsg);
    return Observable.throw(errMsg);
  }
}
