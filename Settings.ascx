<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Settings.ascx.cs" Inherits="Gafware.Modules.Bugs.Settings" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!-- uncomment the code below to start using the DNN Form pattern to create and update settings -->
<%@ Register TagName="label" TagPrefix="dnn" Src="~/controls/labelcontrol.ascx" %>

<h2 id="dnnSitePanel-BasicSettings" class="dnnFormSectionHead"><a href="" class="dnnSectionExpanded"><%=LocalizeString("BasicSettings")%></a></h2>
<fieldset>
    <div class="dnnFormItem">
        <dnn:Label ID="lblBugs" runat="server" ResourceKey="lblBugs" ControlName="chkBugs" Suffix=":" /> 
        <asp:CheckBox ID="chkBugs" runat="server" ValidationGroup="Bugs" AutoPostBack="true" OnCheckedChanged="chkBugs_CheckedChanged" />
    </div>
    <div id="pnlBugs" runat="server">
        <div class="dnnFormItem">
            <dnn:Label ID="lblMinBugs" runat="server" ResourceKey="lblMinBugs" ControlName="txtMinBugs" Suffix=":" /> 
            <telerik:RadNumericTextBox ID="txtMinBugs" MaxValue="9999" MinValue="1" runat="server" CssClass="NormalTextBox" Width="50px" NumberFormat-DecimalDigits="0" Value="2" ValidationGroup="Bugs" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label ID="lblMaxBugs" runat="server" ResourceKey="lblMaxBugs" ControlName="txtMaxBugs" Suffix=":" /> 
            <telerik:RadNumericTextBox ID="txtMaxBugs" MaxValue="9999" MinValue="1" runat="server" CssClass="NormalTextBox" Width="50px" NumberFormat-DecimalDigits="0" Value="20" ValidationGroup="Bugs" />
        </div>
    </div>
    <div class="dnnFormItem">
        <dnn:label ID="lblSpiders" runat="server" ResourceKey="lblSpiders" ControlName="chkSpiders" Suffix=":" />
        <asp:CheckBox ID="chkSpiders" runat="server" ValidationGroup="Bugs" AutoPostBack="true" OnCheckedChanged="chkSpiders_CheckedChanged" />
    </div>
    <div id="pnlSpiders" runat="server">
        <div class="dnnFormItem">
            <dnn:Label ID="lblMinSpiders" runat="server" ResourceKey="lblMinSpiders" ControlName="txtMinSpiders" Suffix=":" /> 
            <telerik:RadNumericTextBox ID="txtMinSpiders" MaxValue="9999" MinValue="1" runat="server" CssClass="NormalTextBox" Width="50px" NumberFormat-DecimalDigits="0" Value="3" ValidationGroup="Bugs" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label ID="lblMaxSpiders" runat="server" ResourceKey="lblMaxSpiders" ControlName="txtMaxSpiders" Suffix=":" /> 
            <telerik:RadNumericTextBox ID="txtMaxSpiders" MaxValue="9999" MinValue="1" runat="server" CssClass="NormalTextBox" Width="50px" NumberFormat-DecimalDigits="0" Value="10" ValidationGroup="Bugs" />
        </div>
    </div>
    <div class="dnnFormItem">
        <dnn:Label ID="lblMouseOver" runat="server" ResourceKey="lblMouseOver" ControlName="lstMouseOver" Suffix=":" /> 
        <asp:DropDownList ID="lstMouseOver" runat="server" ValidationGroup="Bugs">
            <asp:ListItem Text="Nothing" Value="nothing" Selected="True" />
            <asp:ListItem Text="Fly" Value="fly" />
            <asp:ListItem Text="Flyoff (if the bug can fly)" Value="flyoff" />
            <asp:ListItem Text="Die" Value="die" />
            <asp:ListItem Text="Multiply" Value="multiply" />
            <asp:ListItem Text="Random" Value="random" />
        </asp:DropDownList>
    </div>
    <div class="dnnFormItem">
        <dnn:Label ID="lblModuleSettings" runat="server" ResourceKey="lblModuleSettings" ControlName="chkModuleSettings" Suffix=":" />
        <asp:Checkbox ID="chkModuleSettings" runat="server" CssClass="dnnLeft" ValidationGroup="Bugs" Checked="false" />
    </div>
</fieldset>
