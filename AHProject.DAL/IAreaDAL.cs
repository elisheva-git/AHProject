using AHProject.DAL.Models;
using System.Collections.Generic;

namespace AHProject.DAL
{
    public interface IAreaDAL
    {
        public List<Area> GetAreas();
        public bool AddArea(Area area);

    }
}