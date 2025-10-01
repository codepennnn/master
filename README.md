<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WorkOrder_Exemption.aspx.cs" Inherits="CLMS.App.Input.WorkOrder_Exemption" MaintainScrollPositionOnPostback="true" %>
<%@ Register Assembly="CustomControls" Namespace="GridViewasContainer" TagPrefix="cc1" %>
<%@ Register Src="~/Control/MyMsgBox.ascx" TagName="MyMsgBox" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ask" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
  
 
   <script type="text/javascript">

       document.addEventListener('DOMContentLoaded', function () {

       var allBox = document.querySelector('.select-all input[type="checkbox"]');
      
       var itemBoxes = document.querySelectorAll('.item-check input[type="checkbox"]');

  
       allBox.addEventListener('change', function () {
           itemBoxes.forEach(function (cb) {
               cb.checked = allBox.checked;
           });
       });

     
       itemBoxes.forEach(function (cb) {
           cb.addEventListener('change', function () {
        
               allBox.checked = Array.from(itemBoxes).every(function (c) { return c.checked; });
           });
       });
 


       });


       function validateCompliance() {
           
           var checks = document.querySelectorAll(".compliance-check input[type='checkbox']");
           var atLeastOne = Array.from(checks).some(cb => cb.checked);

           if (!atLeastOne) {
               alert("Please select at least one Compliance Type.");
               return false; 
           }
           return true; 
       }
   </script>
 

     <script type="text/javascript">



         function filterCheckBox(e) {
             // Declare variables
             var input, filter, table, tbody, tr, td, a, i, txtValue;
             input = e.value.trim();
             //if (input != "") {
             //    e.nextSibling.nextSibling.innerHTML = '<div class="w-80 text-center mt-2" ><div class="spinner-border spinner-border-sm text-primary" role="status"><span class="sr-only">Loading...</span></div><strong style="font-size:10px"> Loading..</strong></div>';
             //}
             //input = document.getElementById('MainContent_SearchObserver');
             filter = input.toUpperCase();
             //table = document.getElementById("MainContent_ObserverList");e.nextSibling.nextSibling
             table = e.nextSibling.nextSibling.childNodes[1];
             tbody = table.getElementsByTagName('tbody');
             tr = table.getElementsByTagName('tr');

             // Loop through all list items, and hide those who don't match the search query
             for (i = 0; i < tr.length; i++) {
                 a = tr[i].getElementsByTagName("td")[0];
                 txtValue = a.textContent || a.innerText;
                 if (txtValue.toUpperCase().indexOf(filter) > -1) {

                     tr[i].style.display = "";
                 } else {
                     tr[i].style.display = "none";
                 }
             }


         }

         function getClickedElement() {

             //PageMethods.ProcessIT("bvnbv", "bvnbv", onSucess, onError);
             //function onSucess(result) {
             //    alert(result);
             //}

             //function onError(result) {
             //    alert('Something wrong.');
             //}
             var specifiedElement = document.getElementsByClassName('VendorColumn');
             for (var i = 0; i < specifiedElement.length; i++) {

                 specifiedElement[i].childNodes[3].childNodes[3].onclick = function (event) {
                     var target = getEventTarget(event);
                     var data = target.parentNode.getAttribute("data-index-no");

                     //$("#MainContent_VendorViolationRecord_VendorName_0").append($("<option></option>").val
                     //    ("").html("select"));
                     //$("#MainContent_VendorViolationRecord_VendorName_0").text("ram");
                     //document.getElementById("MainContent_VendorViolationRecord_VendorName_0").value = data;
                     event.currentTarget.nextElementSibling.value = data;
                     event.currentTarget.previousElementSibling.value = "";
                     event.currentTarget.nextElementSibling.onchange();
                     // document.getElementById("MainContent_VendorViolationRecord_SearchObserver_0").value = "";
                     //document.getElementById("MainContent_VendorViolationRecord_VendorName_0").selectedIndex = 1;
                     //document.getElementById("MainContent_VendorViolationRecord_VendorName_0").onchange();
                     //return true;
                 };


                 if (specifiedElement[i].childNodes[3].childNodes[5].value.trim() == "")
                     specifiedElement[i].childNodes[1].childNodes[1].innerHTML = "No item selected";
                 else
                     specifiedElement[i].childNodes[1].childNodes[1].innerHTML = specifiedElement[i].childNodes[3].childNodes[5].value.trim();
             }

             //var ul = document.getElementById("searchList");


             //if (document.getElementById("MainContent_VendorViolationRecord_VendorName_0").value.trim() == "")
             //    document.getElementById("filter-option").innerHTML = "No item selected";
             //else
             //    document.getElementById("filter-option").innerHTML = document.getElementById("MainContent_VendorViolationRecord_VendorName_0").value;
         }

        //function validateCombobox() {
        //    var comboboxId = document.getElementById('Department_HOD_TextBox');


        //    if (comboboxId.value === "") {
        //        alert("Please Select!!!!!");
        //        return false;
        //    }

        //    return true;

        //}



         //function updateSelectedWorkorder() {
         //    alert("ok");
         //    var selected = [];
         //    document.querySelectorAll('[id*="WorkOrderNo"] input[type="checkbox"]').forEach(function (cb) {
         //        if (cb.checked) {
         //            selected.push(cb.parentElement.textContent.trim());
         //        }
         //    });
         //    document.querySelector('[id$="TextBox1"]').value = selected.join(", ");

         //    alert("selected");
         //}

         //window.onload = function () {
         //    setTimeout(function () {
         //        document.querySelectorAll('[id*="WorkOrderNo"] input[type="checkbox"]').forEach(function (cb) {
         //            cb.addEventListener("change", updateSelectedWorkorder);
         //        });
         //    }, 300);
         //};







     </script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <uc1:MyMsgBox ID="MyMsgBox" runat="server" />
    </div>

       <div class="card m-2 shadow-lg">
        <div class="card-header bg-info text-light">
            <h6 class="m-0">WorkOrder Exemption</h6>
        </div>
    </div>
  <div class="card-body pt-1">
        <fieldset class="" style="border: 1px solid #bfbebe; padding: 5px 20px 5px 20px; border-radius: 6px; overflow: auto">
            <legend style="width: auto; border: 0; font-size: 14px; margin: 0px 6px 0px 6px; padding: 0px 5px 0px 5px; color: darkslategray"><b>Search</b></legend>

            <div class="form-inline row">

                <div class="form-group col-md-12 mb-1">
                    <label for="lblWorkOrderNo" class="m-0 mr-0 p-0 col-form-label-sm col-sm-1 font-weight-bold fs-6">Work Order No:</label>
                    <asp:TextBox ID="txt_WorkOrderNo" runat="server" CssClass="form-control form-control-sm" AutoComplete="off"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                           <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn  btn-info btn-sm btn-success ml-1" OnClick="btnSearch_Click" />
                    <asp:Button ID="btnNew" runat="server" Text="New" OnClick="btnNew_Click" CssClass="btn  btn-info btn-sm btn-primary ml-4" />

                </div>
            </div>

        </fieldset>

        <fieldset class="" style="border: 1px solid #bfbebe; padding: 5px 20px 5px 20px; border-radius: 6px; overflow: auto">
            <legend style="width: auto; border: 0; font-size: 14px; margin: 0px 6px 0px 6px; padding: 0px 5px 0px 5px; color: darkslategray"><b>Records</b></legend>
            
                   <div class="w-100 border" style="overflow:auto;height:250px;">
                <cc1:DetailsContainer ID="WorkOrder_Exemption_Records" runat="server" AutoGenerateColumns="False"
                    AllowPaging="true" CellPadding="4" GridLines="None" Width="100%" DataMember="App_WorkOrder_Exemption"
                    OnRowDataBound="WorkOrder_Exemption_Record_RowDataBound"
                    DataKeyNames="ID" DataSource="<%# PageRecordsDataSet %>"
                    ForeColor="#333333" ShowHeaderWhenEmpty="True" OnPageIndexChanging="WorkOrder_Exemption_Records_PageIndexChanging"
                    OnSelectedIndexChanged="WorkOrder_Exemption_Records_SelectedIndexChanged" PageSize="10" PagerSettings-Visible="True" PagerStyle-HorizontalAlign="Center"
                    PagerStyle-Wrap="False" HeaderStyle-Font-Size="Smaller" RowStyle-Font-Size="Smaller" OnPreRender="WorkOrder_Exemption_Records_PreRender">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:TemplateField HeaderText="ID" SortExpression="ID" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="ID" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Sl No." SortExpression="Sl_No"
                            HeaderStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate><%# Container.DataItemIndex + 1 + "."%> </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="Created On" SortExpression="CreatedOn">
                            <ItemTemplate>
                                <asp:Label ID="CreatedOn" runat="server"></asp:Label>&nbsp
                            </ItemTemplate>
                        </asp:TemplateField>



                        <asp:TemplateField HeaderText="Vendor Code" SortExpression="VendorCode">
                            <ItemTemplate>
                                <asp:Label ID="VendorCode" runat="server"></asp:Label>&nbsp
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="Vendor Name" SortExpression="VendorName">
                            <ItemTemplate>
                                <asp:Label ID="VendorName" runat="server"></asp:Label>&nbsp
                            </ItemTemplate>
                        </asp:TemplateField>



                          <asp:TemplateField HeaderText="WorkOrder No." 
                               SortExpression="WorkOrderNo">
                               <ItemTemplate>
                               <B> <asp:LinkButton ID="LinkButton1"  runat="server"  CommandName="select" ForeColor="#003399" Text='<%# Bind("WorkOrderNo") %>' ></asp:LinkButton> </B>
                               </ItemTemplate>
                               <HeaderStyle HorizontalAlign="Left" />
                           </asp:TemplateField>

                        <asp:TemplateField HeaderText="Status" SortExpression="Status">
                            <ItemTemplate>
                                <asp:Label ID="Status" runat="server"></asp:Label>&nbsp
                            </ItemTemplate>
                        </asp:TemplateField>



                          <asp:TemplateField HeaderText="Return Attachment" SortExpression="ReturnAttachment" >
                                            <ItemTemplate>
                                                <asp:BulletedList runat="server" ID="ReturnAttachment" CssClass="attachment-list" DisplayMode="HyperLink" OnClick="ReturnAttachment_Click" />
                                            </ItemTemplate>
                                        </asp:TemplateField> 





                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerSettings Mode="Numeric" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" Font-Bold="True" CssClass="pager1" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="False" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </cc1:DetailsContainer>

            </div>
        </fieldset>


        <%--formcontainer--%>



             <div id="DivInputFields" runat="server" visible="true">
                  <fieldset class="" style="border:1px solid #bfbebe;padding:5px 20px 5px 20px;border-radius:6px">
                    <legend style="width:auto;border:0;font-size:14px;margin:0px 6px 0px 6px;padding:0px 5px 0px 5px;color:#0000FF"><b>Record</b></legend>
                       
                       <cc1:formcointainer ID="WorkOrder_Exemption_Record" runat="server" AllowPaging="True" AutoGenerateColumns="False" OnNewRowCreatingEvent="WorkOrder_Exemption_Record_NewRowCreatingEvent"
                           PageSize="1" ShowHeader="False" Width="100%" DataSource="<%# PageRecordDataSet %>" 
                          DataMember="App_WorkOrder_Exemption" DataKeyNames="ID" 
                           BindingErrorMessage="aaaaaaaaa" GridLines="None"  OnPreRender="WorkOrder_Exemption_Record_PreRender" OnRowDataBound="WorkOrder_Exemption_Record_RowDataBound">
                           
                        <Columns>
                            <asp:TemplateField SortExpression="ID" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="ID" runat="server" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <ItemTemplate>
                                <%--OnRowDataBound="WorkOrder_Exemption_Record_RowDataBound"--%>
                       
                                  <div class="form-inline row">

                                       <div class="form-group col-md-6 mb-1">
                                        <label for="VendorCode" class="m-0 mr-2 p-0 col-form-label-sm col-sm-5 font-weight-bold fs-6 justify-content-start">Vendor Code:<span style="color: #FF0000;">*</span></label>
                                        <asp:TextBox ID="VendorCode" runat="server" CssClass="form-control form-control-sm col-sm-6"  Enabled="false" ></asp:TextBox>
                                        <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="Validate" ValidationGroup="Save" ControlToValidate="VendorCode" ValidateEmptyText="true"></asp:CustomValidator>

                                     </div>

                                      <div class="form-group col-md-6 mb-1">
                                        <label for="VendorName" class="m-0 mr-2 p-0 col-form-label-sm col-sm-5 font-weight-bold fs-6 justify-content-start">Vendor Name:<span style="color: #FF0000;">*</span></label>
                                        <asp:TextBox ID="VendorName" runat="server" CssClass="form-control form-control-sm col-sm-6" Enabled="false"></asp:TextBox>
                                        <asp:CustomValidator ID="CustomValidator2" runat="server" ClientValidationFunction="Validate" ValidationGroup="Save" ControlToValidate="VendorName" ValidateEmptyText="true"></asp:CustomValidator>

                                     </div>
                                       </div>










                                    <div class="form-inline row">

                                        

                                       <%--<div class="form-group col-md-6 mb-1">
                                        <label for="WorkOrderNo" class="m-0 mr-2 p-0 col-form-label-sm col-sm-5 font-weight-bold fs-6 justify-content-start">WorkOrder No.:
                                            <span style="color: #FF0000;">*</span></label>
                                        <asp:DropDownList ID="WorkOrderNo" runat="server" CssClass="form-control form-control-sm col-sm-6" DataMember="Exp_Wo_No" 
                                            DataSource="<%# PageDDLDataset %>" DataTextField="Workorder" DataValueField="WO_NO" SelectionMode="Multiple" >
                                            </asp:DropDownList>

                                     </div>--%>

                                      
                              <div class="form-group col-md-6 mb-2">
                                       <label for="lblWorkOrderNo" class="m-0 mr-2 p-0 col-form-label-sm col-sm-5  font-weight-bold fs-6 justify-content-start">WorkOrder No.:
                                           <span style="color: #FF0000;">*</span></label>
                                           <div class="form-group col-md-6 mb-2" style="margin-left:-14px">
                                            <div>
                                          <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <div class="SearchCheckBoxList" style="width:287%;">
                                                          <button class="btn btn-sm btn-default selectArea w-100" type="button"  onclick="togglefloatDiv(this);" 
                                                              id="btn-dwn1" style="border:0.5px solid #ced2d5;">
                                                      <span  class="filter-option float-left">No item Selected</span>
                                                            <span class="caret" ></span>
                                                          </button>
                                                          <div class="floatDiv" runat="server"  style="border:1px solid #ced2d5;position:absolute;z-index:1000;
                                                            box-shadow:0 6px 12px rgb(0 0 0 / 18%);background-color:white;padding:5px;display:none;width:100%;">
                                                           <asp:TextBox runat="server" ID="TextBox1" CssClass="form-control form-control-sm col-sm-12" 
                                                               oninput="filterCheckBox(this)" AutoComplete="off" ViewStateMode="Disabled" placeholder="Enter Workorder" Font-Size="Smaller" />
                                                    <div  style="overflow:auto;max-height:210px;overflow-y:auto;overflow-x:hidden"; class="searchList p-0" >
                                                                  <asp:CheckBoxList ID="WorkOrderNo" runat="server" DataMember="Exp_Wo_No" DataSource="<%# PageDDLDataset %>"
                                                                       DataTextField="Workorder"
                                                                     DataValueField="WO_NO"  CssClass="form-control-sm radio" >
                                             </asp:CheckBoxList>

                                                           </div>
                                                              <asp:TextBox runat="server" ID="TextBox3"  Width="0%" style="display:none" />
                                            </div>
                                                      </div>
                                                </ContentTemplate>
                                               </asp:UpdatePanel>
                                             </div>
                                          </div>
                              </div>

                                         







                                      <div class="form-group col-md-6 mb-1">
                                        <label for="Exemption_Vendor" class="m-0 mr-2 p-0 col-form-label-sm col-sm-5 font-weight-bold fs-6 justify-content-start">No. Of Exemption Days:<span style="color: #FF0000;">*</span></label>
                                      
                                          <asp:TextBox ID="Exemption_Vendor" runat="server" CssClass="form-control form-control-sm col-sm-6" TextMode="Number"></asp:TextBox>
                                        <asp:CustomValidator ID="CustomValidator4" runat="server" ClientValidationFunction="Validate" ValidationGroup="Save" ControlToValidate="Exemption_Vendor" ValidateEmptyText="true"></asp:CustomValidator>
                                          <asp:RegularExpressionValidator ID="RegValue" runat="server" ControlToValidate="Exemption_Vendor" ValidationExpression="^\d+$" ErrorMessage="Please enter a positive integer value." ValidationGroup="Save" ForeColor="Red" Font-Size="Medium" ></asp:RegularExpressionValidator>
                                     </div>


                                     <div class="form-group col-md-12 mb-1">
                                        <label class="m-0 mr-5 p-0 col-form-label-sm col-sm-2  font-weight-bold fs-6 justify-content-start">
                                            Compliance Type: <span style="color:#FF0000;">*</span>
                                        </label>

                                      
                                        <asp:CheckBox ID="Wage"     CssClass="mr-2 compliance-check item-check" runat="server" />
                                        <label class="form-check-label mr-3" for="Wage">Wage</label>

                                        <asp:CheckBox ID="PfEsi"    CssClass="mr-2 compliance-check item-check" runat="server" />
                                        <label class="form-check-label mr-3" for="PfEsi">PF &amp; ESI</label>

                                        <asp:CheckBox ID="Leave"    CssClass="mr-2 compliance-check item-check" runat="server" />
                                        <label class="form-check-label mr-3" for="Leave">Leave</label>

                                        <asp:CheckBox ID="Bonus"    CssClass="mr-2 compliance-check item-check" runat="server" />
                                        <label class="form-check-label mr-3" for="Bonus">Bonus</label>

                                        <asp:CheckBox ID="LL"       CssClass="mr-2 compliance-check item-check" runat="server" />
                                        <label class="form-check-label mr-3" for="LL">Labour License</label>

                                        <asp:CheckBox ID="Grievance" CssClass="mr-2 compliance-check item-check" runat="server" />
                                        <label class="form-check-label mr-3" for="Grievance">Grievance</label>

                                        <asp:CheckBox ID="Notice"   CssClass="mr-2 compliance-check item-check" runat="server" />
                                        <label class="form-check-label mr-3" for="Notice">Notice</label>

                                        <asp:CheckBox ID="All" CssClass="mr-2 compliance-check select-all" runat="server" />
                                        <label class="form-check-label mr-3" for="All">All</label>
                                   


                                     </div>

                                        </div>


                                        



                                       </div>

                



                                           

                                        








                                      <div class="form-inline row">
                                        <div class="form-group col-md-8 mb-3">
                                        <label for="Remarks" class="m-0 mr-2 p-0 col-form-label-sm col-sm-5 font-weight-bold fs-6 justify-content-start">Remarks:<span style="color: #FF0000;">*</span></label>
                                         <asp:TextBox ID="Remarks" runat="server" CssClass="form-control form-control-sm col-sm-10" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                        <asp:CustomValidator ID="CustomValidator3" runat="server" ClientValidationFunction="Validate" ValidationGroup="Save" ControlToValidate="Remarks" ValidateEmptyText="true"></asp:CustomValidator>

                                        </div> 
                                     </div>

                                     <div class="form-inline row">
                                          <div class="form-group col-md-6 mb-2">
                                                <label for="lbl_Attachment" class="m-0 mr-2 p-0 col-form-label-sm col-sm-3 font-weight-bold fs-6 justify-content-start" >Attachment:</label>
                                                    <asp:FileUpload ID="Attachment" runat="server" AllowMultiple="true" Font-Size="Small"/>
                                                    <asp:BulletedList ID="Bull_Attach" runat="server" CssClass="font-smaller text-primary attachment-list" DisplayMode="HyperLink" Target="_blank"/>
                                                                     
                                           
                                              </div>

                                 

                                        </div>
                               

                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                        <PagerSettings Visible="False" />
                    </cc1:formcointainer>
                       
                  </fieldset>

                 <%--Remarks--%>

                   <div id="div_Remarks" runat="server">
                  <fieldset class="" style="border:1px solid #bfbebe;padding:5px 20px 5px 20px;border-radius:6px">
                    <legend style="width:auto;border:0;font-size:14px;margin:0px 6px 0px 6px;padding:0px 5px 0px 5px;color:#0000FF"><b>Remarks History</b></legend>
       
                      <asp:GridView ID="Remarks_grid" runat="server" AutoGenerateColumns="false"
                          AllowPaging="false" CellPadding="0" GridLines="Both" Width="100%" 
                                    ForeColor="#333333" ShowHeaderWhenEmpty="False" OnRowDataBound="Remarks_grid_RowDataBound"
                                    PageSize="10" PagerSettings-Visible="false" PagerStyle-HorizontalAlign="Center" 
                                    PagerStyle-Wrap="True" HeaderStyle-Font-Size="Smaller" RowStyle-Font-Size="Small" CssClass="m-auto border border-info" 
                                    HeaderStyle-HorizontalAlign="Center"  RowStyle-ForeColor="Black" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"> 
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                              <Columns> 
                                    <asp:TemplateField  Visible="False">
                                            <ItemTemplate >
                                                <asp:Label ID="ID" runat="server"></asp:Label>
                                                
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    <asp:BoundField DataField="Remarks" HeaderText="Remarks" ItemStyle-Width="30" />    
                     
                              </Columns>
                                    <EditRowStyle BackColor="#999999" />
                                    <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                                    <HeaderStyle BackColor="#328cda" Font-Bold="True" ForeColor="White" />
                                    <PagerSettings Mode="Numeric" />
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" Font-Bold="True"  CssClass="pager1" />
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="False" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                       </asp:GridView>

      
                    </fieldset>
     </div>

                   <div class="row m-0 justify-content-center mt-2">
                        <asp:Button ID="btnSave" runat="server" Text="Submit" CssClass="btn btn-sm btn-info" ValidationGroup="Save" OnClick="btnSave_Click" OnClientClick="return Page_ClientValidate('Save') && validateCompliance();" />
                      </div>

                      </div> 



    </div>
       <asp:Literal ID="Literal1" runat="server">

             <script type="text/javascript" src="../../Scripts/DynamicDropdown.js" ></script> 
        </asp:Literal>
