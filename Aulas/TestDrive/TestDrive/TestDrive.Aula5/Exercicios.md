## Seções Dentro De Um TableView ## 

Você é um desenvolvedor encarregado de criar um aplicativo de cadastro de
currículos profissionais.

Você precisa desenvolver uma tela para preenchimento de dados.

Escreva um código XAML com um `TableView` com as seguintes seções (obs.: somente as seções, 
sem os campos de coleta).

- Dados Pessoais
- Formação Acadêmica
- Experiência Profissional
- Atividades Complementares

> OPINIÃO DA ALURA:
> 
> É necessário usar 4 `TableSections` dentro de um `TableRoot` dentro de um `TableView`,
> assim:
> 
> ```
> <TableView>
>     <TableRoot>
> 		<TableSection Title="Dados Pessoais">
> 		</TableSection>
> 		<TableSection Title="Formação Acadêmica">
> 		</TableSection>
> 		<TableSection Title="Experiência Profissional">
> 		</TableSection>
> 		<TableSection Title="Atividades Complementares">
> 		</TableSection>
>     </TableRoot>
> </TableView>
> ```
> 

## Entrada de Digitação de Dados Dentro de Um TableView ## 

Considere o código XAML do formulário de entrada de dados abaixo,
criado numa aplicação Xamarin para um e-commerce:

```
<TableView Intent="Form">
    <TableRoot>
        <TableSection Title="Endereço de Entrega">
            <!--Nome da Rua/Avenida, etc.-->
            <!--Número-->
            <!--Complemento-->
            <!--Bairro-->
            <!--CEP-->
        </TableSection>
    </TableRoot>
</TableView>
```

Escolha a alternativa com o código XAML adequado para substituir os 
comentários acima.

a. código
```
<TextCell Label="Endereço" Text="{Binding Endereco}" />
<TextCell Label="Número" Text="{Binding Numero}" />
<TextCell Label="Complemento" Text="{Binding Complemento}" />
<TextCell Label="Bairro" Text="{Binding Bairro}" />
<TextCell Label="CEP" Text="{Binding CEP}" />
```
b. código
```
<TextBox Label="Endereço" Text="{Binding Endereco}" />
<TextBox Label="Número" Text="{Binding Numero}" />
<TextBox Label="Complemento" Text="{Binding Complemento}" />
<TextBox Label="Bairro" Text="{Binding Bairro}" />
<TextBox Label="CEP" Text="{Binding CEP}" />
```
c. código
```
<Entry Label="Endereço" Text="{Binding Endereco}" />
<Entry Label="Número" Text="{Binding Numero}" />
<Entry Label="Complemento" Text="{Binding Complemento}" />
<Entry Label="Bairro" Text="{Binding Bairro}" />
<Entry Label="CEP" Text="{Binding CEP}" />

```
d. código
```
<EntryCell Label="Endereço" Text="{Binding Endereco}" />
<EntryCell Label="Número" Text="{Binding Numero}" />
<EntryCell Label="Complemento" Text="{Binding Complemento}" />
<EntryCell Label="Bairro" Text="{Binding Bairro}" />
<EntryCell Label="CEP" Text="{Binding CEP}" />
```
CORRETO
e. código
```
<Label Text="Endereço"/>
<TextBox Text="{Binding Endereco}" />
<Label Text="Número"/>
<TextBox Text="{Binding Numero}" />
<Label Text="Complemento"/>
<TextBox Text="{Binding Complemento}" />
<Label Text="Bairro"/>
<TextBox Text="{Binding Bairro}" />
<Label Text="CEP"/>
<TextBox Text="{Binding CEP}" />
```

> OPINIÃO DA ALURA:
> Dentro de um `TableView`, deve-se utilizar controles do tipo `Cell`. Mais
> especificamente, para preenchimento de texto, é necessário usar o `EntryCell`,
> que é um controle que possui uma propriedade `Label` e outra `Text`.
> ```
> <EntryCell Label="Endereço" Text="{Binding Endereco}" />
> <EntryCell Label="Número" Text="{Binding Numero}" />
> <EntryCell Label="Complemento" Text="{Binding Complemento}" />
> <EntryCell Label="Bairro" Text="{Binding Bairro}" />
> <EntryCell Label="CEP" Text="{Binding CEP}" />
> ```

## Alterando Teclado Padrão do EntryCell ## 

Você desenvolveu um aplicativo com uma página de cadastro do cliente.
Nessa página de cadastro, o código XAML contém esse trecho de preenchimento
de telefones do cliente:

```
<TableView Intent="Form">
    <TableRoot Title="Cadastro">
        <TableSection Title="Telefones">
            <EntryCell Label="Celular:" Text="{Binding Celular}" />
            <EntryCell Label="Fone Residencial:" Text="{Binding FoneResidencial}" />
        </TableSection>
    </TableRoot>
</TableView>
```

Ao publicar o aplicativo, seus clientes reclamam da usabilidade, e que o 
preenchimento de telefones poderia ser mais fácil.

Modifique o código acima para melhorar a experiência do usuário.

> OPINIÃO DA ALURA:
> No controle `EntryCell`, você pode usar a propriedade `Keyboard` com o valor `Telephone` para mudar
> o tipo de teclado e assim permitir que o usuário utilize um teclado mais
> adequado e confortável para digitação dos telefones:
> 
> ```
> <TableView Intent="Form">
>     <TableRoot Title="Cadastro">
>         <TableSection Title="Telefones">
>             <EntryCell Label="Celular:" Keyboard="Telephone" Text="{Binding Celular}" />
>             <EntryCell Label="Fone Residencial:" Keyboard="Telephone" Text="{Binding FoneResidencial}" />
>         </TableSection>
>     </TableRoot>
> </TableView>
> 
> ```
> 
## Selecionando Data ## 

## Selecionando Hora ## 

## Exibindo Controles Comuns Dentro De Um TableView ## 

