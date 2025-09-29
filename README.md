public List<string> GetWorkOrdersInExemptionPeriod(string workOrders)
{
    string sql = @"SELECT w.WorkOrderNo FROM App_WorkOrder_Exemption AS w INNER JOIN STRING_SPLIT(@workOrders, ',') AS s ON LTRIM(RTRIM(s.value)) = w.WorkOrderNo WHERE w.Status = 'Approved' AND DATEDIFF(DAY, w.Approved_On, GETDATE()) <= w.Exemption_CC;";

    Dictionary<string, object> objParam = new Dictionary<string, object>();
    objParam.Add("workOrders", workOrders);  

    DataHelper dh = new DataHelper();
    DataSet ds = dh.GetDataset(sql, "App_WorkOrder_Exemption", objParam);

    return ds.Tables[0]
             .AsEnumerable()
             .Select(r => r.Field<string>("WorkOrderNo"))
             .ToList();
}

  //validation - Approved work orders should not be repeated within the exempted period defined by the CC team

  string workOrders = PageRecordDataSet.Tables["App_WorkOrder_Exemption"]
                     .Rows[0]["WorkOrderNo"]
                     .ToString();

  List<string> conflicts = blobj.GetWorkOrdersInExemptionPeriod(workOrders);

  if (conflicts.Any())
  {
      string joined = string.Join(", ", conflicts);
      MyMsgBox.show(CLMS.Control.MyMsgBox.MessageType.Errors,
          $"The following work order(s) are already approved and still within the exemption period: {joined}. Duplicate not allowed!");
      return;
  }


  use like operator  - ( WorkOrderNo = @WorkOrder
        OR WorkOrderNo LIKE @WorkOrder + ',%'
        OR WorkOrderNo LIKE '%,' + @WorkOrder + ',%'
        OR WorkOrderNo LIKE '%,' + @WorkOrder )
