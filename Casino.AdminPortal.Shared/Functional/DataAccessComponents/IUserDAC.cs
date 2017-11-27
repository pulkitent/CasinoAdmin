using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.AdminPortal.Shared
{
    public interface IUserDAC : IDataAccessComponent
    {
        IUserDTO CreateAUser(IUserDTO user);

        IList<IUserDTO> GetAllUser();

        IUserDTO GetUserByEmailId(string emailId);

        IList<IUserDTO> SearchUser(string nameSearch, string contactSearch, string emailSearch);

        IUserDTO AddUserMoney(string emailId, decimal rechargeAmount);

        IUserDTO GetUserByContactNumber(string contactNumber);

        IUserDTO BlockBetAmount(string emailId, decimal betAmount);

        IUserDTO AddWinningPrize(string emailId, decimal betAmount, decimal multiplyFactor);

    }
}
