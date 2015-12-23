using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fyl.DataLayer.Repositories;
using Fyl.Library.Dto;
using Fyl.Helpers;
using System.Security.Cryptography;
using Fyl.Library.Helpers;

namespace Fyl.Managers
{
    public class AccountManager : IAccountManager
    {
        private IAccountRepository _accountRepository;

        public AccountManager(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task RegisterUser(RegisterDto dto)
        {
            var meetsRequirements = PasswordHelper.PasswordCaseHelper(dto.Password, dto.PasswordConfirm);
            
            if (meetsRequirements)
            {
                var passwordAuthId = await _accountRepository.AddPasswordAuthorisation(dto.Password);
                dto.PasswordAuthorisationId = passwordAuthId;
                await _accountRepository.RegisterUser(dto);
            }
        }
    }
}
