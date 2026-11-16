# Cadastro de Eventos

Projeto em .NET MAUI 10 para a Agenda 15 de Desenvolvimento de Sistemas II. O aplicativo cadastra um evento e abre uma segunda tela com o resumo dos dados.

**Aluno:** Leonardo Nunes de Souza

## Executar no Visual Studio 2026

1. Extraia o ZIP. No **Visual Studio Installer**, confirme que a carga de trabalho **Desenvolvimento de interface do usuário de aplicativo multiplataforma do .NET** está instalada.
2. Abra `CadastroEventos.slnx` no Visual Studio 2026. Aguarde a restauração dos pacotes.
3. Na barra de execução, selecione **Windows Machine** (ou **Máquina Windows**). Também é possível selecionar um emulador Android já configurado.
4. Pressione **F5**. Preencha o formulário e clique em **Ver resumo**.
5. Clique em **Voltar ao cadastro** para editar os valores preenchidos.

## Como o código funciona

| Arquivo | Responsabilidade |
| --- | --- |
| `Models/Evento.cs` | Representa o evento, valida os dados e calcula a duração e o custo total. |
| `Views/CadastroPage.xaml` | Vincula os seis campos à instância de `Evento` por meio de `BindingContext` e bindings bidirecionais. |
| `Views/CadastroPage.xaml.cs` | Valida os dados e abre a página de resumo, passando a instância preenchida. |
| `Views/ResumoPage.xaml` e `ResumoPage.xaml.cs` | Usam a mesma instância como `BindingContext` e mostram os dados formatados. |

A subtração entre as datas (`DateTime`) produz um `TimeSpan`. A propriedade `Days` desse intervalo indica quantos dias se passaram da data inicial até a final. Na mesma data, a diferença é de 0 dias. O custo total é o número de participantes multiplicado pelo custo individual. Os valores monetários são calculados em `decimal` e exibidos em reais.