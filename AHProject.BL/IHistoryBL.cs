using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace AHProject.BL
{
    public interface IHistoryBL
    {
        public List<HistoryDTO> GetHistory();

    }
}
