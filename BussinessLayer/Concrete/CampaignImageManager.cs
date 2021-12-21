using BussinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Concrete
{
    public class CampaignImageManager : ICampaignImageService
    {
        ICampaignImageDal _CIDal;

        public CampaignImageManager(ICampaignImageDal campaignImageDal)
        {
            _CIDal = campaignImageDal;
        }

        public ResultModel CampaignImageAdd(CampaignImage ci)
        {
            _CIDal.Insert(ci);
            return new ResultModel { Result=true,Message="Adding new new Campaign is succesfull."};
        }

        public ResultModel CampaignImageDelete(int CampaignImageId)
        {
            return _CIDal.deleteById(CampaignImageId);
        }

        public ResultModel CampaignImageUpdate(CampaignImage ci)
        {
            _CIDal.Update(ci);
            return new ResultModel { Result = true, Message = "Updating new new Campaign is succesfull." };

        }

        public List<CampaignImage> GetAll()
        {
            return _CIDal.GetAll();
        }

        public CampaignImage GetById(int CampaignImageId)
        {
            return _CIDal.Get(c => c.ImageId == CampaignImageId);
        }
    }
}
