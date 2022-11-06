namespace HandySample.ApiModels.Responses
{
    public class ListResponse<T>
    {
        public List<T> Items { get; set; }

        public int TotalCount { get; set; }
    }
}
