using Casino.AdminPortal.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.AdminPortal.BusinessFacade
{
    public class UserFacade : FacadeBase, IUserFacade
    {
        public UserFacade()
            : base(FacadeType.UserFacade)
        {

        }

        public OperationResult<IUserDTO> CreateAUser(IUserDTO user)
        {
            IUserBDC userBDC = (IUserBDC)BDCFactory.Instance.Create(BDCType.UserBDC);
            return userBDC.CreateAUser(user);
        }

        public OperationResult<IList<IUserDTO>> GetAllUser()
        {
            IUserBDC userBDC = (IUserBDC)BDCFactory.Instance.Create(BDCType.UserBDC);
            return userBDC.GetAllUser();
        }

        public OperationResult<IUserDTO> GetUserByEmailId(string emailId)
        {
            IUserBDC userBDC = (IUserBDC)BDCFactory.Instance.Create(BDCType.UserBDC);
            return userBDC.GetUserByEmailId(emailId);
        }

        public OperationResult<IList<IUserDTO>> SearchUser(string nameSearch, string contactSearch, string emailSearch)
        {
            IUserBDC userBDC = (IUserBDC)BDCFactory.Instance.Create(BDCType.UserBDC);
            return userBDC.SearchUser(nameSearch, contactSearch, emailSearch);

        }

        public OperationResult<IUserDTO> AddUserMoney(string emailId, decimal rechargeAmount)
        {
            IUserBDC userBDC = (IUserBDC)BDCFactory.Instance.Create(BDCType.UserBDC);
            return userBDC.AddUserMoney(emailId, rechargeAmount);
        }

        public OperationResult<IUserDTO> GetUserByContactNumber(string contactNumber)
        {
            IUserBDC userBDC = (IUserBDC)BDCFactory.Instance.Create(BDCType.UserBDC);
            return userBDC.GetUserByContactNumber(contactNumber);
        }

        public OperationResult<IUserDTO> BlockBetAmount(string emailId, decimal betAmount)
        {
            IUserBDC userBDC = (IUserBDC)BDCFactory.Instance.Create(BDCType.UserBDC);
            return userBDC.BlockBetAmount(emailId,betAmount);
        }

        public OperationResult<IUserDTO> AddWinningPrize(string emailId, decimal betAmount, decimal multiplyFactor)
        {
            IUserBDC userBDC = (IUserBDC)BDCFactory.Instance.Create(BDCType.UserBDC);
            return userBDC.AddWinningPrize(emailId,betAmount, multiplyFactor);
        }

    }
}
