public List<string> GetWorkOrdersInExemptionPeriod(string workOrder)
{
    // Use your requested LIKE-pattern logic
    string sql = @"
        SELECT w.WorkOrderNo
        FROM App_WorkOrder_Exemption AS w
        WHERE w.Status = 'Approved'
          AND DATEDIFF(DAY, w.Approved_On, GETDATE()) <= w.Exemption_CC
          AND (
                w.WorkOrderNo = @WorkOrder
             OR w.WorkOrderNo LIKE @WorkOrder + ',%'
             OR w.WorkOrderNo LIKE '%,' + @WorkOrder + ',%'
             OR w.WorkOrderNo LIKE '%,' + @WorkOrder
          );
    ";

    // Parameter dictionary — match name exactly
    Dictionary<string, object> objParam = new Dictionary<string, object>
    {
        { "@WorkOrder", workOrder }
    };

    DataHelper dh = new DataHelper();
    DataSet ds = dh.GetDataset(sql, "App_WorkOrder_Exemption", objParam);

    // Convert the first table’s rows to a list of strings
    return ds.Tables[0]
             .AsEnumerable()
             .Select(r => r.Field<string>("WorkOrderNo"))
             .ToList();
}




string[] workOrders = PageRecordDataSet.Tables["App_WorkOrder_Exemption"]
                                       .Rows[0]["WorkOrderNo"]
                                       .ToString()
                                       .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

foreach (string wo in workOrders)
{
    List<string> conflicts = blobj.GetWorkOrdersInExemptionPeriod(wo.Trim());

    if (conflicts.Any())
    {
        string joined = string.Join(", ", conflicts);
        MyMsgBox.show(CLMS.Control.MyMsgBox.MessageType.Errors,
            $"The following work order(s) are already approved and still within the exemption period: {joined}. Duplicate not allowed!");
        return;
    }
}
