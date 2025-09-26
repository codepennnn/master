protected void btnDwnld_Click(object sender, EventArgs e)
{
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

            string cellValue = string.Empty;

            // Check for TextBox
            TextBox tb = row.Cells[colIndex].FindControl("Bonus_Paid_Amount") as TextBox;
            if (tb == null) tb = row.Cells[colIndex].FindControl("Bonus_UnPaid_Amount") as TextBox;
            if (tb != null)
            {
                cellValue = tb.Text.Trim();
            }
            else
            {
                // Check for Label
                Label lbl = row.Cells[colIndex].FindControl("lblID") as Label ??
                            row.Cells[colIndex].FindControl("lblYear") as Label ??
                            row.Cells[colIndex].FindControl("lblVcode") as Label ??
                            row.Cells[colIndex].FindControl("lblAadharNo") as Label ??
                            row.Cells[colIndex].FindControl("lblWorkManSlno") as Label ??
                            row.Cells[colIndex].FindControl("lblWorkorderNo") as Label ??
                            row.Cells[colIndex].FindControl("lblWorkManCategory") as Label ??
                            row.Cells[colIndex].FindControl("lblWorkManName") as Label ??
                            row.Cells[colIndex].FindControl("lblTotaldaysWorked") as Label ??
                            row.Cells[colIndex].FindControl("lblTotalWages") as Label ??
                            row.Cells[colIndex].FindControl("lblPuja_Bonus") as Label ??
                            row.Cells[colIndex].FindControl("lblInterim_Bonus") as Label ??
                            row.Cells[colIndex].FindControl("lblDeduction_misconduct_emp") as Label ??
                            row.Cells[colIndex].FindControl("lblTotal_deduction") as Label ??
                            row.Cells[colIndex].FindControl("lblBonusPayableAmount") as Label ??
                            row.Cells[colIndex].FindControl("lblBankStatementSlno") as Label;

                if (lbl != null)
                    cellValue = lbl.Text.Trim();
                else
                    cellValue = row.Cells[colIndex].Text.Trim(); // fallback
            }

            // handle &nbsp;
            if (cellValue == "&nbsp;") cellValue = string.Empty;

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
