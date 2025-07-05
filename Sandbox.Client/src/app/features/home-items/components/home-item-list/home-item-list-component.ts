import { Component } from '@angular/core';
import { HomeItemViewDTO } from '../../../../models/home-item-view-dto';
import { CommonModule } from '@angular/common';
import { HomeItemHttpService } from '../../services/http/home-item-http.service';
import { RouterModule } from '@angular/router';
import { ListControlComponent } from '../controls/list-control/list-control.component';

@Component({
  selector: 'app-home-item-list-component',
  standalone: true,
  imports: [CommonModule, RouterModule, ListControlComponent],
  templateUrl: './home-item-list-component.html',
  styleUrl: './home-item-list-component.css'
})
export class HomeItemListComponentComponent {

  constructor(private homeItemHttpService: HomeItemHttpService) { }

  public testData: HomeItemViewDTO[] = [
    { Id: 1, Description: 'descr', Location: 'loc', Name: 'nam' }
  ];

  ngOnInit() {
    this.homeItemHttpService.getAll().subscribe(response => this.testData = response);
  }
}
