import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HomeItemViewDTO } from '../../../../models/home-item-view-dto';
import { environment } from '../../../../../environments/environment';
import { OffsetPaginationResponseModel } from '../../../../models/offset-pagination-response-model';

@Injectable({
  providedIn: 'root'
})
export class HomeItemHttpService {

  constructor(private httpClient: HttpClient) {
  }


  public getAll(): Observable<HomeItemViewDTO[]> {
    return this.httpClient.get<HomeItemViewDTO[]>(`${environment.apiUrl}`);
  }

  public GetAllByPaging(pageNumber: number, pageSize: number): Observable<OffsetPaginationResponseModel<HomeItemViewDTO>> {
    return this.httpClient.get<OffsetPaginationResponseModel<HomeItemViewDTO>>(`${environment.apiUrl}/api/homeitem/ByPaging?pageNumber=${pageNumber}&pageSize=${pageSize}`);
  }
}

