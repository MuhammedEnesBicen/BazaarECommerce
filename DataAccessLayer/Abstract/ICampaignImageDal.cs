using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ICampaignImageDal: IGenericDal<CampaignImage>
    {
        ResultModel deleteById(int campaignImageId);
        
    }
}