</asp:Content>



--------------------------------------------------


using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Data.OleDb;
using System.Text;
using System.IO;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Configuration;
using System.Web.UI.HtmlControls;
namespace CLMS.App.Input
{
    public partial class WorkOrder_Exemption :Classes.basePage
    {
        App_WorkOrder_Exemption_Ds dsRecords = new App_WorkOrder_Exemption_Ds();
        App_WorkOrder_Exemption_Ds dsRecord = new App_WorkOrder_Exemption_Ds();

        DataSet dsDDL = new DataSet();



        protected override void SetBaseControls()
        {
            base.SetBaseControls();

            PageRecordsDataSet = dsRecords;
            PageRecordDataSet = dsRecord;
            PageDDLDataset = dsDDL;
            BLObject = new BL_WorkOrder_Exemption();
        }

        private StringDictionary GetFilterCondition()
        {
            StringDictionary d = null;
            d = new StringDictionary();
            d.Add("VendorCode", Session["UserName"].ToString());
            if (txt_WorkOrderNo.Text != "")
            {
                d.Add("WorkOrderNo", txt_WorkOrderNo.Text);
            }
            return d;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            WorkOrder_Exemption_Records.DataSource = PageRecordsDataSet;
            WorkOrder_Exemption_Record.DataSource = PageRecordDataSet;

            if (!IsPostBack)
            {

                GetRecords(GetFilterCondition(), WorkOrder_Exemption_Records.PageSize, 10, "");
                WorkOrder_Exemption_Records.BindData();
                DivInputFields.Visible = false;
                WorkOrder_Exemption_Record.NewRecord();
                WorkOrder_Exemption_Record.BindData();
                Dictionary<string, object> ddlParams = new Dictionary<string, object>();
                ddlParams.Add("V_Code", Session["UserName"].ToString());
                GetDropdowns("Exp_Wo_No", ddlParams);
                
               
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            PageRecordDataSet.Clear();
            GetRecords(GetFilterCondition(), WorkOrder_Exemption_Records.PageSize, 10, "");
            WorkOrder_Exemption_Records.SelectedIndex = -1;
            WorkOrder_Exemption_Records.BindData();
            PageRecordDataSet.Tables[WorkOrder_Exemption_Record.DataMember].Rows.Clear();
            WorkOrder_Exemption_Record.BindData();
        }

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
            btnSave.Enabled = true;


            BL_WorkOrder_Exemption blobj = new BL_WorkOrder_Exemption();
            DataSet ds = new DataSet();
            ds = blobj.Getvendor_Name(Session["UserName"].ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                PageRecordDataSet.Tables["App_WorkOrder_Exemption"].Rows[0]["VendorCode"] = Session["UserName"].ToString();
                PageRecordDataSet.Tables["App_WorkOrder_Exemption"].Rows[0]["VendorName"] = ds.Tables["App_VendorMaster"].Rows[0]["V_NAME"].ToString();
            }

           
        }

