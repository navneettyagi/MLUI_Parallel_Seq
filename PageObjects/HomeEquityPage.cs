


using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLAutoFramework.PageObjects
{
    class HomeEquityPage
    {
        public static By HE_Purpose_Ddn = By.Id("HomeEquityPurposeID");

        public static By HE_Reason_Ddn = By.Id("RefinancePurpose");

        public static By HE_Rate_Type_Ddn = By.Id("RateType");

        public static By HE_Amt_Requested_Txt = By.Id("AmountRequested_AmountRequested");

        public static By HE_Loan_Term_Txt = By.Id("LoanTerm");

        public static By HE_Est_Property_Value_Txt = By.Id("EstimatedPropertyValue");

        public static By HE_Value_Source_Ddn = By.Id("PropertyValueSource_txtPropertyValueSource");

        public static By HE_Interview_Method_Ddn = By.Id("InterviewMethod_InterviewMethod");

        public static By HE_Occupancy_Status_Ddn = By.Id("PropertyOccupancyStatus");

        public static By HE_Property_Type_Ddn = By.Id("PropertyType");

        public static By HE_State_Ddn = By.Id("PropertyState");

        public static By HE_Sex_Male_Select_Box = By.Id("sa_HMDADemographic_SexMale");

        public static By HE_Race_American_Indian_Select_Box = By.Id("sa_HMDADemographic_isRaceAmericanIndian");

        public static By HE_Ethnicity_Not_Hispanic_Select_Box = By.Id("sa_HMDADemographic_EthnicityNotHispanic");

        public static By HE_Ethnicity_Radio_Btn = By.Id("sa_HMDADemographic_rblEthnicityYN_0");

        public static By HE_Sex_Radio_Btn = By.Id("sa_HMDADemographic_rblSexYN_0");

        public static By HE_Race_Radio_Btn = By.Id("sa_HMDADemographic_rblRaceYN_0");
    }
}
