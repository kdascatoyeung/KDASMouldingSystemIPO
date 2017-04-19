using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Mould_System.test
{
    public interface IDataPageRetriever
    {
        DataTable SupplyPageOfData(int lowerPageBoundary, int rowsPerPage);
    }
}
