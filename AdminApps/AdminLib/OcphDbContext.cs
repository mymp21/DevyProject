using AdminLib.DTO;
using Ocph.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminLib
{
    public class OcphDbContext:Ocph.DAL.Provider.MySql.MySqlDbConnection
    {
        public OcphDbContext()
        {
            this.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public IRepository<petugas> Petugas { get { return new Repository<petugas>(this); } }
        public IRepository<pengaduan> Pengaduan { get { return new Repository<pengaduan>(this); } }
        public IRepository<pelanggan> Pelanggan { get { return new Repository<pelanggan>(this); } }
        public IRepository<pemasangan> Pemasangan{ get { return new Repository<pemasangan>(this); } }
    }
}
