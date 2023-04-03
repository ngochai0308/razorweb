namespace APS.net_Entity_.Helpers
{
    public class PagingModel
    {
        public int currenpage { get; set; }
        public int countpages { get; set; }
        public Func<int?,string > generateUrl { get; set; }
    }
}
