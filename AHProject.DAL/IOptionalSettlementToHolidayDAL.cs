namespace AHProject.DAL
{
    public interface IOptionalSettlementToHolidayDAL
    {
        public void addSettlements(int idSchedulingHoliday);
        public void removeSettlements(int idSchedulingHoliday);
    }
}