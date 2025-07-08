import { ChangeDetectorRef, Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { LoaderService } from './features/home-items/services/loader/loader-service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {

  isLoading:boolean = false;

  constructor(
    public loaderService: LoaderService,
    private cdr: ChangeDetectorRef) {

  }

  ngOnInit(): void {
    this.loaderService.loader$.subscribe(value => {
      this.isLoading = value;
      this.cdr.detectChanges();
    });
  }

  public get AppLoaded(): boolean {
    return true;
  }


}
