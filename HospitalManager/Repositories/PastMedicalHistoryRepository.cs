using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HospitalManager.Models;

namespace HospitalManager.Repositories
{
    /// <summary>
    /// Handles adding to and modifying a user's past medical history
    /// </summary>
    public class PastMedicalHistoryRepository
    {
        private PastMedicalHistoryDatabase histDb = new PastMedicalHistoryDatabase();

        /// <summary>
        /// Get a user's past medical history
        /// </summary>
        /// <param name="user">User for which to get medical history</param>
        /// <returns>Medical history for user user</returns>
        public PastMedicalHistory GetPastMedicalHistory(User user)
        {
            var medicalHistory = from hist in histDb.PastMedicalHistories
                                 where hist.UserID == user.UserID
                                 select hist;

            if (medicalHistory.Count() == 0)
                return null;

            PastMedicalHistory result = medicalHistory.First();
            result.LoadConditions();

            return result;
        }

        /// <summary>
        /// Update a user's past medical history
        /// </summary>
        /// <param name="history">History to update or insert</param>
        public void SetPastMedicalHistory(PastMedicalHistory history)
        {
            var medicalHistory = from hist in histDb.PastMedicalHistories
                                 where hist.UserID == history.UserID
                                 select hist;

            if (medicalHistory.Count() == 0)
            {
                // No record exists, insert
                histDb.PastMedicalHistories.InsertOnSubmit(history);
                histDb.SubmitChanges();
            }
            else
            {
                // A records exists, update
                var record = medicalHistory.Single();
                record.Height = history.Height ?? 0;
                record.Weight = history.Weight ?? 0;
                record.Age = history.Age ?? 0;
                record.Gender = history.Gender ?? "Undefined";
                record.Ethnicity = history.Ethnicity ?? "Undefined";
                record.Allergies = history.Allergies ?? "None";
                record.Operations = history.Operations ?? "None";
                histDb.SubmitChanges();
            }
        }

        /// <summary>
        /// Get all defined medical conditions
        /// </summary>
        /// <returns>List of defined medical conditions</returns>
        public IQueryable<MedicalCondition> GetAllMedicalConditions()
        {
            return from cond in histDb.MedicalConditions
                   orderby cond.ConditionName ascending
                   select cond;
        }

        /// <summary>
        /// Get all defined family members
        /// </summary>
        /// <returns>List of family members</returns>
        public IQueryable<FamilyMember> GetAllFamilyMembers()
        {
            return from member in histDb.FamilyMembers
                   select member;
        }

        /// <summary>
        /// Remove a patient's medical condition
        /// </summary>
        /// <param name="user">User from which to remove the condition</param>
        /// <param name="conditionID">Condition to remove</param>
        public void DeletePatientMedicalCondition(User user, int conditionID)
        {
            var result = from cond in histDb.PatientConditions
                         where cond.UserID == user.UserID &&
                               cond.ConditionID == conditionID
                         select cond;

            if (result.Count() == 0)
                return;

            histDb.PatientConditions.DeleteOnSubmit(result.First());
            histDb.SubmitChanges();
        }

        /// <summary>
        /// Add a medical condition for a user
        /// </summary>
        /// <param name="user">User for which to add a condition</param>
        /// <param name="medicalCondition">Condition to add</param>
        /// <returns>False on failure, true on success</returns>
        public bool AddPatientMedicalCondition(User user, int medicalCondition)
        {
            // Make sure the user does not already have the condition assigned to them
            var result = from cond in histDb.PatientConditions
                         where cond.ConditionID == medicalCondition &&
                               cond.UserID == user.UserID
                         select cond;

            if (!MedicalConditionExists(medicalCondition) || result.Count() != 0)
                return false;

            // Insert the condition
            var patientCondition = new PatientCondition()
            {
                UserID = user.UserID,
                ConditionID = medicalCondition
            };

            histDb.PatientConditions.InsertOnSubmit(patientCondition);
            histDb.SubmitChanges();

            return true;
        }

        /// <summary>
        /// Remove a family member's other medical condition
        /// </summary>
        /// <param name="user">The user associated with the family member</param>
        /// <param name="otherConditionID">Condition id to remove</param>
        public void DeleteOtherPatientMedicalCondition(User user, int otherConditionID)
        {
            var result = from cond in histDb.OtherPatientConditions
                         where cond.OtherConditionID == otherConditionID &&
                               cond.UserID == user.UserID
                         select cond;

            if (result.Count() == 0)
                return;

            histDb.OtherPatientConditions.DeleteOnSubmit(result.First());
            histDb.SubmitChanges();
        }

        /// <summary>
        /// Add a family member's other medical condition
        /// </summary>
        /// <param name="user">User for which to add the condition</param>
        /// <param name="condition">Condition to add</param>
        /// <returns>False on failure, true on success</returns>
        public bool AddOtherPatientMedicalCondition(User user, string condition)
        {
            // Make sure this condition has not been inserted already
            var assigned = from cond in histDb.OtherPatientConditions
                           where cond.UserID == user.UserID &&
                                 cond.Condition == condition
                           select cond;

            if (assigned.Count() != 0)
                return false;

            // Insert the condition
            var patientCondition = new OtherPatientCondition()
            {
                UserID = user.UserID,
                Condition = condition
            };

            histDb.OtherPatientConditions.InsertOnSubmit(patientCondition);
            histDb.SubmitChanges();

            return true;
        }

