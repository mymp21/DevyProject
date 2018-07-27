using SharedApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminLib.Models
{
    public class Pelanggan : DTO.pelanggan, IBaseModel<Pelanggan>, IConvertModel<PelangganModel>
    {

        public Pelanggan(int id)
        {
            IdPelanggan = id;
        }

        public Pelanggan() { }

        public PelangganModel ConvertModel()
        {
            return new PelangganModel {
                Alamat = Alamat,
                Email = Email,
                IdPelanggan = IdPelanggan,
                IdUser = IdUser,
                JK = JK,
                Nama = Nama,
                NoIdentitas = NoIdentitas,
                NoKontak = NoKontak,
                ScanIdentitas = ScanIdentitas
            };
        }

        public Task<bool> Delete()
        {
            throw new NotImplementedException();
        }

        public Task<List<Pelanggan>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Pelanggan> GetById()
        {
            throw new NotImplementedException();
        }

        public Task<Pelanggan> SaveChange()
        {
            throw new NotImplementedException();
        }
    }
}
