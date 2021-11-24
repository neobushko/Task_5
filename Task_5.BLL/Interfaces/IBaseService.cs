using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_5.BLL.DTO;

namespace Task_5.BLL.Interfaces
{
    public interface IBaseService : ICheckRooms, ICompareThreeDates
    {
        public BenefitPeriod BenefitForPeriod(DateTime startDate, DateTime endDate);
    }
}
