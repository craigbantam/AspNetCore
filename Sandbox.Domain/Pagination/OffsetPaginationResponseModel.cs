namespace Sandbox.Domain.Pagination
{
    public class OffsetPaginationResponseModel<T> where T : class
    {
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
        public int TotalRecords { get; set; }
        public int PageCount { get; set; }
        public int PageNumber { get; set; }
        public IEnumerable<T> Entities { get; set; } = [];
    }
}
