using Azure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace UMR.Requestor.Models
{
    public static class ExcelData
    {

        public static List<Request> requests = new List<Request>
        {
        new Request
        {
            ProjectTitle = "Routing logic - change to Medicare Rule",
            ProjectStatus = ProjectStatus.New,
            Description = "Allow claims to route for pricing when Medicare is secondary and when Medicare does not cover the service",
            Reason = "Process improvement. Manual work in current process is extensive, and not easily trackable or reportable",
            PIPP = "PLC11637",
            UserStory = "TBD",
            ITInstallDate = DateTime.Now,
            Ownership = "Capital",
            SME = "Scott Senalik",
            Notes = "11/13/24 - This is included in a group of initiatives under Network Optimization - has been approved for 2025 Included in 3/6/24 - Included in 2025/2026 Product Captial Roadmap. 1/4/24 - Prioritized. BOB. 10/27/23 - AHA template completed 10/11/23 - Key contacts updated in communicaiton. Scott to FU if Aha was submitted, etc. 9/27 - No Updates. 8/30 - Sized as capital.. To Laura Rhyme & Raina for funding.",
            PriorityRanking = "1.0",
            Contingency = null,
            Risk = null,
            BlueChip = null
        },
        new Request
        {
            ProjectTitle = "Nexus Tier Issues",
            ProjectStatus = ProjectStatus.New,
            Description = "One claim is pulling a tier indicator while others are not when the providers are the same and they are billing from the same locations.CCN 24239142453 CCN 24176378453",
            Reason = "NX99 should pay at tier 1 level of benefits.",
            PIPP = "12878",
            UserStory = "TBD",
            ITInstallDate =  DateTime.Now,
            Ownership = "Garnet",
            SME = "Stephanie Wallace",
            Notes = "2/5/25 - Reviewed; keeping same priority 12/4/24 - Question out to Stephanie. Pending response. 10/23/24 - Ck w/Stephanie re: volume Sizing Complete",
            PriorityRanking = "1.0",
            Contingency = null,
            Risk = null,
            BlueChip = null
        },
        new Request
        {
            ProjectTitle = "Bundle 492T ability to read Type of Bill",
            ProjectStatus = ProjectStatus.New,
            Description = "Would like the 492T OP Bundle table to be able to decipher TOB or POS so that more than one implant selectoin can be used.",
            Reason = "All allowable implants HCPCS codes for both ASC facilities and OP facilities are loaded to the selection BCB. Then if an allowable implant is billed, it is allowed as part of the bundle package, then the claim is then pended to MRU for them to make the determination if the implant is allowable based on place of service, and if not, they reduce the bundle allow by the billed charges of the implant.",
            PIPP = "PLC11638",
            UserStory = "TBD",
            ITInstallDate =  DateTime.Now,
            Ownership = "Capital",
            SME = "Christina Ruby Stephanie Brackney",
            Notes = "3/6/24 - Included in 2025/2026 Product Captial Roadmap. 1/4/24 - Prioritized. No target date committed due to capital just know we have to complete due to open issues global log 10/24/23 - PLC Pending",
            PriorityRanking = "2.0",
            Contingency = "Manual processes",
            Risk = "This is causing MRU pends. (Impact is manual process & claims may be pd inappropriately) Volume needed?",
            BlueChip = null
        },
        new Request
        {
            ProjectTitle = "EGID - Provider OPI HCJ and HC2 with EE OPI's DOCM, MHCO and MDHC to read eff and term as DOS vs processed date",
            ProjectStatus = ProjectStatus.New,
            Description = "Would like the BIF0059T for provider OPI's HCJ and HC2 combined with employee OPI's MHCO, MDHC and DOCM effective and term dates to be based on dates of service vs processed date. The CPT codes loaded on this table are based off of quarterly fee schedules in which the effective and term dates are service date based. The BIF0059T should be coded the same as the fee schedule dates.",
            Reason = "Currently the 59T Exceptions table the effective date and term date is based on processed date and not by effective date for the Provider OPI and Provider OPI/Employee combinations. Exception is for DRC and 0L for HAH2 and HAH3 which are based on DOS.",
            PIPP = "12129",
            UserStory = "TBD",
            ITInstallDate =  DateTime.Now,
            Ownership = "Garnet",
            SME = "Jean Stenzel",
            Notes = "2/5/25 - Reviewed; keeping same priority 10/23/24 - Continue w/priority #1 3/13/24 not on Tracy's list yet 2/7/24 - IT sizing complete.",
            PriorityRanking = "2.0",
            Contingency = null,
            Risk = null,
            BlueChip = null
        },
        new Request
        {
            ProjectTitle = "Update the Medicare Lab process",
            ProjectStatus = ProjectStatus.New,
            Description = "Currently, PCI is running macros to update about 250,000 lines for the Medicare Lab file, would like to implement a more efficient process w/ IT",
            Reason = "The Medicare Lab Fee File is loaded by PCI via a Macro. We get quarterly updates for these. The lab file in the past was loaded by IT and when Medicare started quarterly updates we have to change it to PCI to load due to IT not being able to load these files quarterly. We would like to review this process and determine what can be done to have IT to load these file as they do for the Phycian Medicare file loads.",
            PIPP = "11240",
            UserStory = "US6548036 - not prioritized yet",
            ITInstallDate =  DateTime.Now,
            Ownership = "Garnet",
            SME = "Adam Donner Laura Rice",
            Notes = "3/19/25 - Updated priority. 2/5/25 - Reviewed; keeping same priority 10/23/24 - Reviewed. 3/13/24 not on Tracy's list…11/29/23 - Updated to priority ranking 1",
            PriorityRanking = "3.0",
            Contingency = "continue with manual process or code custom logic contract by contract like PEIA * EGID",
            Risk = "high volume manual process with claim delay, causes backlog of pricing and errors",
            BlueChip = null
        },
        new Request
        {
            ProjectTitle = "New EDI connection for SHO/BHO/NNHN networks",
            ProjectStatus = ProjectStatus.New,
            Description = "Placeholder for SHO/BHO/NNHN pricing moving from internal to external vendor pricing. Also ability to tier networks and validate MRF and CPTT processes.",
            Reason = "SHO to maintain SHO NTWKs eff 1/1/25 rather than being internally priced.",
            PIPP = "PLC12371",
            UserStory = "TBD",
            ITInstallDate =  DateTime.Now,
            Ownership = "Garnet",
            SME = "John Miller Scott Senalik",
            Notes = "2/5/25 -On IT tracker. Robin TB w/Tracy re: PIPP # 4/12/24 - Gatekeeper approved",
            PriorityRanking = null,
            Contingency = null,
            Risk = null,
            BlueChip = null
        },
        new Request
        {
            ProjectTitle = "Rounding when Fee Schedule is set to Pend",
            ProjectStatus = ProjectStatus.New,
            Description = "Rounding issue on large dollar FNF claims causing discount and payment errors",
            Reason = "In order to pay claims correctly",
            PIPP = "12180",
            UserStory = "TBD",
            ITInstallDate =  DateTime.Now,
            Ownership = "Garnet",
            SME = "Scott Senalik",
            Notes = "2/5/25 - Reviewed; keeping same priority 10/23/24 - Reviewed 3/13/24 - not on Tracy's list…2/14/24 - Per Dental ability to only use PFS-driven fee schedules, need to maintain both processes. 2/13 - need PCI decision to ask for logic for GJWZ only, or are we still maintaining the old, outdated PFS fee schedule process with GJNF? Low volume of known issues. 2 large claims for one provider; one claim was caught in MRU and processed correctly, one was not caught and processed incorreclty.",
            PriorityRanking = "4.0",
            Contingency = "Don't validate changes",
            Risk = "Possible errors in claim data, payments and system or file issues",
            BlueChip = null
        }
        };
    }
}
