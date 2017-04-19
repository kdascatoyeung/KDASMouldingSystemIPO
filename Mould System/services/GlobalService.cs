using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Mould_System.functions.others;

namespace Mould_System.services
{
    public class GlobalService
    {
        public static List<string> PurchaseGroupList { get; set; }

        public static List<string> toRingiList { get; set; }

        public static SqlDataReader reader { get; set; }

        public static SqlDataAdapter adapter { get; set; }

        public static string gMouldNo { get; set; }

        public static string gItemCode { get; set; }

        public static List<string> RingiItemList { get; set; }

        public static List<ToFacContent> ToFacList { get; set; }

        public static List<string> fileUlList { get; set; }

        public static int selectedId { get; set; }

        public static string selectedChaseno { get; set; }

        public static List<string> ChaseNoList { get; set; }

        public static String IPO1st { get; set; }

        public static String IPO2nd { get; set; }

        public static SqlDataReader Reader { get; set; }

        public static String Owner { get; set; }

        public static String SelectedRingiNo { get; set; }

        public static String SelectedRingiContent { get; set; }

        public static String SelectedRingiBalance { get; set; }

        public static String Ringi { get; set; }
    }
}
