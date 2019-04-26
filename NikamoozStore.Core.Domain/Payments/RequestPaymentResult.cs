using System;
using System.Collections.Generic;
using System.Text;

namespace NikamoozStore.Core.Domain.Payments
{
    public abstract class BankRequestResult
    {
        public int Status { get; set; }
        public string Token { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }

        public bool IsCorrect => Status == 1;
    }
    public class RequestPaymentResult: BankRequestResult
    {

    }
    public  class PaymentResult: BankRequestResult
    {

    }
    public class VerifyPayemtnResult
    {
        public int Status { get; set; }
        public string amount { get; set; }
        public string transId { get; set; }
        public string factorNumber { get; set; }
        public string mobile { get; set; }
        public string description { get; set; }
        public string cardNumber { get; set; }
        public string message { get; set; }
        public string errorCode { get; set; }
        public string errorMessage { get; set; }
        public bool IsCorrect => Status == 1;


    }
}
