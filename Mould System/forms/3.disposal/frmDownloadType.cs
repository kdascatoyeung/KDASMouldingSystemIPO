using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mould_System.file.excel;
using Mould_System.file.csv;

namespace Mould_System.forms._3.disposal
{
    public partial class frmDownloadType : Form
    {
        DataTable dltable;

        public frmDownloadType(DataTable table)
        {
            InitializeComponent();

            dltable = new DataTable();
            dltable = table;
        }

        private void Download(DataTable table)
        {
            ExportCsvUtil.ExportCsv(table, "", "DISPOSAL");
        }

        private void Open(DataTable table)
        {
            ExportXlsUtil.XlsUtil(table);
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            this.Download(dltable);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            this.Open(dltable);
        }
    }
}
