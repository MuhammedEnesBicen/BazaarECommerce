using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface ICampaignImageService
    {
        ResultModel CampaignImageAdd(CampaignImage ci);
        ResultModel CampaignImageDelete(int CampaignImageId);
        ResultModel CampaignImageUpdate(CampaignImage ci);

        CampaignImage GetById(int CampaignImageId);

        List<CampaignImage> GetAll();

    }
}
