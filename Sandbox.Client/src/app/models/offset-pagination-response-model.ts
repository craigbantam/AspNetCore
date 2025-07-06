export interface OffsetPaginationResponseModel<T> {
    hasNextPage: boolean;
    hasPreviousPage: boolean;
    totalRecords: number;
    pageCount: number;
    pageNumber: number;
    entities: T[];
}