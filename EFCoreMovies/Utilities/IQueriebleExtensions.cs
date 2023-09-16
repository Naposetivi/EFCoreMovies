
namespace EFCoreMovies.Utilities
{
    public static class IQueriebleExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> sourse, int page, int recordsToTake)
        {
            return sourse.Skip((page - 1) * recordsToTake).Take(recordsToTake);
        } 
    }
}
