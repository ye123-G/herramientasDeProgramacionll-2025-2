using GestionDeinformacion.application.Adapters.Validators;
using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeinformacion.application.Adapters.bulders
{
    internal class UserBulder
    {
        private PersonValidator personValidator;
        private EmergensyContact emergencycontactValidator;
        private UserValidator userValidator;

        public UserBuilder()
        {
            personValidator = new PersonValidator();
            emergensyContact = new EmergensyContact();
            userValidator = new UserValidator();
        }

        internal PersonValidator PersonValidator { get => personValidator; set => personValidator = value; }
        internal ContactValidator ContactValidator { get => contactValidator; set => contactValidator = value; }
        internal UserValidator UserValidator { get => userValidator; set => userValidator = value; }

        public User create(
            string role,
            string nameUser,
            string password,
            string name,
            string id,
            string document,
            string email,
            string phone,
            string age,
            string direction,
            string contactName,
            string contactRelation,
            string contactPhone,
            string contactEmail
            )
        {
            User user = new User
            {
                Role = UserValidator.ValidateRole(role),
                NameUser = UserValidator.ValidateUserName(nameUser),
                Password = UserValidator.ValidatePassword(password),
                Name = PersonValidator.ValidateName(name),
                Id = GenerateUniqueId(),
                Email = PersonValidator.ValidateEmail(email),
                Phone = PersonValidator.ValidatePhone(phone),
                document = PersonValidator.ValidateId(document),
                DateBirth = PersonValidator.ValidateAge(age),
                Direction = PersonValidator.ValidationDirection(direction),
                EmergencyContact = new Contact
                {
                    Relation = ContactValidator.RelationValidator(contactRelation),
                    Name = ContactValidator.NameValidator(contactName),
                    PhoneNumber = ContactValidator.PhoneNumberValidator(contactPhone),
                    Email = ContactValidator.EmailValidator(contactEmail)
                }
            };
            return user;
        }
        private static ulong GenerateUniqueId()
        {
            var bytes = Guid.NewGuid().ToByteArray();
            return BitConverter.ToUInt64(bytes, 0);
        }

    }
}
}
