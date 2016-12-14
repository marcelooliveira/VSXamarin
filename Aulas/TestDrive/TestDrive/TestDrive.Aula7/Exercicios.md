### mvvm listview selecteditem ###

### Comunicação Entre Componentes ###

Qual componente permite que componentes de uma aplicação Xamarin comuniquem-se
uns com os outros através de mensagens sem necessariamente conhecerem uns aos
outros?

a. A classe ViewModel
b. A interface INotifyPropertyChanged
c. A interface ICommand
d. A classe Xamarin.Forms.MessagingCenter
CORRETO.

> OPINIÃO DA ALURA:
> A classe MessagingCenter do Xamarin.Forms permite que view models e outros componentes
> se comuniquem através de mensagens, sem conhecerem uns aos outros. 
> 

### Implementando Uma Comunicação Simples ###

Considere a aplicação de Calculadora abaixo. Modifique o código para que
o método `CalculaSoma` de `CalculadoraViewModel` envie uma mensagem 
a ser capturada pelo code behind `CalculadoraView.xaml.cs`, que por sua
vez deve mostrar uma dialog com o resultado da soma para o usuário.

```
CalculadoraView.xaml.cs
=======================

public partial class CalculadoraView : ContentPage
{
    public CalculadoraView()
    {
        InitializeComponent();
    }
}


CalculadoraViewModel.cs
=======================

public class CalculadoraViewModel
{
    public void CalculaSoma(decimal parcela1, decimal parcela2)
    {
        decimal soma = parcela1 + parcela2;
    }
}
```

Primeiro é preciso fazer a `CalculadoraViewModel` acessar a classe
`MessagingCenter` do Xamarin Forms e enviar uma mensagem com um nome
específico (ex.: "SomaCalculada") e contendo o total da soma:

```
public void CalculaSoma(decimal parcela1, decimal parcela2)
{
    decimal soma = parcela1 + parcela2;
    MessagingCenter.Send(soma, "SomaCalculada");
}
```

Em seguida, devemos fazer o code behind "assinar a mensagem", para que ele
possa interceptar a mensagem enviada e em seguida exibir o total para o usuário.
Como o tipo da mensagem que está sendo enviada pela `ViewModel` é um _decimal_,
então a assinatura da mensagem também deve especificar o tipo _decimal_:

```
protected override void OnAppearing()
{
    base.OnAppearing();
    MessagingCenter.Subscribe<decimal>(this, "SomaCalculada",
        (msg) =>
        {
            DisplayAlert("Soma", 
            string.Format("O resultado da soma é: {0}", soma), "Ok");
        });
}
```

O código completo ficaria assim:

```
CalculadoraView.xaml.cs
=======================

public partial class CalculadoraView : ContentPage
{
    public CalculadoraView()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        MessagingCenter.Subscribe<decimal>(this, "SomaCalculada",
            (msg) =>
            {
                DisplayAlert("Soma", string.Format("O resultado da soma é: {0}", soma), "Ok");
            });
    }
}


CalculadoraViewModel.cs
=======================

public class CalculadoraViewModel
{
    public void CalculaSoma(decimal parcela1, decimal parcela2)
    {
        decimal soma = parcela1 + parcela2;
        MessagingCenter.Send(soma, "SomaCalculada");
    }
}
```

### button command icommand ###

