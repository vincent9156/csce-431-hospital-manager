using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HospitalManager.Models;

namespace HospitalManager.Repositories
{
    public class BillingInformationRepository
    {
        UserBillingInformationDatabase infoDb = new UserBillingInformationDatabase();

        /**
         * Get the credit card information for a user
         */
        CreditCardInformation GetCreditCardInfo(int UserID)
        {
            return infoDb.CreditCardInformations.Single(u => u.UserID == UserID);
        }

        /**
         * Edit a user's billing information
         */
        void EditBillingInfo(CreditCardInformation info)
        {
            var result = (from dbInfo in infoDb.CreditCardInformations
                          where dbInfo.UserID == info.UserID
                          select dbInfo).Single();

            result.CardProviderID = info.CardProviderID;
            result.CardNumber = info.CardNumber;
            result.SecurityCode = info.SecurityCode;
            result.ExpirationMonth = info.ExpirationMonth;
            result.ExpirationYear = info.ExpirationYear;
            result.BillingAddress = info.BillingAddress;
            result.InsurancePolicyNumber = info.InsurancePolicyNumber;
            result.InsuranceProviderName = info.InsuranceProviderName;

            infoDb.SubmitChanges();
        }

        /**
         * Create a user's billing information
         */
        public void CreateBillingInfo(CreditCardInformation info)
        {
            infoDb.CreditCardInformations.InsertOnSubmit(info);
            infoDb.SubmitChanges();
        }

    }
}