        protected void WorkOrder_Exemption_Records_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            WorkOrder_Exemption_Records.PageIndex = e.NewPageIndex;
            GetRecords(GetFilterCondition(), WorkOrder_Exemption_Records.PageSize, WorkOrder_Exemption_Records.PageIndex, "");
            WorkOrder_Exemption_Records.SelectedIndex = -1;
            WorkOrder_Exemption_Records.BindData();
            PageRecordDataSet.Tables[WorkOrder_Exemption_Records.DataMember].Rows.Clear();
            WorkOrder_Exemption_Records.BindData();
        }

        protected void WorkOrder_Exemption_Records_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetRecord(WorkOrder_Exemption_Records.SelectedDataKey.Value.ToString());
            WorkOrder_Exemption_Records.SelectedIndex = -1;
            WorkOrder_Exemption_Record.BindData();
            DivInputFields.Visible = true;
            btnSave.Visible = true;
            


        }

        protected void WorkOrder_Exemption_Record_NewRowCreatingEvent(System.Data.DataRow oRow, ref bool cancel)
        {
            oRow["ID"] = Guid.NewGuid();
            oRow["CreatedBy"] = Session["UserName"].ToString();
            oRow["CreatedOn"] = System.DateTime.Now;

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        
            PageRecordDataSet.Tables["App_WorkOrder_Exemption"].Rows[0]["Wage"] = 0;
            PageRecordDataSet.Tables["App_WorkOrder_Exemption"].Rows[0]["PfEsi"] = 0;
            PageRecordDataSet.Tables["App_WorkOrder_Exemption"].Rows[0]["Leave"] = 0;
            PageRecordDataSet.Tables["App_WorkOrder_Exemption"].Rows[0]["Bonus"] = 0;
            PageRecordDataSet.Tables["App_WorkOrder_Exemption"].Rows[0]["LL"] = 0;
            PageRecordDataSet.Tables["App_WorkOrder_Exemption"].Rows[0]["Grievance"] = 0;
            PageRecordDataSet.Tables["App_WorkOrder_Exemption"].Rows[0]["Notice"] = 0;

        
            if (((CheckBox)WorkOrder_Exemption_Record.Rows[0].FindControl("Wage")).Checked)
                PageRecordDataSet.Tables["App_WorkOrder_Exemption"].Rows[0]["Wage"] = 1;

            if (((CheckBox)WorkOrder_Exemption_Record.Rows[0].FindControl("PfEsi")).Checked)
                PageRecordDataSet.Tables["App_WorkOrder_Exemption"].Rows[0]["PfEsi"] = 1;

            if (((CheckBox)WorkOrder_Exemption_Record.Rows[0].FindControl("Leave")).Checked)
                PageRecordDataSet.Tables["App_WorkOrder_Exemption"].Rows[0]["Leave"] = 1;

            if (((CheckBox)WorkOrder_Exemption_Record.Rows[0].FindControl("Bonus")).Checked)
                PageRecordDataSet.Tables["App_WorkOrder_Exemption"].Rows[0]["Bonus"] = 1;

            if (((CheckBox)WorkOrder_Exemption_Record.Rows[0].FindControl("LL")).Checked)
                PageRecordDataSet.Tables["App_WorkOrder_Exemption"].Rows[0]["LL"] = 1;

            if (((CheckBox)WorkOrder_Exemption_Record.Rows[0].FindControl("Grievance")).Checked)
                PageRecordDataSet.Tables["App_WorkOrder_Exemption"].Rows[0]["Grievance"] = 1;

            if (((CheckBox)WorkOrder_Exemption_Record.Rows[0].FindControl("Notice")).Checked)
                PageRecordDataSet.Tables["App_WorkOrder_Exemption"].Rows[0]["Notice"] = 1;






            string selectedWorkorder = string.Join(",", ((CheckBoxList)WorkOrder_Exemption_Record.Rows[0].FindControl("WorkOrderNo")).Items.
            Cast<ListItem>().Where(li => li.Selected).Select(li => li.Value));

            //PageRecordDataSet.Tables["App_WorkOrder_Exemption"].Rows[0]["WorkOrderNo"] = selectedWorkorder;


            string strRemarks = PageRecordDataSet.Tables["App_WorkOrder_Exemption"].Rows[0]["Remarks"].ToString();
            WorkOrder_Exemption_Record.UnbindData();
            BL_WorkOrder_Exemption blobj = new BL_WorkOrder_Exemption();

            string Workordercomma = PageRecordDataSet.Tables["App_WorkOrder_Exemption"].Rows[0]["WorkOrderNo"].ToString();
            string WorkOrderTrim = Workordercomma.TrimEnd(',');
            PageRecordDataSet.Tables["App_WorkOrder_Exemption"].Rows[0]["WorkOrderNo"] = WorkOrderTrim;



            string getFileName = "";
            List<string> FileList = new List<string>();
            if (((FileUpload)WorkOrder_Exemption_Record.Rows[0].FindControl("Attachment")).HasFile)
            {
                foreach (HttpPostedFile htfiles in ((FileUpload)WorkOrder_Exemption_Record.Rows[0].FindControl("Attachment")).PostedFiles)
                {
                    getFileName = PageRecordDataSet.Tables["App_WorkOrder_Exemption"].Rows[0]["ID"].ToString() + "_" + Path.GetFileName(htfiles.FileName);
                    getFileName = Regex.Replace(getFileName, @"[,+*/?|><&=\#%:;@[^$?:'()!~}{`]", "");
                    htfiles.SaveAs((@"D:/Cybersoft_Doc/CLMS/Attachments/" + getFileName));
                    FileList.Add(getFileName);
                }
                PageRecordDataSet.Tables["App_WorkOrder_Exemption"].Rows[0]["Attachment"] = string.Join(",", FileList);
            }






              PageRecordDataSet.Tables["App_WorkOrder_Exemption"].Rows[0]["Status"] = "Pending With CC";

            if (PageRecordDataSet.Tables["App_WorkOrder_Exemption"].Rows[0].RowState.ToString() == "Modified")
            {
                PageRecordDataSet.Tables["App_WorkOrder_Exemption"].Rows[0]["ResubmittedOn"] = System.DateTime.Now;
                PageRecordDataSet.Tables["App_WorkOrder_Exemption"].Rows[0]["ResubmittedBy"] = Session["UserName"].ToString();
            }

            if (PageRecordDataSet.Tables["App_WorkOrder_Exemption"].Rows[0]["Remarks"].ToString() == "")
            {
                PageRecordDataSet.Tables["App_WorkOrder_Exemption"].Rows[0]["Remarks"] = strRemarks + "( VENDOR --" + System.DateTime.Now.ToString("dd/MM/yyyy")
                    + " -- " + ((TextBox)WorkOrder_Exemption_Record.Rows[0].FindControl("Remarks")).Text + ")|";
            }
            else
            {
                PageRecordDataSet.Tables["App_WorkOrder_Exemption"].Rows[0]["Remarks"] = strRemarks + "( VENDOR --" + System.DateTime.Now.ToString("dd/MM/yyyy")
                    + " -- " + ((TextBox)WorkOrder_Exemption_Record.Rows[0].FindControl("Remarks")).Text + ")|";
            }


            //validation for checkboxlist
            int count = 0;
                foreach (ListItem lstitem in ((CheckBoxList)WorkOrder_Exemption_Record.Rows[0].FindControl("WorkOrderNo")).Items)
                {
                if (lstitem.Selected == true)
                    count++;
                }
                if (count==0)
                {
                
                MyMsgBox.show(CLMS.Control.MyMsgBox.MessageType.Errors, "Please Select atleast one workorder no. !!");
                return;
                }


            //validation - Approved work orders should not be repeated within the exempted period defined by the CC team

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
                        $"The following work orders are already approved and still within the exemption period: {joined}. Duplicate not allowed!");
                    return;
                }
            }








            bool result = Save();

            if (result)
            {

                string v_code = Session["UserName"].ToString();
                string v_name = "";
                string wo_no = PageRecordDataSet.Tables["App_WorkOrder_Exemption"].Rows[0]["WorkOrderNo"].ToString();
                string subject = "";
                string msg = "";
                string cc = "";
                DataSet ds = new DataSet();
                DataSet ds1 = new DataSet();
                BL_Send_Mail blobj1 = new BL_Send_Mail();
                ds = blobj1.Get_Vendor_mail(Session["UserName"].ToString());
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    cc = ds.Tables["aspnet_Membership"].Rows[0]["Email"].ToString();
                }

                ds1 = blobj1.Get_Vendor_name(v_code);
                if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
                {
                    v_name = ds1.Tables["App_vendor_reg"].Rows[0]["v_name"].ToString();
                }



                subject = "Application for WorkOrder Exemption has been submitted or updated by M/S  " + v_name + " (Vendor Code – " + v_code + " ) ";
                msg = "<html><body><P><B>" 
                              + "To<BR /> "
                              + "Contractor Cell <BR/>"
                              + "<BR />Dear Sir/Madam"
                              + "<BR /> "

                              + "M/s " + v_name + " (" + v_code + ") has submitted Work Order Registration application against Work Order " + wo_no + ", request you to please do the needful as soon as possible.<BR/>"

                              + "<BR />Link :- https://services.tsuisl.co.in/CLMS "
                              + " <BR /> " + " <BR /> Thanks & Regards " + " <BR /> "
                              + " <BR /> TATA STEEL UISL Contractor's Cell </B></P></html></body>"
                              + " <BR /> "
                              + " <BR /> Note: Please do not reply as it is a system generated mail. ";


                blobj1.sendmail_request("", cc, subject, msg, "");





















                PageRecordDataSet.Clear();
                WorkOrder_Exemption_Record.BindData();
                GetRecords(GetFilterCondition(), WorkOrder_Exemption_Records.PageSize, 10, "");
                WorkOrder_Exemption_Records.BindData();

                MyMsgBox.show(CLMS.Control.MyMsgBox.MessageType.Success, "Record saved successfully !");
                btnSave.Visible = false;
                DivInputFields.Visible = false;

            }
            else
            {
                MyMsgBox.show(CLMS.Control.MyMsgBox.MessageType.Errors, "Error While Saving !");
            }
        }

        protected void WorkOrder_Exemption_Record_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            //if (WorkOrder_Exemption_Record.Rows.Count > 0)
            //{
            //    ((BulletedList)WorkOrder_Exemption_Record.Rows[0].FindControl("Bull_Attach")).Items.Clear();
            //    string[] attachments;
            //    if (!string.IsNullOrEmpty(PageRecordDataSet.Tables["App_WorkOrder_Exemption"].Rows[0]["Attachment"].ToString()))
            //    {
            //        attachments = PageRecordDataSet.Tables["App_WorkOrder_Exemption"].Rows[0]["Attachment"].ToString().Split(',');

            //        foreach (string image in attachments)
            //        {
            //            ListItem link = new ListItem();
            //            //link.Value = "~/Attachments/" + image;
            //            link.Value = "~/FileDownloadHandler.ashx?file=" + Server.UrlEncode(image);
            //            link.Text = image;
            //            link.Attributes.CssStyle.Add("text-decoration", "underline");
            //            link.Attributes.CssStyle.Add("color", "blue");
            //            link.Text = image.Substring(37);
            //            ((BulletedList)WorkOrder_Exemption_Record.Rows[0].FindControl("Bull_Attach")).Items.Add(link);
            //        }
            //    }

            //}



            if (string.Equals(e.Row.RowType.ToString(), "DATAROW", StringComparison.CurrentCultureIgnoreCase))
            {
                DataRow oRow = ((DataRowView)e.Row.DataItem).Row;

                System.Web.UI.Control Attachment = e.Row.FindControl("ReturnAttachment");

               if(Attachment!= null)
               {
                    string[] attachments;
                    if (!string.IsNullOrEmpty(oRow["ReturnAttachment"].ToString()))
                    {
                        attachments = oRow["ReturnAttachment"].ToString().Split(',');


                        foreach (string image in attachments)
                        {
                            ListItem link = new ListItem();
                            //link.Value = "~/Attachments/" + image;
                            link.Value = "~/FileDownloadHandler.ashx?file=" + Server.UrlEncode(image);
                            link.Text = image.Substring(37);
                            link.Attributes.CssStyle.Add("text-decoration", "underline");
                            link.Attributes.CssStyle.Add("color", "blue");

                            ((BulletedList)Attachment).Items.Add(link);
                        }
                    }
                }

                else
                {

                }
                
                   
                
            }






        }




        protected void ReturnAttachment_Click(object sender, BulletedListEventArgs e)
        {
            string filePath = (sender as LinkButton).CommandArgument;
            if (filePath != "")
            {
                Response.ContentType = ContentType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
                Response.TransmitFile(@"D:/Cybersoft_Doc/CLMS/Attachments/" + filePath);
                Response.End();
            }
            else
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('There is no file to Download');", true);
        }





        protected void Remarks_grid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if ((e.Row.Cells[1].Text.StartsWith("( VENDOR --")) || (e.Row.Cells[1].Text.StartsWith("\n( VENDOR --")))
            {
                e.Row.Attributes.CssStyle.Value = "color: Blue;Font-weight:bold";
            }

            if ((e.Row.Cells[1].Text.StartsWith("( CC --")) || (e.Row.Cells[1].Text.StartsWith("\n( CC --")))
            {
                e.Row.Attributes.CssStyle.Value = "color: DarkRed;Font-weight:bold";
            }
            if ((e.Row.Cells[1].Text.StartsWith("( CC --")) || (e.Row.Cells[1].Text.StartsWith("\n( CC --")))
            {
                e.Row.Attributes.CssStyle.Value = "color: DarkRed;Font-weight:bold";
            }
        }

        protected void WorkOrder_Exemption_Record_PreRender(object sender, EventArgs e)
        {
            BL_WorkOrder_Exemption blobjs = new BL_WorkOrder_Exemption();
            DataSet ds = new DataSet();
            if (WorkOrder_Exemption_Record.Rows.Count > 0)
            {

          


                if (PageRecordDataSet.Tables["App_WorkOrder_Exemption"].Rows.Count > 0)
                {
                    ds = blobjs.BindRemarks(PageRecordDataSet.Tables["App_WorkOrder_Exemption"].Rows[0]["ID"].ToString());
                    Remarks_grid.DataSource = ds;
                    Remarks_grid.DataBind();
                    
                }



            }
            if (PageRecordDataSet.Tables["App_WorkOrder_Exemption"].Rows[0]["WorkOrderNo"].ToString() != "") 
            {


                if (PageRecordDataSet.Tables["App_WorkOrder_Exemption"].Rows[0]["Status"].ToString() == "Pending With CC" ||
                   PageRecordDataSet.Tables["App_WorkOrder_Exemption"].Rows[0]["Status"].ToString() == "Approved")
                {
                    ((CheckBoxList)WorkOrder_Exemption_Record.Rows[0].FindControl("WorkOrderNo")).Enabled = false;
                    ((TextBox)WorkOrder_Exemption_Record.Rows[0].FindControl("Exemption_Vendor")).Enabled = false;
                    ((FileUpload)WorkOrder_Exemption_Record.Rows[0].FindControl("Attachment")).Enabled = false;
                    ((TextBox)WorkOrder_Exemption_Record.Rows[0].FindControl("Remarks")).Enabled = false;
                    btnSave.Enabled = false;
                }



                else
                {
                    WorkOrder_Exemption_Record.Enabled = true;
                    btnSave.Enabled = true;
                    ((TextBox)WorkOrder_Exemption_Record.Rows[0].FindControl("Remarks")).Text = "";
                    ((FileUpload)WorkOrder_Exemption_Record.Rows[0].FindControl("Attachment")).Enabled = true;
                }









            }




        }

        protected void WorkOrder_Exemption_Records_PreRender(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "getClickedElement();", true);
        }

       
        


        //protected void AttachDownload_ServerClick(object sender, EventArgs e)
        //{
        //    string filename = PageRecordDataSet.Tables["App_WorkOrder_Exemption"].Rows[0]["Attachment"].ToString();
        //    // string filepath = Server.MapPath("~/Attachments/") + filename;

        //    if (!string.IsNullOrEmpty(filename))
        //    {
        //        string filepath = Server.MapPath("~/Attachments/" + filename);
        //        if (File.Exists(filepath))
        //        {
        //            Response.Clear();

        //            Response.ContentType = MimeMapping.GetMimeMapping(filename);
        //            Response.AppendHeader("Content-Disposition", "attachment; filename=\"" + Path.GetFileName(filename) + "\"");
        //            Response.TransmitFile(filepath);
        //            Response.Flush();
        //            Response.End();
        //        }
        //        else
        //        {
        //            //Response.Write("File not found.");
        //            MyMsgBox.show(CLMS.Control.MyMsgBox.MessageType.Success, "File not found.");
        //        }
        //    }
        //    else
        //    {
        //        MyMsgBox.show(CLMS.Control.MyMsgBox.MessageType.Errors, "File not found.");
        //    }
        //}
    }
}


