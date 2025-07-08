import { Component, EventEmitter, Input, Output, SimpleChanges } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { OffsetPaginationResponseModel } from '../../../../../models/offset-pagination-response-model';
import { HomeItemViewDTO } from '../../../../../models/home-item-view-dto';

@Component({
    selector: 'app-list-control',
    standalone: true,
    imports: [CommonModule, RouterModule],
    templateUrl: './list-control.component.html'
})
export class ListControlComponent {

    public Data: any[] = [];

    @Input()
    public PaginationData: OffsetPaginationResponseModel<HomeItemViewDTO>;

    @Output()
    public Paginate: EventEmitter<number> = new EventEmitter<number>();

    @Output()
    public Navigate: EventEmitter<number> = new EventEmitter<number>();

    pages: number[] = [];
    pageCount: number;
    currentPage: number;

    ngOnChanges(changes: SimpleChanges): void {
        if (changes['PaginationData'] && this.PaginationData) {
            this.currentPage = this.PaginationData.pageNumber;
            this.pageCount = this.PaginationData.pageCount;
            this.Data = this.PaginationData.entities;
            this.pages = Array.from({ length: this.pageCount }, (_, i) => i + 1);
        }
    }

    public get columns(): string[] {
        return this.Data && this.Data.length > 0 ? Object.keys(this.Data[0]) : [];
    }

    onNavigate(event: Event,id: number) {
        event.preventDefault(); // Prevents the browser from jumping to `#`
        this.Navigate.emit(id);
    }

    onPageClick(event: Event, page: number): void {
        event.preventDefault(); // Prevents the browser from jumping to `#`
        if (page !== this.currentPage) {
            this.currentPage = page;

            this.Paginate.emit(page);
        }
    }

}
