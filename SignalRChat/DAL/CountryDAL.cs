using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Caching;
using System.Web;
using SignalRChat.Models;

namespace SignalRChat.DAL
{
    public static class CountryDAL
    {
        private static readonly MemoryCache Cache = MemoryCache.Default;



        /// <summary>Gets countries for master data.</summary>
        /// <returns>The list.</returns>
        public static List<CountryModel> CountryList
        {
            get
            {
                if (!Cache.Contains("CountryList"))
                {
                    RefreshCountries();
                }

                return Cache.Get("CountryList") as List<CountryModel>;
            }
        }

        public static void RefreshCountries()
        {
            var countries = new List<CountryModel>();

            using (var ds = Database.ExecuteProcedureDataSet("dbo.CountryList",null))
            {
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    countries.AddRange(from DataRow dr in ds.Tables[0].Rows
                        select new CountryModel()
                        {
                            IdCountry = (int) dr["CtyId"], RefCountry = dr["RefCountry"].ToString(), LibCountry = dr["libCountry"].ToString()
                        });
                }
            }

            var cacheItemPolicy = new CacheItemPolicy { AbsoluteExpiration = DateTime.Now.AddHours(1) };
            Cache.Add("CountryList", countries, cacheItemPolicy);
        }

        public static CountryModel GetCountry(string key)
        {
            return CountryList.Find(x => x.RefCountry == key);
        }
    }


}