------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BusinessData;

namespace BusinessLayer
{
    public class BL_WorkOrder_Exemption:IBLDataProvider
    {
        public DataSet GetRecords(System.Collections.Specialized.StringDictionary FilterConditions, int totalPagesize, string sortExpression)
        {

            string strSQL = " select * from App_WorkOrder_Exemption where Status in ('Pending With CC','Return','Approved') ";
            DataHelper dh = new DataHelper();
            Dictionary<string, object> objParam = null;
            if (FilterConditions != null && FilterConditions.Count > 0)
            {
                strSQL += " and ";
                objParam = new Dictionary<string, object>();
                int cnt = FilterConditions.Count;
                foreach (string dickey in FilterConditions.Keys)
                {
                    objParam.Add(dickey,"%" + FilterConditions[dickey] + '%');
                    if (cnt > 0 && cnt != FilterConditions.Count)
                        strSQL += " and " + dickey + " like @" + dickey ;
                    else
                        strSQL += dickey + " like @" + dickey;
                    cnt--;
                }
            }
            strSQL += " order by CreatedOn desc";
            return dh.GetDataset(strSQL, "App_WorkOrder_Exemption", objParam);

        }

        public DataSet GetDropdowns(string DropdownNames, Dictionary<string, object> ddlParam)
        {
            return DropDownHelper.GetDropDownsDataset(DropdownNames, ddlParam, true);
        }

