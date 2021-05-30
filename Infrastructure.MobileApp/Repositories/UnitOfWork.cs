using Application.MobileApp.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.MobileApp.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Repositories

        public IUserRepository UserRepository { get; }

        #endregion Repositories

        #region Constructors

        public UnitOfWork(IUserRepository userRepository) => UserRepository = userRepository;

        #endregion Constructors
    }
}
