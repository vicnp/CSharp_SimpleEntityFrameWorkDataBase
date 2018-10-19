<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastrarProfessor.aspx.cs" Inherits="ProfessorSite.CadastrarProfessor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="styles/estilos.css" rel="stylesheet" />
    <title>Cadastrar Professor</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2 id="h2_titulo" runat="server">Cadastro de Professor</h2>
            <p>
                Nome: <br />
                <asp:TextBox runat="server" id="txtNome"/>
            </p>
            <p>
                Área de Atuação: <br />
                <asp:TextBox runat="server"  id="txtAreaAtuacao"/>
            </p>
            <p>
                Especialidade: <br />
                <asp:TextBox runat="server" id="txtEspecialidade"/>
            </p>
            <p>
                Titulação: <br />
                <asp:DropDownList runat="server" ID="ddlTitulacaoes"/>
            </p>
            <p>
                <asp:Button Text="Cadastrar" runat="server" ID="btnCadastrar" OnClick="btnCadastrar_Click"/>
            </p>
                <!-- Exibindo os professores cadastrados -->
                <table border="2">
                <thead>
                    <tr>
                        <td>Nome</td>
                        <td>Área de Atuação</td>
                        <td>Especialidade</td>
                        <td>Titulação</td>
                        <td>Opções</td>
                    </tr>
                </thead>
                    <asp:ListView runat="server" ID="lvProfessores" OnItemCommand="lvProfessores_ItemCommand">
                        <ItemTemplate>
                            <tr>
                            <td><%# Eval("Nome") %></td>
                            <td><%# Eval("AreaAtuacao") %></td>
                            <td><%# Eval("Especialidade") %></td>
                            <td><%# Eval("GetTitulacaoDescricao") %></td>    
                            <td>
                                
                                <asp:LinkButton class="lnk-btn" Text="Alterar" runat="server" id="btnAlterar"
                                    href='<%# "CadastrarProfessor.aspx?IdProfessor=" + Eval("IdProfessor") %>'>
                                    <img class="img-btn" src="images/alterar_icon.png" alt="Alterar"/>
                                </asp:LinkButton>
                                
                                &nbsp

                                <asp:LinkButton class="lnk-btn" Text="Excluir" runat="server" id="btnExcluir"
                                    CommandName="Excluir" CommandArgument='<%# Eval("IdProfessor") %>' 
                                    OnClientClick="return confirm('Deseja realmente excluir?');" >
                                    <img class="img-btn" src="images/excluir_icon.png" alt="Excluir"/>
                                </asp:LinkButton>
                                
                            </td>
                            </tr>
                        </ItemTemplate>
                    </asp:ListView>
                </table>

            <p>
                <a href="~/" runat="server">Página Inicial</a>
            </p>
            
        </div>
    </form>
</body>
</html>
