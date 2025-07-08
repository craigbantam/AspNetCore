import { BehaviorSubject } from 'rxjs';
import { Injectable, NgZone } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class LoaderService {
  private requestCount = 0;
  private loaderSubject = new BehaviorSubject<boolean>(false);
  loader$ = this.loaderSubject.asObservable();

  constructor(private ngZone: NgZone) {}

  show(): void {
    this.requestCount++;
    if (this.requestCount === 1) {
      this.ngZone.run(() => this.loaderSubject.next(true));
    }
  }

  hide(): void {
    if (this.requestCount > 0) {
      this.requestCount--;
    }
    if (this.requestCount === 0) {
      
      this.ngZone.run(() => this.loaderSubject.next(false));
    }
  }
}
