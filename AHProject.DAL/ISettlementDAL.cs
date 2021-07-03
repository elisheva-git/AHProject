using AHProject.DAL.Models;
using System.Collections.Generic;

namespace AHProject.DAL
{
    public interface ISettlementDAL
    {
        public bool AddSettlement(Settlement settlement);
        public List<Settlement> GetSettlements();
        public bool DeleteSettlement(int idSettlement);
        public Settlement GetSettlementById(int id);
    }
}