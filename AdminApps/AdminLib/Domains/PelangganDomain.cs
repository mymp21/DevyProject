using AdminLib.Models;
using SharedApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminLib.Domains
{
    public class PelangganDomain : IBaseDomain<PelangganModel>
    {
        public Task<bool> Delete(int id)
        {
            var data = new Pelanggan(id);
            return data.Delete();
        }

        public async Task<List<PelangganModel>> Get()
        {
            var data = new Pelanggan();
            var results = await data.Get();
            List<PelangganModel> list = new List<PelangganModel>();
            foreach(var item in list)
            {
                list.Add(item);
            }
            return list;
        }

        public async Task<PelangganModel> GetById(int id)
        {
            var data = new Pelanggan(id);
            var result= await data.GetById();
            return result.ConvertModel();
        }

        public async Task<PelangganModel> SaveChange(PelangganModel item)
        {
            var data = item.ConvertModel();
            var result = await data.SaveChange();
            return result.ConvertModel();
        }
    }
}
