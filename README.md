<asp:TemplateField HeaderText="Sl.No." SortExpression="Sl_No"
    HeaderStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
    <ItemTemplate>
        <asp:Label ID="lblSlNo" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
    </ItemTemplate>
</asp:TemplateField>
