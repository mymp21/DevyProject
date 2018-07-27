using SharedApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminLib.Models
{
    public class Pengaduan : DTO.pengaduan, IBaseModel<Pengaduan>, IConvertModel<PengaduanModel>
    {
        public Petugas Petugas { get; set; }

        public PengaduanModel ConvertModel()
        {
            return new PengaduanModel {
                 IdPengaduan = IdPengaduan, IdPetugas=IdPetugas, Pengaduan=Pengaduan, Status=Status,
                  WaktuLapor=WaktuLapor, WaktuSelesai=WaktuSelesai
            };
        }

        public Task<bool> Delete()
        {

            using (var db = new OcphDbContext())
            {
                try
                {
                    if (db.Pengaduan.Delete(O => O.IdPengaduan == IdPengaduan))
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

        public Task<List<Pengaduan>> Get()
        {
            using (var db = new OcphDbContext())
            {
                try
                {
                    var result = from a in db.Pengaduan.Select()
                                 join b in db.Petugas.Select() on a.IdPetugas equals b.idpetugas
                                 select new Pengaduan
                                 {
                                     IdPengaduan = a.IdPengaduan,
                                     IdPetugas = a.IdPetugas,
                                     Pengaduan = a.Pengaduan,
                                     Status = a.Status,
                                     WaktuLapor = a.WaktuLapor,
                                     WaktuSelesai = a.WaktuSelesai,
                                     Petugas = new Petugas
                                     {
                                         Alamat = b.Alamat,
                                         Email = b.Email,
                                         idpetugas = b.idpetugas,
                                         JK = b.JK,
                                         Nama = b.Nama,
                                         NoKontak = b.NoKontak,
                                         UserId = b.UserId
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

        public Task<Pengaduan> GetById()
        {
            try
            {
                using (var db = new OcphDbContext())
                {
                    var result = (from a in db.Pengaduan.Where(O => O.IdPengaduan == this.IdPengaduan)
                                  join b in db.Petugas.Select() on a.IdPetugas equals b.idpetugas
                                  select new Pengaduan
                                  {
                                      IdPengaduan = a.IdPengaduan,
                                      IdPetugas = a.IdPetugas,
                                      Pengaduan = a.Pengaduan,
                                      Status = a.Status,
                                      WaktuLapor = a.WaktuLapor,
                                      WaktuSelesai = a.WaktuSelesai,
                                      Petugas = new Petugas
                                      {
                                          Alamat = b.Alamat,
                                          Email = b.Email,
                                          idpetugas = b.idpetugas,
                                          JK = b.JK,
                                          Nama = b.Nama,
                                          NoKontak = b.NoKontak,
                                          UserId = b.UserId
                                      }
                                  }).ToList();

                    if (result.FirstOrDefault() != null)
                        return Task.FromResult(result.FirstOrDefault());
                    else
                        throw new SystemException("Data Tidak Ditemukan");
                }
            }
            catch (Exception ex)
            {

                throw new SystemException(ex.Message);
            }
        }

        public Task<Pengaduan> SaveChange()
        {
            using (var db = new OcphDbContext())
            {
                try
                {
                    if (this.IdPengaduan <= 0)
                    {
                        this.IdPengaduan = db.Pengaduan.InsertAndGetLastID(this);
                        if (IdPengaduan <= 0)
                            throw new SystemException("Data Tidak Tersimpan");
                    }
                    else
                    {
                        if (!db.Pengaduan.Update(O => new { O.IdPetugas, O.Pengaduan, O.Status, O.WaktuLapor, O.WaktuSelesai }, this, O => O.IdPengaduan == IdPengaduan))
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
