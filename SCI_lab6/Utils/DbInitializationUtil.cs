using DbDataLibrary.Data;

namespace SCI_lab6.Utils
{
    public class DbInitializationUtil
    {
        public static void Init()
        {
            ToursSqliteDbContext dbContext = new ToursSqliteDbContext();
            DbInitializer<ToursSqliteDbContext>.Initialize(dbContext);
        }
   
    }
}
