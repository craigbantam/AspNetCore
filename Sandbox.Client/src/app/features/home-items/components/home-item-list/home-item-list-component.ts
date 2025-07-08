import { Component } from '@angular/core';
import { HomeItemViewDTO } from '../../../../models/home-item-view-dto';
import { CommonModule } from '@angular/common';
import { HomeItemHttpService } from '../../services/http/home-item-http.service';
import { Router, RouterModule } from '@angular/router';
import { ListControlComponent } from '../controls/list-control/list-control.component';
import { OffsetPaginationResponseModel } from '../../../../models/offset-pagination-response-model';
import { LoaderService } from '../../services/loader/loader-service';

@Component({
  selector: 'app-home-item-list-component',
  standalone: true,
  imports: [CommonModule, RouterModule, ListControlComponent],
  templateUrl: './home-item-list-component.html',
  styleUrl: './home-item-list-component.css'
})
export class HomeItemListComponentComponent {

  constructor(private homeItemHttpService: HomeItemHttpService,
    private router: Router
  ) { }

  public testData: OffsetPaginationResponseModel<HomeItemViewDTO>;

  ngOnInit() {
    this.homeItemHttpService.GetAllByPaging(1, 10).subscribe(response => {

      this.testData = response;
    });
  }

  OnPaginate(page: number) {
    this.homeItemHttpService.GetAllByPaging(page, 10).subscribe(response => {

      this.testData = response;
    });
  }

  onNavigate(id: number) {
    this.router.navigate([`edit/${id}`]);
  }
}