        DataSet IBLDataProvider.GetRecord(string recordId)
        {
            string strSQL = " select * from App_WorkOrder_Exemption where ID=@ID ";
            Dictionary<string, object> objParam = new Dictionary<string, object>();
            objParam.Add("ID", recordId);
            DataHelper dh = new DataHelper();
            DataSet ds = new DataSet();
            ds = dh.GetDataset(strSQL, "App_WorkOrder_Exemption", objParam);


            return ds;

            //throw new NotImplementedException();
        }

        public bool SaveRecord(ref DataSet recordDataset)
        {
            DataHelper dh = new DataHelper();
            bool result = dh.SaveData(recordDataset);
            return result;
        }

        public DataSet Getvendor_Name(string V_CODE)
        {
            string StrSQL = " SELECT V_NAME FROM App_VendorMaster WHERE V_CODE='" + V_CODE + "' ";

            Dictionary<string, object> objParam = null;

            DataHelper dh = new DataHelper();
            return dh.GetDataset(StrSQL, "App_VendorMaster", objParam);
        }

        public DataSet BindRemarks(string ID)
        {
            string StrSQL = "SELECT ID,value As Remarks FROM App_WorkOrder_Exemption CROSS APPLY STRING_SPLIT(Remarks, '|') where ID='" + ID + "'";
            Dictionary<string, object> objParam = new Dictionary<string, object>();
            DataHelper dh = new DataHelper();
            return dh.GetDataset(StrSQL, "App_WorkOrder_Exemption", objParam);
        }







