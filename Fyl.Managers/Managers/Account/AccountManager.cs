using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fyl.DataLayer.Repositories;
using Fyl.Library.Dto;
using Fyl.Helpers;
using System.Security.Cryptography;

namespace Fyl.Managers
{
    public class AccountManager
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
                dto.Password = MD5.Create(dto.Password).ToString();
                await _accountRepository.RegisterUser(dto);
            }
        }
    }
}
