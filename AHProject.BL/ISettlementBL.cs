using DTO;
using System.Collections.Generic;

namespace AHProject.BL
{
    public interface ISettlementBL
    {
        public bool AddSettlement(SettlementDTO settlement);
        public List<SettlementDTO> GetSettlements();
        public bool DeleteSettlement(int idSettlement);
        public SettlementDTO GetSettlementById(int id);
        public bool UpdatSettlement(SettlementDTO settlement);
        public bool IsPlaced(int settlement);
    }
}