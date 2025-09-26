protected void btnDwnld_Click(object sender, EventArgs e)
{
    DataTable dt = new DataTable("BonusData");

    // ----- Headers -----
    foreach (DataControlField column in Grid.Columns)
    {
        // Only add visible columns and skip the ID column
        if (column.Visible && column.HeaderText != "ID")
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
            // Skip hidden columns and ID column
            if (!column.Visible || column.HeaderText == "ID") continue;

            string cellValue = string.Empty;

            // Check for controls inside the cell
            if (row.Cells[colIndex].Controls.Count > 0)
            {
                foreach (System.Web.UI.Control ctrl in row.Cells[colIndex].Controls)
                {
                    if (ctrl is TextBox tb)
                    {
                        cellValue = tb.Text.Trim();
                        break;
                    }
                    else if (ctrl is Label lbl)
                    {
                        cellValue = lbl.Text.Trim();
                        break;
                    }
                    else if (ctrl is DropDownList ddl)
                    {
                        cellValue = ddl.SelectedItem.Text.Trim();
                        break;
                    }
                }
            }

            // Fallback to cell text
            if (string.IsNullOrEmpty(cellValue) || cellValue == "&nbsp;")
            {
                cellValue = row.Cells[colIndex].Text.Trim();
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
