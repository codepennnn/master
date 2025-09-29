public bool AreWorkOrdersInExemptionPeriod(string workOrdersCsv)
{
    string sql = @"
        SELECT COUNT(*) 
        FROM App_WorkOrder_Exemption
        WHERE Status = 'Approved'
          AND DATEDIFF(DAY, Approved_On, GETDATE()) <= Exemption_CC
          AND @WorkOrders LIKE '%' + WorkOrderNo + '%';
    ";

    Dictionary<string, object> parameters = new Dictionary<string, object>
    {
        { "@WorkOrders", workOrdersCsv }
    };

    DataHelper dh = new DataHelper();
    object result = dh.ExecuteScalar(sql, parameters);
    int count = Convert.ToInt32(result);

    return count > 0;
}



string selectedWorkordersCsv = PageRecordDataSet.Tables["App_WorkOrder_Exemption"]
                                 .Rows[0]["WorkOrderNo"].ToString();

if (blobj.AreWorkOrdersInExemptionPeriod(selectedWorkordersCsv))
{
    MyMsgBox.show(CLMS.Control.MyMsgBox.MessageType.Errors,
        "One or more work orders are already approved and still within the exemption period. Duplicate not allowed!");
    return;
}
