namespace App.Common.Data
{
    public interface IDbContext
    {
        int SaveChanges();
        void RegisterSaveChangeEvent(OnContextSaveChange ev);
        void OnSaveChanged();
    }
}