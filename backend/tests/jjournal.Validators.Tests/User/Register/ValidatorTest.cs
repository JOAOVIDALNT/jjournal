using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jjournal.Validators.Tests.User.Register
{
    public class ValidatorTest
    {

        [Fact]
        public static void Success()
        {
            var validator = new RegisterUserValidator();

            var result = validator.Validate();




;;        }
    }
}
