using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HospitalManager.Models;

namespace HospitalManager.Repositories
{
    /// <summary>
    /// Handles adding and editing billing information
    /// </summary>
    public class BillingInformationRepository
    {
        /// <summary>
        /// Connection to billing info database
        /// </summary>
        UserBillingInformationDatabase infoDb = new UserBillingInformationDatabase();

        /// <summary>
        /// Get the credit card information for a user (return null if no info exists)
        /// </summary>
        /// <param name="UserID">ID of user to look up</param>
        /// <returns>Credit card information for user UserID</returns>
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

        /// <summary>
        /// Edit a user's billing information
        /// </summary>
        /// <param name="info">Contains the new credit card information</param>
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

        /// <summary>
        /// Create a user's billing information
        /// </summary>
        /// <param name="info">Contains the credit card information to insert</param>
        public void CreateBillingInfo(CreditCardInformation info)
        {
            infoDb.CreditCardInformations.InsertOnSubmit(info);
            infoDb.SubmitChanges();
        }

        /// <summary>
        /// Return all credit card providers
        /// </summary>
        /// <returns>List of credit card providers (VISA, AMEX, ...)</returns>
        public IQueryable<CardProvider> GetCardProviders()
        {
            var result = from cardProv in infoDb.CardProviders
                         select cardProv;
            return result;
        }

    }
}