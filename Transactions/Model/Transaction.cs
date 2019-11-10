using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Transactions.Model
{
    public class Transaction
    {
        public int transactionID;
        public int userID;
        public int fromAccountNumber;
        public int toAccountNumber;
        public string reason = String.Empty;
    }
}
