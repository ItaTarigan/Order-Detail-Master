using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Silpo.Tools;
using BalitTanahPelayanan.Services;
using BalitTanahPelayanan.Models;
using BalitTanahPelayanan.Helpers;
using System.Security.Cryptography;

namespace BalitTanahPelayanan.Services
{
    public class AccountService : ICrud<Accounttbl>
    {
        Encryption enc;
        smlpobDB db;
        public AccountService()
        {
            if (db == null) db = new smlpobDB();
            if (enc == null) enc = new Encryption();
        }
        public bool DeleteData(object Id)
        {
            if (Id is int FID)
            {
                var data = from x in db.Accounttbl
                           where x.AccountNo == FID
                           select x;
                foreach (var item in data)
                {
                    db.Accounttbl.Remove(item);
                }
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Accounttbl> FindByKeyword(string Keyword)
        {
            throw new NotImplementedException();
        }

        public List<Accounttbl> GetAllData()
        {
            var data = from x in db.Accounttbl//.Include(x=>x.Province)
                       select x;
            return data.ToList();
        }
        public bool IsUserExists(string Email)
        {
            try
            {
                var res = db.Accounttbl.Any(x => x.Username.ToLower() == Email.ToLower());
                return res;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;

        }
        public Accounttbl GetbyEmail(string Email)
        {
            try
            {
                var res = db.Accounttbl.Where(x => x.Username.ToLower() == Email.ToLower()).FirstOrDefault();
                return res;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;

        }
        public bool IsValid(string Email, string Password)
        {
            try
            {
                string DescryptedPass = Crypto.Encrypt(Password);
                var data = from x in db.Accounttbl
                           where x.Username.ToLower() == Email.ToLower()
                           select x;
                //if (data == null || data.Count() <= 0) return false;
                foreach (var item in data)
                {
                    if (item.Password == DescryptedPass) return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;

        }
        public bool IsValid(string Email, string Password, out Accounttbl user)
        {
            bool result = false;
            user = null;
            try
            {
                var data = (from x in db.Accounttbl
                            where x.Username.ToLower() == Email.ToLower()
                            select x).FirstOrDefault();
                if (data != null)
                {
                    string DescryptedPass = Crypto.Encrypt(Password);
                    user = data;
                    if (data.Password == DescryptedPass)
                        result = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return result;

        }
        public bool ResetPassword(string Email, string NewPassword)
        {
            try
            {
                bool Changed = false;
                var data = from x in db.Accounttbl
                           where x.Username.ToLower() == Email.ToLower()
                           select x;
                //if (data == null || data.Count() <= 0) return false;
                foreach (var item in data)
                {
                    Changed = true;
                    item.Password = Crypto.Encrypt(NewPassword);
                }
                db.SaveChanges();
                return Changed;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public Accounttbl GetDataById(object Id)
        {
            if (Id is int FID)
            {
                var data = from x in db.Accounttbl
                           where x.AccountNo == FID
                           select x;
                return data.FirstOrDefault();
            }
            return default;
        }


        public long GetLastId()
        {
            var lastId = db.Accounttbl.OrderByDescending(x => x.AccountNo).FirstOrDefault();
            return lastId.AccountNo + 1;
        }

        public bool InsertData(Accounttbl data)
        {
            try
            {
                db.Accounttbl.Add(data);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

                return false;
            }

        }


        public bool UpdateData(Accounttbl data)
        {
            try
            {
                db.Entry(data).State = EntityState.Modified;
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;


            }

        }

        public Accounttbl GetRoleByEmail(string keyword)
        {
            var data = (from x in db.Accounttbl
                        where x.Username == keyword
                        select x).FirstOrDefault();
            var role = (from x in db.Roletbl
                        where x.RoleName == data.RoleName
                        select x).FirstOrDefault();
            data.RoleNameNavigation = role;
            return data;
        }

    }
}


