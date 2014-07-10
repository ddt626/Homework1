using System;
using System.Linq;
using System.Collections.Generic;

namespace Homework1.Models
{
    public class 客戶銀行資訊Repository : EFRepository<客戶銀行資訊>, I客戶銀行資訊Repository
    {
        public override IQueryable<客戶銀行資訊> All()
        {
            return base.All().Where(p => !p.isDelete);
        }

        public 客戶銀行資訊 Find(int id)
        {
            return All().FirstOrDefault(p => p.Id == id);
        }

        public void DeleteForIsDelete(int id)
        {
            var item = Find(id);
            if (item != null)
            {
                try
                {
                    item.isDelete = true;
                    UnitOfWork.Commit();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

    }

    public interface I客戶銀行資訊Repository : IRepository<客戶銀行資訊>
    {

    }
}