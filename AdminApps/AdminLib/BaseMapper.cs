using AdminLib.DTO;
using AdminLib.Models;
using AutoMapper;
using SharedApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminLib
{

    public static class OcphMapper
    {
        private static BaseMapper mapper;

        public static BaseMapper Mapper
        {
            get
            {
                if (mapper == null)
                    mapper = new BaseMapper();
                return mapper;
            }
        }
    }


    public class BaseMapper : IMapper
    {

        public BaseMapper()
        {
            Mapper.Initialize(config);
        }


        private void config(IMapperConfigurationExpression obj)
        {
            obj.CreateMap<PetugasModel, Petugas>();
            obj.CreateMap<Petugas, PetugasModel>();

            obj.CreateMap<Pelanggan, PelangganModel>();
            obj.CreateMap<PelangganModel, Pelanggan>();

            obj.CreateMap<Pemasangan, PemasanganModel>();
            obj.CreateMap<PemasanganModel, Pemasangan>();

            obj.CreateMap<Pengaduan, PengaduanModel>();
            obj.CreateMap<PengaduanModel, Pengaduan>();


            obj.CreateMap<petugas, Petugas>();
            obj.CreateMap<Petugas, petugas>();

            obj.CreateMap<Pelanggan, pelanggan>();
            obj.CreateMap<pelanggan, Pelanggan>();

            obj.CreateMap<Pemasangan, pemasangan>();
            obj.CreateMap<pemasangan, Pemasangan>();

            obj.CreateMap<Pengaduan, pengaduan>();
            obj.CreateMap<pengaduan, Pengaduan>();

        }


        public IConfigurationProvider ConfigurationProvider => Mapper.Configuration;

        public Func<Type, object> ServiceCtor => throw new NotImplementedException();

        public TDestination Map<TDestination>(object source)
        {
           return Mapper.Map<TDestination>(source);
        }

        public TDestination Map<TDestination>(object source, Action<IMappingOperationOptions> opts)
        {
            return Mapper.Map<TDestination>(source, opts);
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return Mapper.Map<TSource, TDestination>(source);
        }

        public TDestination Map<TSource, TDestination>(TSource source, Action<IMappingOperationOptions<TSource, TDestination>> opts)
        {
            return Mapper.Map<TSource, TDestination>(source, opts);
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return Mapper.Map<TSource, TDestination>(source, destination);
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination, Action<IMappingOperationOptions<TSource, TDestination>> opts)
        {
            return Mapper.Map<TSource, TDestination>(source,destination, opts);
        }

        public object Map(object source, Type sourceType, Type destinationType)
        {
            throw new NotImplementedException();
        }

        public object Map(object source, Type sourceType, Type destinationType, Action<IMappingOperationOptions> opts)
        {
            return Mapper.Map(source, sourceType, destinationType, opts);
        }

        public object Map(object source, object destination, Type sourceType, Type destinationType)
        {
            return Mapper.Map(source, destination, sourceType, destinationType);
        }

        public object Map(object source, object destination, Type sourceType, Type destinationType, Action<IMappingOperationOptions> opts)
        {
            return Mapper.Map(source, destination, sourceType, destinationType,opts);
        }
    }
}
