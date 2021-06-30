using DTO;
using System.Collections.Generic;

namespace AHProject.BL
{
    public interface ISettlementBL
    {
        public bool AddSettlement(SettlementDTO settlement);
        public List<SettlementDTO> GetSettlements();
    }
}