        /// <summary>
        /// Remove a family member's medical condition
        /// </summary>
        /// <param name="user">User associated with the family member</param>
        /// <param name="memberID">ID of the family member</param>
        /// <param name="conditionID">ID of the condition</param>
        public void DeleteFamilyMedicalCondition(User user, int memberID, int conditionID)
        {
            var result = from cond in histDb.FamilyConditions
                         where cond.UserID == user.UserID &&
                               cond.FamilyMemberID == memberID &&
                               cond.ConditionID == conditionID
                         select cond;

            if (result.Count() == 0)
                return;

            histDb.FamilyConditions.DeleteOnSubmit(result.First());
            histDb.SubmitChanges();
        }


        /// <summary>
        /// Add a family member's medical condition
        /// </summary>
        /// <param name="user">User associated with the family member</param>
        /// <param name="memberID">ID of family member</param>
        /// <param name="conditionID">ID of condition</param>
        /// <returns>False on failure, true on success</returns>
        public bool AddFamilyMedicalCondition(User user, int memberID, int conditionID)
        {

            // Make sure the family member does not already have the condition
            var assigned = from cond in histDb.FamilyConditions
                         where cond.ConditionID == conditionID &&
                               cond.UserID == user.UserID &&
                               cond.FamilyMemberID == memberID
                         select cond;

            // Do the data checks
            if (!FamilyMemberExists(memberID) ||
                !MedicalConditionExists(conditionID) ||
                assigned.Count() != 0)
            {
                return false;
            }

            // Insert the condition
            var familyCondition = new FamilyCondition()
            {
                UserID = user.UserID,
                FamilyMemberID = memberID,
                ConditionID = conditionID
            };

            histDb.FamilyConditions.InsertOnSubmit(familyCondition);
            histDb.SubmitChanges();

            return true;
        }

        /// <summary>
        /// Remove a family member's other medical condition
        /// </summary>
        /// <param name="user">User associated with the family member</param>
        /// <param name="otherConditionID">ID of the condition</param>
        public void DeleteOtherFamilyMedicalCondition(User user, int otherConditionID)
        {
            var result = from cond in histDb.OtherFamilyConditions
                         where cond.OtherConditionID == otherConditionID &&
                               cond.UserID == user.UserID
                         select cond;

            if (result.Count() == 0)
                return;

            histDb.OtherFamilyConditions.DeleteOnSubmit(result.First());
            histDb.SubmitChanges();
        }

        /// <summary>
        /// Add a family member's other medical condition
        /// </summary>
        /// <param name="user">User associated with the family member</param>
        /// <param name="memberID">Family member ID</param>
        /// <param name="condition">Condition ID</param>
        /// <returns>False on failure, true on success</returns>
        public bool AddOtherFamilyMedicalCondition(User user, int memberID, string condition)
        {
            // Make sure this condition has not been inserted already
            var assigned = from cond in histDb.OtherFamilyConditions
                           where cond.UserID == user.UserID &&
                                 cond.FamilyMemberID == memberID &&
                                 cond.Condition == condition
                           select cond;

            if (!FamilyMemberExists(memberID) || assigned.Count() != 0)
                return false;

            // Insert the condition
            var familyCondition = new OtherFamilyCondition()
            {
                UserID = user.UserID,
                FamilyMemberID = memberID,
                Condition = condition
            };

            histDb.OtherFamilyConditions.InsertOnSubmit(familyCondition);
            histDb.SubmitChanges();

            return true;
        }

        /// <summary>
        /// Get a patient's conditions
        /// </summary>
        /// <param name="userID">ID of patient</param>
        /// <returns>List of conditions</returns>
        public List<PatientCondition> GetPatientConditions(int userID)
        {
            return (from condition in histDb.PatientConditions
                    where condition.UserID == userID
                    select condition).ToList();
        }

        /// <summary>
        /// Get a patient's other conditions
        /// </summary>
        /// <param name="userID">ID of patient</param>
        /// <returns>List of patient's other conditions</returns>
        public List<OtherPatientCondition> GetOtherPatientConditions(int userID)
        {
            return (from condition in histDb.OtherPatientConditions
                    where condition.UserID == userID
                    select condition).ToList();
        }

        /// <summary>
        /// Get a user's family's conditions
        /// </summary>
        /// <param name="userID">ID of user</param>
        /// <returns>The user's family's conditions</returns>
        public List<FamilyCondition> GetFamilyConditions(int userID)
        {
            return (from condition in histDb.FamilyConditions
                    where condition.UserID == userID
                    select condition).ToList();
        }

        /// <summary>
        /// Get a user's family's other conditions
        /// </summary>
        /// <param name="userID">ID of user</param>
        /// <returns>The user's family's other conditions</returns>
        public List<OtherFamilyCondition> GetOtherFamilyConditions(int userID)
        {
            return (from condition in histDb.OtherFamilyConditions
                    where condition.UserID == userID
                    select condition).ToList();
        }


        /* Private utility methods for validation purposes */

        /// <summary>
        /// Checks if a medical condition exists
        /// </summary>
        /// <param name="conditionID">ID of condition</param>
        /// <returns>True if it exists, false otherwise</returns>
        private bool MedicalConditionExists(int conditionID)
        {
            var conds = from cond in histDb.MedicalConditions
                        where cond.ConditionID == conditionID
                        select cond;
            bool result = conds.Count() != 0;
            return result;
        }

        /// <summary>
        /// Checks if a family member exists
        /// </summary>
        /// <param name="memberID">ID of family member</param>
        /// <returns>True if it exists, false otherwise</returns>
        private bool FamilyMemberExists(int memberID)
        {
            var members = from member in histDb.FamilyMembers
                          where member.FamilyMemberID == memberID
                          select member;
            bool result = members.Count() != 0;
            return result;
        }
    }
}