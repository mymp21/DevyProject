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
  public  class Helpers
    {
        public static Mapper Mapper
        {
            get
            {
                if (Mapper.Configuration == null)
                    Mapper.Initialize(config);
                return Mapper;
            }
        }

        private static void config(IMapperConfigurationExpression obj)
        {
            obj.CreateMap<PetugasModel, Petugas>();
            obj.CreateMap<Petugas, PetugasModel>();

            obj.CreateMap<Pelanggan, PelangganModel>();
            obj.CreateMap<PelangganModel, Pelanggan>();

            obj.CreateMap<Pemasangan, PemasanganModel>();
            obj.CreateMap<PemasanganModel, Pemasangan>();

            obj.CreateMap<Pengaduan, PengaduanModel>();
            obj.CreateMap<PengaduanModel, Pengaduan>();



        }
    }
}
