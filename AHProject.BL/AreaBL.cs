using AHProject.DAL;
using AHProject.DAL.Models;
using AutoMapper;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace AHProject.BL
{
    public class AreaBL: IAreaBL
    {
        IAreaDAL _IAreaDAL;
        IMapper _mapper;
        public AreaBL(IAreaDAL IAreaDAL, IMapper mapper)
        {
            this._IAreaDAL = IAreaDAL;
            this._mapper = mapper;
        }
        public List<AreaDTO> GetAreas()
        {
            List<Area> areas = _IAreaDAL.GetAreas();
            return _mapper.Map<List< Area>,List< AreaDTO>>(areas);
        }
        public bool AddArea(AreaDTO area)
        {
            return _IAreaDAL.AddArea(_mapper.Map<AreaDTO, Area>(area));
        }
    }
}
