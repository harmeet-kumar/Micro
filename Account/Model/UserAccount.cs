using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Account.Model
{
    public class UserAccount
    {
        public int accountNumber;
        public int userID;
        public bool isChequeBookIssued;
        public bool isChequeBookBlocked;
        public bool isAccountActive;
        public int branchID;
        public string branchName;
        public string pincode;
        public int balance;
    }
}
