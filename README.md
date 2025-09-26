protected void btnDwnld_Click(object sender, EventArgs e)
{
    DataTable dt = new DataTable("BonusData");

    // ----- Build list of visible columns (skip ID) -----
    List<int> visibleColumnIndexes = new List<int>();
    foreach (DataControlField column in Grid.Columns)
    {
        if (column.Visible && column.HeaderText != "ID")
        {
            dt.Columns.Add(column.HeaderText);
            visibleColumnIndexes.Add(Grid.Columns.IndexOf(column)); // store actual index
        }
    }

    // ----- Rows -----
    foreach (GridViewRow row in Grid.Rows)
    {
        DataRow dr = dt.NewRow();

        for (int i = 0; i < visibleColumnIndexes.Count; i++)
        {
            int colIndex = visibleColumnIndexes[i];
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

            dr[i] = cellValue; // assign to DataRow
        }

        dt.Rows.Add(dr);
    }

    // ----- Export to Excel -----
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
