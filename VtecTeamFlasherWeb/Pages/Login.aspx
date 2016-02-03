<%@ Page Title="Авторизация пользователя в системе" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="Login.aspx.cs" Inherits="VtecTeamFlasherWeb.Pages.Login" %>

<%@ Register TagPrefix="dx" Namespace="DevExpress.Web.ASPxPanel" Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.Web.ASPxEditors" Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.Web.ASPxFormLayout" Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.Web.ASPxPopupControl" Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.Web.ASPxCallbackPanel" Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.Web.ASPxHiddenField" Assembly="DevExpress.Web.v13.2, Version=13.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>

<%@ Register TagPrefix="dx" Namespace="WebAppCommons.Classes.Controls.ASPx.xSmartPopupControl" Assembly="WebAppCommons" %>


<asp:Content runat="server" ID="Head" ContentPlaceHolderID="HeadContent">
    
    <%
        Bundles.Reference("javascript-crypto-core-bundle", "head");
        Bundles.Reference("javascript-page-functions-bundle", "head");
    %>
    
    <script type="text/javascript">
        var XML = '';
        
        var isAappletStarted = false;
        var isHideMainLoadingPanelRequired = false;

        
        <%--function UseCSPAuthorization() {
            return <%= GetUseCSPAuthorization() %>;
        }--%>
        

        function RaiseLoginButtonClick(s, e) {
            return RaiseButtonClickOnEnter(e, 'aspxbtnLogin');
            
        }
        
        function RaiseContinueWithPinButtonClick(s, e) {
            return RaiseButtonClickOnEnter(e, 'aspxbtnContinueWithPin');
        }



        function ShowAuthorizationError(error) {
            $('#loginFormErrors').html(error);

            var item = MainFormLayout.GetItemByName('ItemErrorMessage');
                item.SetVisible(error.length > 0);
        }

        //function ShowPinError(error) {
        //    $("#pinFormErrors").html(error);
        //    $('#pinFormErrorsContainer').show();
        //}


        function HidePopUp() {
            aspxpcMainPopUp.Hide();
            
            if (isHideMainLoadingPanelRequired) {
                HideMainLoadingPanel();
            }

            var item = aspxflPopUpContent.GetItemByName('aspxliNotifyUser');
                item.SetVisible(false);

            item = aspxflPopUpContent.GetItemByName('aspxliFormPin');
            item.SetVisible(false);
        }


        function StartAuthorization() {
            isHideMainLoadingPanelRequired = false;

            var login = aspxtbLogin.GetValue();
            var password = aspxtbPassword.GetValue();

            if (login == null || password == null) {
                ShowAuthorizationError('<%: "Необходимо указать имя пользователя и пароль".Localize() %>');

                ASPxControlDefaults_SetFocus(login == null ? aspxtbLogin : aspxtbPassword);

                return;
            }

            ShowMainLoadingPanel();

            ShowAuthorizationError('');

            //if (UseCSPAuthorization()) {
            //    PrepareAuthorizationXML();
            //} else {
                SetMainLoadingPanelText('<%: "Подождите! Идет авторизация пользователя в системе".Localize() %>');

                aspxbtnAuthorize.DoClick();
           // }
        }



        function CancelAuthorization() {
            isHideMainLoadingPanelRequired = true;

            HidePopUp();

            ASPxControlDefaults_SetFocus(aspxbtnLogin);
        }


        
        function aspxbtnLogin_OnButtonClick(s, e) {
            StartAuthorization();
        }

        function aspxbtnContinue_OnButtonClick(s, e) {
            if (isAappletStarted) {
                SelectKeyContainer();
            } else {
                StartApplet();
            }
        }

        function aspxbtnContinueWithPin_OnButtonClick(s, e) {
            FinishCSPAuthorization();
        }

        function aspxpcMainPopUp_OnCloseUp(s, e) {
            HidePopUp();
        }
        
        function aspxpcMainPopUp_OnCloseButtonClick(s, e) {
            isHideMainLoadingPanelRequired = true;
        }

    </script>

</asp:Content>

