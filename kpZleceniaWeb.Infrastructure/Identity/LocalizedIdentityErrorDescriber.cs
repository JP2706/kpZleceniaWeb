﻿using Microsoft.AspNetCore.Identity;

namespace kpZleceniaWeb.Infrastructure.Identity
{
    public class LocalizedIdentityErrorDescriber : IdentityErrorDescriber
    {
        private const string Email = "Email";
        private const string Password = "Password";

        public override IdentityError PasswordMismatch()
        {
            return new IdentityError
            {
                Code = Password,
                Description = "Hasło i Potwierdzone hasło są różne."
            };
        }

        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError
            {
                Code = Password,
                Description = "Hasło musi zawierać przynajmniej 1 cyfrę."
            };
        }

        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError
            {
                Code = Password,
                Description = "Hasło musi zawierać przynajmniej 1 małą literę."
            };
        }

        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError
            {
                Code = Password,
                Description = "Hasło musi zawierać przynajmniej 1 znak specjalny (np. $, #, & itp.)."
            };
        }

        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError
            {
                Code = Password,
                Description = "Hasło musi zawierać przynajmniej 1 dużą literę."
            };
        }

        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError
            {
                Code = Password,
                Description = "Hasło musi mieć co najmniej 8 znaków i nie więcej niż 100 znaków długości."
            };
        }

        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError
            {
                Code = Email,
                Description = "Wybrany email jest już zajęty."
            };
        }
    }
}
