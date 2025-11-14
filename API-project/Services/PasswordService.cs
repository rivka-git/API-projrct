using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PasswordService
    {
        public PassWord getStrengthByPassword(PassWord p)
        {

            var result = Zxcvbn.Core.EvaluatePassword(p.Password);
            p.Strength = result.Score;
            return p;
        }
    }
}
