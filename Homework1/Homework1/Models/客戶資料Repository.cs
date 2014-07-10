using System;
using System.Linq;
using System.Collections.Generic;

namespace Homework1.Models
{
    public class 客戶資料Repository : EFRepository<客戶資料>, I客戶資料Repository
    {
        public override IQueryable<客戶資料> All()
        {
            return base.All().Where(p => !p.IsDelete);
        }

        public 客戶資料 Find(int id)
        {
            return All().FirstOrDefault(p => p.Id == id);
        }

        public void DeleteForIsDelete(int id)
        {
            var client = Find(id);

            if (client != null)
            {
                try
                {
                    client.IsDelete = true;

                    if (client.客戶聯絡人 != null)
                    {
                        foreach (var item in client.客戶聯絡人)
                        {
                            item.isDelete = true;
                        }
                    }

                    if (client.客戶銀行資訊 != null)
                    {
                        foreach (var item in client.客戶銀行資訊)
                        {
                            item.isDelete = true;
                        }
                    }

                    UnitOfWork.Commit();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }
    }

    public interface I客戶資料Repository : IRepository<客戶資料>
    {

    }
}