        //public List<string> GetWorkOrdersInExemptionPeriod(string workOrders)
        //{
        //    string sql = @"SELECT w.WorkOrderNo FROM App_WorkOrder_Exemption AS w INNER JOIN STRING_SPLIT(@workOrders, ',') AS s ON LTRIM(RTRIM(s.value)) = w.WorkOrderNo WHERE w.Status = 'Approved' AND DATEDIFF(DAY, w.Approved_On, GETDATE()) <= w.Exemption_CC;";

        //    Dictionary<string, object> objParam = new Dictionary<string, object>();
        //    objParam.Add("workOrders", workOrders);  

        //    DataHelper dh = new DataHelper();
        //    DataSet ds = dh.GetDataset(sql, "App_WorkOrder_Exemption", objParam);

        //    return ds.Tables[0]
        //             .AsEnumerable()
        //             .Select(r => r.Field<string>("WorkOrderNo"))
        //             .ToList();
        //}



        public List<string> GetWorkOrdersInExemptionPeriod(string workOrder)
        {
         
            string sql = @"SELECT w.WorkOrderNo FROM App_WorkOrder_Exemption AS w WHERE w.Status = 'Approved' AND DATEDIFF(DAY, w.Approved_On, GETDATE()) <= w.Exemption_CC AND
         (
          w.WorkOrderNo = @workOrder
             OR w.WorkOrderNo LIKE @workOrder + ',%'
             OR w.WorkOrderNo LIKE '%,' + @workOrder + ',%'
             OR w.WorkOrderNo LIKE '%,' + @workOrder
          );";

            Dictionary<string, object> objParam = new Dictionary<string, object>();
            objParam.Add("workOrder", workOrder);  

            DataHelper dh = new DataHelper();
            DataSet ds = dh.GetDataset(sql, "App_WorkOrder_Exemption", objParam);

        
            return ds.Tables[0]
                     .AsEnumerable()
                     .Select(r => r.Field<string>("WorkOrderNo"))
                     .ToList();
        }




    }
}
