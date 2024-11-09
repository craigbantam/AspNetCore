import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HomeItemViewDTO } from '../../../../models/home-item-view-dto';

@Injectable({
  providedIn: 'root'
})
export class HomeItemHttpService {

  constructor(private httpClient: HttpClient) {
  }

  //todo: add pagination
  public getAll(): Observable<HomeItemViewDTO[]> {
    return this.httpClient.get<HomeItemViewDTO[]>("https://localhost:7067/api/homeitem");
  }
}

