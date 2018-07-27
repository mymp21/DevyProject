using SharedApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminLib.Models
{
    public class Pemasangan : DTO.pemasangan, IBaseModel<Pemasangan>, IConvertModel<PemasanganModel>
    {
        public Pemasangan() { }
        public Pemasangan(int id)
        {
            this.idpemasangan = id;
        }

        public Petugas Petugas { get; internal set; }
        public Pelanggan Pelanggan { get; internal set; }

        public PemasanganModel ConvertModel()
        {
            return new PemasanganModel {
                 Biaya=Biaya, Daya=Daya, Petugas=Petugas, IdPelanggan=IdPelanggan, idpemasangan=idpemasangan,  JenisTarif=JenisTarif,
                   NoGardu=NoGardu, Peruntukan=Peruntukan, StatusUbah=StatusUbah, Tarif=Tarif, UangJaminan=UangJaminan
            };
        }

        public Task<bool> Delete()
        {

            using (var db = new OcphDbContext())
            {
                try
                {
                    if (db.Pemasangan.Delete(O => O.idpemasangan == idpemasangan))
                        return Task.FromResult(true);
                    else
                        throw new SystemException("Data Tidak Terhapus");

                }
                catch (Exception ex)
                {
                    throw new SystemException(ex.Message);
                }
            }
        }

        public Task<List<Pemasangan>> Get()
        {
            using (var db = new OcphDbContext())
            {
                try
                {
                    var result = from a in db.Pemasangan.Select().AsEnumerable()
                                 join c in db.Petugas.Select() on a.IdPetugas equals c.idpetugas
                                 join b in db.Pelanggan.Select() on a.IdPelanggan equals b.IdPelanggan
                                 select new Pemasangan
                                 {
                                     Biaya = a.Biaya,
                                     Daya = a.Daya,
                                     IdPelanggan = a.IdPelanggan,
                                     idpemasangan = a.idpemasangan,
                                     JenisTarif = a.JenisTarif,
                                     NoGardu = a.NoGardu,
                                     Pelanggan = new Pelanggan
                                     {
                                         Alamat = b.Alamat,
                                         Email = b.Email, IdPelanggan=b.IdPelanggan, IdUser=b.IdUser, JK=b.JK,
                                          Nama=b.Nama, NoIdentitas=b.NoIdentitas, NoKontak=b.NoKontak, ScanIdentitas=b.ScanIdentitas
                                     },
                                     Peruntukan = a.Peruntukan,
                                     StatusUbah = a.StatusUbah,
                                     Tarif = a.Tarif,
                                     UangJaminan = a.UangJaminan,

                                     Petugas = new Petugas
                                     {
                                         Alamat = c.Alamat,
                                         Email = c.Email,
                                         idpetugas = a.IdPetugas,
                                         JK = c.JK,
                                         Nama = c.Nama,
                                         NoKontak = c.NoKontak,
                                         UserId = c.UserId
                                     }
                                 };

                    return Task.FromResult(result.ToList());

                }
                catch (Exception ex)
                {

                    throw new SystemException(ex.Message);
                }
            }
        }

        public Task<Pemasangan> GetById()
        {
            using (var db = new OcphDbContext())
            {
                try
                {
                    var result = (from a in db.Pemasangan.Where(O=>O.idpemasangan==idpemasangan)
                                 join c in db.Petugas.Select() on a.IdPetugas equals c.idpetugas
                                 join b in db.Pelanggan.Select() on a.IdPelanggan equals b.IdPelanggan
                                 select new Pemasangan
                                 {
                                     Biaya = a.Biaya,
                                     Daya = a.Daya,
                                     IdPelanggan = a.IdPelanggan,
                                     idpemasangan = a.idpemasangan,
                                     JenisTarif = a.JenisTarif,
                                     NoGardu = a.NoGardu,
                                     Pelanggan = new Pelanggan
                                     {
                                         Alamat = b.Alamat,
                                         Email = b.Email,
                                         IdPelanggan = b.IdPelanggan,
                                         IdUser = b.IdUser,
                                         JK = b.JK,
                                         Nama = b.Nama,
                                         NoIdentitas = b.NoIdentitas,
                                         NoKontak = b.NoKontak,
                                         ScanIdentitas = b.ScanIdentitas
                                     },
                                     Peruntukan = a.Peruntukan,
                                     StatusUbah = a.StatusUbah,
                                     Tarif = a.Tarif,
                                     UangJaminan = a.UangJaminan,

                                     Petugas = new Petugas
                                     {
                                         Alamat = c.Alamat,
                                         Email = c.Email,
                                         idpetugas = a.IdPetugas,
                                         JK = c.JK,
                                         Nama = c.Nama,
                                         NoKontak = c.NoKontak,
                                         UserId = c.UserId
                                     }
                                 }).FirstOrDefault();
                    if (result == null)
                        throw new SystemException("Data Tidak Ditemukan");

                    return Task.FromResult(result);

                }
                catch (Exception ex)
                {

                    throw new SystemException(ex.Message);
                }
            }
        }

        public Task<Pemasangan> SaveChange()
        {
            using (var db = new OcphDbContext())
            {
                try
                {
                    if (idpemasangan<= 0)
                    {
                        idpemasangan = db.Pemasangan.InsertAndGetLastID(this);
                        if (idpemasangan <= 0)
                            throw new SystemException("Data Tidak Tersimpan");
                    }
                    else
                    {
                        if (!db.Pemasangan.Update(O => new { O.IdPetugas, O.Biaya, O.Daya, O.IdPelanggan,O.JenisTarif,O.NoGardu,O.Peruntukan,O.StatusUbah,O.Tarif,O.UangJaminan}, this, O => O.idpemasangan== idpemasangan))
                            throw new SystemException("Data Tidak Tersimpan");
                    }

                    return Task.FromResult(this);
                }
                catch (Exception ex)
                {
                    throw new SystemException(ex.Message);
                }

            }
        }
    }
}
