using AutoMapper;
using SquareFindings.Entities;
using SquareFindings.Models;

namespace SquareFindings
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        { 
            CreateMap<PointEntity, PointModel>();
            CreateMap<PointModel, PointEntity>();
            CreateMap<PointEntity, Point>();
        }
    }
}
