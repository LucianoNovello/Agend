using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
namespace Utils
{
    public static class DataSetHelper{
        public static bool HasRecords(DataSet ds)
        {
            return
                ds != null
                && ds.Tables.Count > 0
                && ds.Tables[0].Rows.Count > 0;
        }

    }
}
