import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, RouterModule } from '@angular/router';

@Component({
  selector: 'app-home-item-edit-component',
  standalone: true,
  imports: [RouterModule],
  templateUrl: './home-item-edit-component.html'
})
export class HomeItemEditComponent implements OnInit {
  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    const itemId = this.route.snapshot.paramMap.get('itemId');
    console.log(itemId);
  }
}
