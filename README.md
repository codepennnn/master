public List<string> GetWorkOrdersInExemptionPeriod(string workOrdersCsv)
{
    string sql = @"
        SELECT w.WorkOrderNo
        FROM App_WorkOrder_Exemption AS w
        INNER JOIN STRING_SPLIT(@WorkOrders, ',') AS s
                ON LTRIM(RTRIM(s.value)) = w.WorkOrderNo
        WHERE w.Status = 'Approved'
          AND DATEDIFF(DAY, w.Approved_On, GETDATE()) <= w.Exemption_CC;
    ";

    var parameters = new Dictionary<string, object>
    {
        { "@WorkOrders", workOrdersCsv }
    };

    DataHelper dh = new DataHelper();
    DataSet ds = dh.GetDataset(sql, "App_WorkOrder_Exemption", parameters);

    return ds.Tables[0]
             .AsEnumerable()
             .Select(r => r.Field<string>("WorkOrderNo"))
             .ToList();
}



string csv = PageRecordDataSet.Tables["App_WorkOrder_Exemption"]
                              .Rows[0]["WorkOrderNo"]
                              .ToString();

List<string> conflicts = blobj.GetWorkOrdersInExemptionPeriod(csv);

if (conflicts.Any())
{
    string joined = string.Join(", ", conflicts);
    MyMsgBox.show(CLMS.Control.MyMsgBox.MessageType.Errors,
        $"The following work order(s) are already approved and still within the exemption period: {joined}. Duplicate not allowed!");
    return;
}
