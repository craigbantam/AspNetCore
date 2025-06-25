import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HomeItemViewDTO } from '../../../../models/home-item-view-dto';
import { environment } from '../../../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class HomeItemHttpService {

  constructor(private httpClient: HttpClient) {
  }

  //todo: add pagination
  public getAll(): Observable<HomeItemViewDTO[]> {
    return this.httpClient.get<HomeItemViewDTO[]>(`${environment.apiUrl}/homeitem`);
  }
}

