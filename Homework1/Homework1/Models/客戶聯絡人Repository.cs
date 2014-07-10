using System;
using System.Linq;
using System.Collections.Generic;
	
namespace Homework1.Models
{   
	public  class 客戶聯絡人Repository : EFRepository<客戶聯絡人>, I客戶聯絡人Repository
	{
        public override IQueryable<客戶聯絡人> All()
        {
            return base.All().Where(p => !p.isDelete);
        }

        public 客戶聯絡人 Find(int id)
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

	public  interface I客戶聯絡人Repository : IRepository<客戶聯絡人>
	{

	}
}