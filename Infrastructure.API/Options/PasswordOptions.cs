﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.API.Options
{
    public class PasswordOptions
    {
        #region Properties
        public int SaltSize { get; set; }
        public int KeySize { get; set; }
        public int Iterations { get; set; }
        #endregion
    }
}
