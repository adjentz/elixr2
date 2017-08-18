import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Http, Response, Headers } from '@angular/http';
import 'rxjs/add/operator/toPromise'

@Injectable()
export class ApiService {

  constructor(private http: Http) {

  }

  private getFullUrl(resourcePath: string): string {
    return [environment.apiPath, resourcePath].join('/');
  }
  post<T>(resourceUrl: string, data: any): Promise<T> {
    return new Promise<T>(resolve => {

      let url = this.getFullUrl(resourceUrl);
      let httpObs = this.http.post(url, data)
        .toPromise()
        .then(resp => resolve(this.extractData(resp)))
        .catch(this.handleError);
    });

  }

  postFile<T>(resourceUrl: string, file: File, fileName: string): Promise<T> {
    let formData = new FormData();
    formData.append("file", file, fileName);
    let headers = new Headers();
    headers.append("Accept", "application/json");

    return new Promise<T>(resolve => {

      let url = this.getFullUrl(resourceUrl);
      let httpObs = this.http.post(url, formData, { headers: headers })
        .toPromise()
        .then(resp => resolve(this.extractData(resp)))
        .catch(this.handleError);
    });

  }

  get<T>(resourceUrl: string): Promise<T> {
    return new Promise<T>(resolve => {

      let url = this.getFullUrl(resourceUrl);
      let httpObs = this.http.get(url)
        .toPromise()
        .then(resp => resolve(this.extractData(resp)))
        .catch(this.handleError);
    });

  }


  private extractData(res: Response) {
    let body = res.json();
    return body || body.data || {};
  }
  private handleError(error: Response | any) {
    let errMsg: string;
    if (error instanceof Response) {
      const body = error.json() || '';
      const err = body.error || JSON.stringify(body);
      errMsg = `${error.status} - ${error.statusText || ''} ${err}`;
    } else {
      errMsg = error.message ? error.message : error.toString();
    }
    console.error(errMsg);
    return Promise.reject(errMsg);
  }
}
