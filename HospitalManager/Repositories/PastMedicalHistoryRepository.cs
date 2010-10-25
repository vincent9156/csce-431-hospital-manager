using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HospitalManager.Models;

namespace HospitalManager.Repositories
{
    public class PastMedicalHistoryRepository
    {
        private PastMedicalHistoryDatabase histDb = new PastMedicalHistoryDatabase();

        /**
         * Get a user's past medical history
         */
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

        /**
         * Update a user's past medical history
         */
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

        /**
         * Get all defined medical conditions
         */
        public IQueryable<MedicalCondition> GetAllMedicalConditions()
        {
            return from cond in histDb.MedicalConditions
                   orderby cond.ConditionName ascending
                   select cond;
        }

        /**
         * Get all defined family members
         */
        public IQueryable<FamilyMember> GetAllFamilyMembers()
        {
            return from member in histDb.FamilyMembers
                   select member;
        }

        /**
         * Remove a patient's medical condition
         */
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

        /**
         * Add a medical condition for a user
         */
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

        /**
         * Remove a family member's other medical condition
         */
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

        /**
         * Add a family member's other medical condition
         */
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

        /**
         * Remove a family member's medical condition
         */
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


        /**
         * Add a family member's medical condition
         */
        public bool AddFamilyMedicalCondition(User user, int memberID, int conditionID)
        {

            // Make sure the family member does not already have the condition
            var assigned = from cond in histDb.PatientConditions
                         where cond.ConditionID == conditionID &&
                               cond.UserID == user.UserID
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

        /**
         * Remove a family member's other medical condition
         */
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

        /**
         * Add a family member's other medical condition
         */
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


        /** Private utility methods for validation purposes **/


        private bool MedicalConditionExists(int conditionID)
        {
            var conds = from cond in histDb.MedicalConditions
                        where cond.ConditionID == conditionID
                        select cond;
            return conds.Count() != 0;
        }

        private bool FamilyMemberExists(int memberID)
        {
            var members = from member in histDb.FamilyMembers
                          where member.FamilyMemberID == memberID
                          select member;
            return members.Count() != 0;
        }
    }
}