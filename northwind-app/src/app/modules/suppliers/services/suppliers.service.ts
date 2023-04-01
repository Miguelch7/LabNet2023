import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

import { Supplier } from '../models/Supplier';

@Injectable({
  providedIn: 'root'
})
export class SuppliersService {

  url: string = environment.apiUrl + 'Suppliers';

  constructor(
    private http: HttpClient
  ) { }

  getAll(): Observable<Supplier[]> {
    return this.http.get<Supplier[]>(this.url);
  }

  getById(id: number): Observable<Supplier> {
    return this.http.get<Supplier>(`${this.url}/${id}`);
  }

  add(supplier: Supplier): Observable<Supplier> {
    return this.http.post<Supplier>(this.url, supplier);
  }

  update(supplier: Supplier): Observable<Supplier> {
    return this.http.put<Supplier>(`${this.url}/${supplier.id}`, supplier);
  }

  delete(id: number): Observable<string> {
    return this.http.delete<string>(`${this.url}/${id}`);
  }
}
