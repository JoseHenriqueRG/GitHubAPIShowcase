import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Repository } from '../interfaces/repository';

@Injectable({
  providedIn: 'root'
})
export class GithubapiService {
  private baseUrl = 'https://localhost:7068/api/GitHubAPIShowcase';
  //private baseUrl = 'http://localhost/GitHubApiShowcase/api/GitHubAPIShowcase';

  constructor(private http: HttpClient) { }

  searchRepositories(term: string, page: number, perPage: number): Observable<any>
  {
    console.log('Termo2: ' + term);

    var url = `${this.baseUrl}/SearchRepositories`;

    term = term.trim();
    
    const options = { params: new HttpParams().set('term', term).set('page', page).set('perPage', perPage) };

    return this.http.get<any>(url, options);
  }
}
