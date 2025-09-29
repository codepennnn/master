public List<string> GetWorkOrdersInExemptionPeriod(string workOrders)
{
    string sql = @"
        SELECT w.WorkOrderNo
        FROM App_WorkOrder_Exemption AS w
        INNER JOIN STRING_SPLIT(@WorkOrders, ',') AS s
                ON LTRIM(RTRIM(s.value)) = w.WorkOrderNo
        WHERE w.Status = 'Approved'
          AND DATEDIFF(DAY, w.Approved_On, GETDATE()) <= w.Exemption_CC;
    ";

    Dictionary<string, object> objParam = new Dictionary<string, object>();
    objParam.Add("@WorkOrders", workOrders);   // <-- match SQL exactly

    DataHelper dh = new DataHelper();
    DataSet ds = dh.GetDataset(sql, "App_WorkOrder_Exemption", objParam);

    return ds.Tables[0]
             .AsEnumerable()
             .Select(r => r.Field<string>("WorkOrderNo"))
             .ToList();
}
