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
         * Get the credit card information for a user (return null if no info exists)
         */
        public CreditCardInformation GetCreditCardInfo(int UserID)
        {
            try
            {
                return infoDb.CreditCardInformations.Single(u => u.UserID == UserID);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /**
         * Edit a user's billing information
         */
        public void EditBillingInfo(CreditCardInformation info)
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

        /**
         * Return all credit card providers
         */
        public IQueryable<CardProvider> GetCardProviders()
        {
            var result = from cardProv in infoDb.CardProviders
                         select cardProv;
            return result;
        }

    }
}