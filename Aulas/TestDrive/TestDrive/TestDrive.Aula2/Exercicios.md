### Exibindo Label ###

Qual alternativa abaixo representa corretamente um XAML 
com um `Label` dividido em 3 partes?

a. código:
```
<Label>
    <Span Text="Telefone:" FontAttributes="Bold"/>
    <Span Text="12413122" ForegroundColor="Red" />
    <Span Text="(Horário de funcionamento: Dias úteis e sábados das 8h às 22h)"/>
</Label>
```

> Os controles `Span` devem estar contidos dentro de
> `FormattedText` e `FormattedString`.

b. código:

```
<Label>
    <Label.FormattedText>
        <FormattedString>
            <Label Text="Telefone:" FontAttributes="Bold"/>
            <Label Text="12413122" ForegroundColor="Red" />
            <Label Text="(Horário de funcionamento: Dias úteis e sábados das 8h às 22h)"/>
        </FormattedString>
    </Label.FormattedText>
</Label>
```

> Um controle `Label` não pode conter outros controles
> `Label`.

c. código:
```
<Label>
    <Label Text="Telefone:" FontAttributes="Bold"/>
    <Label Text="12413122" ForegroundColor="Red" />
    <Label Text="(Horário de funcionamento: Dias úteis e sábados das 8h às 22h)"/>
</Label>
```

> Um controle `Label` não pode conter outros controles
> `Label`.

d. código:
```
<Label>
    <Label.FormattedText>
        <FormattedString>
            <Span Text="Telefone:" FontAttributes="Bold"/>
            <Span Text="12413122" ForegroundColor="Red" />
            <Span Text="(Horário de funcionamento: Dias úteis e sábados das 8h às 22h)"/>
        </FormattedString>
    </Label.FormattedText>
</Label>
```

> CORRETO:
> O label pode ser dividido em uma série de controles `Span`, contidos
> na propriedade `FormattedText.FormattedString`.
> 

e. código:
```
<Label>
    <StackLayout Orientation="Horizontal">
        <Span Text="Telefone:" FontAttributes="Bold"/>
        <Span Text="12413122" ForegroundColor="Red" />
        <Span Text="(Horário de funcionamento: Dias úteis e sábados das 8h às 22h)"/>
    </StackLayout>
</Label>
```

> Os controles `Span` devem estar contidos dentro de
> `FormattedText` e `FormattedString`.


### stacklayout horizontal ###

Escreva um trecho de código XAML em que três labels
diferentes com as palavras "Red", "Green" e "Blue" sejam exibidos 
horizontalmente, na mesma linha.

OPINIÃO DA ALURA:
Deve-se colocar os 3 Labels dentro de um StackLayout com 
Orientation="Horizontal", da seguinte forma:

```
<StackLayout Orientation="Horizontal">
    <Label Text="Red"/>
    <Label Text="Green"/>
    <Label Text="Blue"/>
</StackLayout>
```

### listview itemtapped ###

listview itemtapped

### displayalert ###

displayalert

