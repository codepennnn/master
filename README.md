using System;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;
using ClosedXML.Excel;

protected void btnDwnld_Click(object sender, EventArgs e)
{
    // Build a DataTable directly from the GridView
    DataTable dt = new DataTable("BonusData");

    // ----- Headers -----
    foreach (DataControlField column in Grid.Columns)
    {
        if (column.Visible)
        {
            dt.Columns.Add(column.HeaderText);
        }
    }

    // ----- Rows -----
    foreach (GridViewRow row in Grid.Rows)
    {
        DataRow dr = dt.NewRow();
        int colIndex = 0;

        foreach (DataControlField column in Grid.Columns)
        {
            if (!column.Visible) continue;

            // Try to capture any TextBox value if present
            string cellValue = string.Empty;
            if (row.Cells[colIndex].Controls.Count > 0 &&
                row.Cells[colIndex].Controls[0] is TextBox tb)
            {
                cellValue = tb.Text.Trim();
            }
            else
            {
                cellValue = row.Cells[colIndex].Text.Trim();
                // handle &nbsp;
                if (cellValue == "&nbsp;") cellValue = string.Empty;
            }

            dr[colIndex] = cellValue;
            colIndex++;
        }

        dt.Rows.Add(dr);
    }

    // ----- Export with ClosedXML -----
    using (XLWorkbook wb = new XLWorkbook())
    {
        wb.Worksheets.Add(dt);

        using (MemoryStream ms = new MemoryStream())
        {
            wb.SaveAs(ms);
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = 
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("Content-Disposition",
                "attachment; filename=Bonus_From_Grid.xlsx");
            Response.BinaryWrite(ms.ToArray());
            Response.Flush();
            Response.End();
        }
    }
}
