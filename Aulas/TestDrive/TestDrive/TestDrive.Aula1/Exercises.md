### Organizando Controles na Página ###

Suponha que você tenha 4 controles `Label` numa página 
**XAML**:

```
<Label Text="Inglês"/>
<Label Text="Português"/>
<Label Text="Espanhol"/>
<Label Text="Italiano"/>
```

Escolha a alternativa contém o código `XAML` necessário
para exibir esses 4 labels "empilhados" verticalmente:

a. código

```
    <Grid>
        <Label Text="Inglês"/>
        <Label Text="Português"/>
        <Label Text="Espanhol"/>
        <Label Text="Italiano"/>
    </Grid>
```

> O controle `Grid` poderia ser usado para exibir os labels
> em múltiplas linhas, porém é necessário criar definições
> de linhas (RowDefinitions).

b. código

```
    <ListView>
        <Label Text="Inglês"/>
        <Label Text="Português"/>
        <Label Text="Espanhol"/>
        <Label Text="Italiano"/>
    </ListView>
```

> O controle `ListView` é um "repetidor" de layout, isto é,
> ele pode criar várias instâncias dos controles que estão
> contidos em seu template, porém ele não serve como um
> simples "container" de controles, como nesse caso.

c. código

```
    <StackLayout>
        <Label Text="Inglês"/>
    </StackLayout>
    <StackLayout>
        <Label Text="Português"/>
    </StackLayout>
    <StackLayout>
        <Label Text="Espanhol"/>
    </StackLayout>
    <StackLayout>
        <Label Text="Italiano"/>
    </StackLayout>
```

> Está incorreto porque deveríamos ter um único 
> `StackLayout` contendo todos os labels, e não um
> `StackLayout` para cada label.

d. código
```
    <StackLayout>
        <Label Text="Inglês"/>
        <Label Text="Português"/>
        <Label Text="Espanhol"/>
        <Label Text="Italiano"/>
    </StackLayout>
```

CORRETO. O `StackLayout` é um container que por padrão
organiza os controles encapsulados, empilhando-os na
página XAML.

e. código

```
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition/>
            <RowDefinition/>
            <RowDefinition/>
            <RowDefinition/>
        </Grid.RowDefinitions>
        <Label Text="Inglês"/>
        <Label Text="Português"/>
        <Label Text="Espanhol"/>
        <Label Text="Italiano"/>
    </Grid>

```

Essa abordagem poderia funcionar, porém para isso seria
necessário que cada `Label` tivesse definido a propriedade
`Grid.Row`, caso contrário os controles-filhos
serão exibidos "amontoados" uns sobre os outros.

### Grid ###

### ListView ItemsSource ###

### ListView Binding ###

### ListView Template ###