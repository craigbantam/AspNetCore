import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

@Component({
    selector: 'app-list-control',
    standalone: true,
    imports: [CommonModule, RouterModule],
    templateUrl: './list-control.component.html'
})
export class ListControlComponent {

    @Input()
    public Data: any[] = [];

    pages: number[] = [];
    pageCount = 3;
    ngOnInit() {
        this.pages = Array.from({ length: this.pageCount }, (_, i) => i + 1);
    }

    public get columns(): string[] {
        return Object.keys(this.Data[0]);
    }

}
