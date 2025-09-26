   public bool IsWorkOrderInExemptionPeriod(string workOrderNo)
   {
       string StrSQL = "SELECT COUNT(*) FROM App_WorkOrder_Exemption WHERE WorkOrderNo = @WorkOrderNo AND Status = 'Approved' AND DATEDIFF(DAY, Approved_On, GETDATE()) <= Exemption_CC;";
       Dictionary<string, object> objParam = new Dictionary<string, object>();
       DataHelper dh = new DataHelper();
       return dh.GetDataset(StrSQL, "App_WorkOrder_Exemption", objParam);
   }

  //validation - Approved work orders should not be repeated within the exempted period defined by the CC team

  string[] selectedWorkorders = PageRecordDataSet.Tables["App_WorkOrder_Exemption"]
                                  .Rows[0]["WorkOrderNo"].ToString()
                                  .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

  foreach (string wo in selectedWorkorders)
  {
      if (blobj.IsWorkOrderInExemptionPeriod(wo.Trim()))
      {
          MyMsgBox.show(CLMS.Control.MyMsgBox.MessageType.Errors,
              $"Work Order {wo} is already approved and still within the exemption period. Duplicate not allowed!");
          return;   
      }
  }
