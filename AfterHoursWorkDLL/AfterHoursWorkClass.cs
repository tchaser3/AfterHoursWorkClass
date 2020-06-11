/* Title:           After Hours Work Class
 * Date:            6-10-20
 * Author:          Terry Holmes
 * 
 * Description:     This is the class used to access the after hours information */

using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using NewEventLogDLL;

namespace AfterHoursWorkDLL
{
    public class AfterHoursWorkClass
    {
        //setting up the classes
        EventLogClass TheEventLogClass = new EventLogClass();

        //setting up the data
        EmployeeOverNightWorkDataSet aEmployeeOverNightWorkDataSet;
        EmployeeOverNightWorkDataSetTableAdapters.employeeovernightworkTableAdapter aEmployeeOverNightWorkTableAdapter;

        InsertEmployeeOverNightWorkEntryTableAdapters.QueriesTableAdapter aInsertEmployeeOverNightWorkTableAdapter;

        FindEmployeeOverNightWorkbyDataEntryDateMatchDataSet aFindEmployeeOverNightWorkByDataEntryDateMatchDataSet;
        FindEmployeeOverNightWorkbyDataEntryDateMatchDataSetTableAdapters.FindEmployeeOverNightWorkByDataEntryDateMatchTableAdapter aFindEmployeeOverNightWorkByDataEntryDateMatchTableAdapter;

        FindEmployeeOverNightWorkByEmployeeIDDataSet aFindEmployeeOverNightWorkByEmployeeIDDataSet;
        FindEmployeeOverNightWorkByEmployeeIDDataSetTableAdapters.FindEmployeeOverNightWorkByEmployeeIDTableAdapter aFindEmployeeOverNightWorkByEmployeeIDTableAdapter;

        public FindEmployeeOverNightWorkByEmployeeIDDataSet FindEmployeeOverNightWorkByEmployeeID(int intEmployeeID, DateTime datStartDate, DateTime datEndDate)
        {
            try
            {
                aFindEmployeeOverNightWorkByEmployeeIDDataSet = new FindEmployeeOverNightWorkByEmployeeIDDataSet();
                aFindEmployeeOverNightWorkByEmployeeIDTableAdapter = new FindEmployeeOverNightWorkByEmployeeIDDataSetTableAdapters.FindEmployeeOverNightWorkByEmployeeIDTableAdapter();
                aFindEmployeeOverNightWorkByEmployeeIDTableAdapter.Fill(aFindEmployeeOverNightWorkByEmployeeIDDataSet.FindEmployeeOverNightWorkByEmployeeID, intEmployeeID, datStartDate, datEndDate);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "After Hours Work Class // Find Employee Over Night Work By Employee ID " + Ex.Message);
            }

            return aFindEmployeeOverNightWorkByEmployeeIDDataSet;
        }
        public FindEmployeeOverNightWorkbyDataEntryDateMatchDataSet FindEmployeeOverNightWorkByDataEntryDateMatch(DateTime datDataEntryDate)
        {
            try
            {
                aFindEmployeeOverNightWorkByDataEntryDateMatchDataSet = new FindEmployeeOverNightWorkbyDataEntryDateMatchDataSet();
                aFindEmployeeOverNightWorkByDataEntryDateMatchTableAdapter = new FindEmployeeOverNightWorkbyDataEntryDateMatchDataSetTableAdapters.FindEmployeeOverNightWorkByDataEntryDateMatchTableAdapter();
                aFindEmployeeOverNightWorkByDataEntryDateMatchTableAdapter.Fill(aFindEmployeeOverNightWorkByDataEntryDateMatchDataSet.FindEmployeeOverNightWorkByDataEntryDateMatch, datDataEntryDate);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "After Hours Work Class // Find Employee Over Night Work By Data Entry Date Match " + Ex.Message);
            }

            return aFindEmployeeOverNightWorkByDataEntryDateMatchDataSet;
        }
        public bool InsertEmployeeOverNightWork(int intOfficeID,  int intDepartmentID, int intEmployee, int intManagerID, int intVehicleID, int intProjectID, DateTime datWorkDate, string strOutTime, string strWorkLocation, string strInETA, DateTime datDataEntryDate)
        {
            bool blnFatalError = false;

            try
            {
                aInsertEmployeeOverNightWorkTableAdapter = new InsertEmployeeOverNightWorkEntryTableAdapters.QueriesTableAdapter();
                aInsertEmployeeOverNightWorkTableAdapter.InsertEmployeeOvernightWork(intOfficeID, intDepartmentID, intEmployee, intManagerID, intVehicleID, intProjectID, datWorkDate, strOutTime, strWorkLocation, strInETA, datDataEntryDate);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "After Hours Work Class // Insert Employee Over Night Work " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public EmployeeOverNightWorkDataSet GetEmployeeOverNightWorkInfo()
        {
            try
            {
                aEmployeeOverNightWorkDataSet = new EmployeeOverNightWorkDataSet();
                aEmployeeOverNightWorkTableAdapter = new EmployeeOverNightWorkDataSetTableAdapters.employeeovernightworkTableAdapter();
                aEmployeeOverNightWorkTableAdapter.Fill(aEmployeeOverNightWorkDataSet.employeeovernightwork);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "After Hours Work Class // Get Employee Over Night Work Info " + Ex.Message);
            }

            return aEmployeeOverNightWorkDataSet;
        }
        public void UpdateEmployeeOverNightWorkDB(EmployeeOverNightWorkDataSet aEmployeeOverNightWorkDataSet)
        {
            try
            {
                aEmployeeOverNightWorkTableAdapter = new EmployeeOverNightWorkDataSetTableAdapters.employeeovernightworkTableAdapter();
                aEmployeeOverNightWorkTableAdapter.Update(aEmployeeOverNightWorkDataSet.employeeovernightwork);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "After Hours Work Class // Update Employee Over Night Work DB " + Ex.Message);
            }
        }
    }
}
