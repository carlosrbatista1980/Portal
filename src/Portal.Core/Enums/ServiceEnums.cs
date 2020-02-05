using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Core.Enums
{
    public static class ServiceEnums
    {
        public enum SignUpState : short
        {
            /// <summary>
            /// When new account is created on database successfully.
            /// </summary>
            Success = 1,

            /// <summary>
            /// When account already exists.
            /// </summary>
            Exists = 2,

            /// <summary>
            /// When account is not found on database.
            /// </summary>
            NotFound = 3,
            
            /// <summary>
            /// Error: When error occurs by an internal exception.
            /// </summary>
            InternalError = 9,
        }

        public enum SignInState : short
        {
            Success = 1,
            Failed = 2,
            Error = 9,
        }
    }
}
