using AutoMapper;

using PersonsWebApi.Models;
using PersonsWebApi.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonsWebApi
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<PersonCreateAndUpdateRequest, Person>();            
        }
    }
}
