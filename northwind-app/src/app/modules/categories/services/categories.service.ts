import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Category } from '../models/Category';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CategoriesService {

  url: string = environment.apiUrl + 'Categories';

  constructor(
    private http: HttpClient
  ) { }

  getAll(): Observable<Category[]> {
    return this.http.get<Category[]>(this.url);
  }

  getById(id: number): Observable<Category> {
    return this.http.get<Category>(`${this.url}/${id}`);
  }

  add(category: Category): Observable<Category> {
    return this.http.post<Category>(this.url, category);
  }
}
