using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfCampaignImageRepository : GenericRepository<CampaignImage>, ICampaignImageDal
    {
        public ResultModel deleteById(int campaignImageId)
        {
            using (var context = new Context())
            {
                CampaignImage temp =  context.CampaignImages.FirstOrDefault(c => c.ImageId == campaignImageId);
                context.CampaignImages.Remove(temp);
                return new ResultModel { Result = true, Message = "Deleting Campaign is succesfull." };
            }
        }
    }
}