<asp:Content runat="server" ID="PageContent" ContentPlaceHolderID="HeadContent">
    
    <dx:ASPxCallbackPanel runat="server" 
        ID="aspxcpSourceXML" ClientInstanceName="aspxcpSourceXML" 
        OnCallback="aspxcpSourceXML_Callback"
        ShowLoadingPanel="False"
    >
        <ClientSideEvents 
            EndCallback="aspxcpSourceXML_OnEndCallback"
        />
        
        <PanelCollection>
            <dx:PanelContent ID="pcSourceXMLContent" runat="server">
                <dx:ASPxHiddenField runat="server"
                    ID="aspxhfAuthorizationXMLData" ClientInstanceName="aspxhfAuthorizationXMLData" 
                />
            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxCallbackPanel>
    
   
    
    <div class="LoginFormHeader">
        <h2><dx:ASPxLabel runat="server" Text="<%$ Localize: Авторизация пользователя в системе %>" /></h2>
    </div>

    <div class="LoginFormContent">
        <dx:ASPxFormLayout runat="server"
            ID="MainFormLayout" ClientInstanceName="MainFormLayout"
            AlignItemCaptionsInAllGroups="True"
            RequiredMarkDisplayMode="None"
            SettingsItemCaptions-HorizontalAlign="Right" SettingsItemCaptions-VerticalAlign="Middle"
            Width="400px"
        >
            <Styles>
                <LayoutGroup Cell-Paddings-PaddingBottom="10px" Cell-Paddings-PaddingLeft="22px" Cell-Paddings-PaddingRight="22px" />
            </Styles>

            <Items>
            
                <dx:LayoutGroup Caption="<%$ Localize: Данные пользователя %>" GroupBoxStyle-Caption-Font-Bold="True">
                
                    <Items>
                        
                        <dx:EmptyLayoutItem />
                    
                        <dx:LayoutItem Caption="<%$ Localize: Логин %>">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
                                    <dx:ASPxTextBox runat="server"
                                        ID="aspxtbLogin" ClientInstanceName="aspxtbLogin"
                                        ValidationSettings-Display="None" ValidationSettings-SetFocusOnError="True" 
                                        ClientSideEvents-Init="ASPxTextBoxDefaults_OnInit"
                                        ClientSideEvents-KeyUp="RaiseLoginButtonClick"
                                        AutoPostBack="False"
                                        Width="100%"
                                    />
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        
                        <dx:LayoutItem Caption="<%$ Localize: Пароль %>">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
                                    <dx:ASPxTextBox runat="server" 
                                        ID="aspxtbPassword" ClientInstanceName="aspxtbPassword"
                                        Password="True"
                                        ValidationSettings-Display="None" ValidationSettings-SetFocusOnError="True"
                                        ClientSideEvents-Init="ASPxTextBoxDefaults_OnInit"
                                        ClientSideEvents-KeyUp="RaiseLoginButtonClick"
                                        AutoPostBack="False"
                                        Width="100%"
                                    />
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        
                        <dx:LayoutItem Name="ItemErrorMessage" ClientVisible="False" ShowCaption="False">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <div runat="server" class="CommonASPxFormLayout">
                                        <dx:ASPxPanel runat="server" ClientInstanceName="aspxpnlErrorMessage" CssClass="Message Error Simple">
                                            <PanelCollection>
                                                <dx:PanelContent runat="server">
                                                    <div runat="server" id="loginFormErrors" ClientIDMode="Static"></div>
                                                </dx:PanelContent>
                                            </PanelCollection>
                                        </dx:ASPxPanel>
                                    </div>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                        <dx:LayoutItem ShowCaption="False" HorizontalAlign="Center">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxButton runat="server" 
                                        ID="aspxbtnLogin" ClientInstanceName="aspxbtnLogin"
                                        Text="<%$ Localize: Войти в систему %>" 
                                        AutoPostBack="False" UseSubmitBehavior="False"
                                        ClientSideEvents-Click="aspxbtnLogin_OnButtonClick"
                                        Width="200px"
                                    />
                                    <dx:ASPxButton runat="server" 
                                        ID="aspxbtnAuthorize" ClientInstanceName="aspxbtnAuthorize"
                                        Text="<%$ Localize: Войти в систему %>" 
                                        ClientVisible="False"
                                        AutoPostBack="False" UseSubmitBehavior="False"
                                        OnClick="aspxbtnAuthorize_OnClick"
                                        Width="200px"
                                    />
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                    </Items>

                </dx:LayoutGroup>

            </Items>
        </dx:ASPxFormLayout>
    </div>
    
    <div id="applet" class="AppletContainer"></div>

</asp:Content>