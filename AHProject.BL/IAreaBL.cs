using DTO;
using System.Collections.Generic;

namespace AHProject.BL
{
    public interface IAreaBL
    {
        public List<AreaDTO> GetAreas();
        public bool AddArea(AreaDTO area);
    }
}