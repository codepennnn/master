  protected void btnNew_Click(object sender, EventArgs e)
  {
      //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "getClickedElement();", true);

      PageRecordDataSet.Clear();
      WorkOrder_Exemption_Records.SelectedIndex = -1;
      PageRecordDataSet.EnforceConstraints = false;
      WorkOrder_Exemption_Record.NewRecord();
      WorkOrder_Exemption_Record.BindData();
      DivInputFields.Visible = true;
      btnSave.Visible = true;
      }

         protected void WorkOrder_Exemption_Records_SelectedIndexChanged(object sender, EventArgs e)
   {
       GetRecord(WorkOrder_Exemption_Records.SelectedDataKey.Value.ToString());
       WorkOrder_Exemption_Records.SelectedIndex = -1;
       WorkOrder_Exemption_Record.BindData();
       DivInputFields.Visible = true;
       btnSave.Visible = true;
       


   }
