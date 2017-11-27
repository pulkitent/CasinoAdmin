using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.AdminPortal.Shared
{
    public interface IUserBDC : IBusinessDomainComponent
    {

        OperationResult<IUserDTO> CreateAUser(IUserDTO user);

        OperationResult<IList<IUserDTO>> GetAllUser();

        OperationResult<IUserDTO> GetUserByEmailId(string emailId);

        OperationResult<IList<IUserDTO>> SearchUser(string nameSearch, string contactSearch, string emailSearch);

        OperationResult<IUserDTO> AddUserMoney(string emailId, decimal rechargeAmount);

        OperationResult<IUserDTO> GetUserByContactNumber(string contactNumber);

        OperationResult<IUserDTO> BlockBetAmount(string emailId, decimal betAmount);

        OperationResult<IUserDTO> AddWinningPrize(string emailId, decimal betAmount, decimal multiplyFactor);

    }
}
