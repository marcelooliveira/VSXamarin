### Fazendo Uma Requisição HTTP Get ###

const string URL_GET_VEICULOS = "http://aluracar.herokuapp.com/";
HttpClient cliente = new HttpClient();
var resultado = await cliente.GetStringAsync(URL_GET_VEICULOS);

### Convertendo Json Para Objetos C# ###

[{"nome":"Azera V6","preco":85000},
{"nome":"Onix 1.6","preco":35000},
{"nome":"Fiesta 2.0","preco":52000},
{"nome":"C3 1.0","preco":22000},
{"nome":"Uno Fire","preco":11000},
{"nome":"Sentra 2.0","preco":53000},
{"nome":"Astra Sedan","preco":39000},
{"nome":"Vectra 2.0 Turbo","preco":37000},
{"nome":"Hilux 4x4","preco":90000},
{"nome":"Montana Cabine dupla","preco":57000},
{"nome":"Outlander 2.4","preco":99000},
{"nome":"Brasilia Amarela","preco":9500},
{"nome":"Omega Hatch","preco":8000}]

class VeiculoJson
{
    public string nome { get; set; }
    public int preco { get; set; }
}

var veiculosJson = JsonConvert.DeserializeObject<VeiculoJson[]>(resultado);

### Fazendo Uma Requisição HTTP Post ###

HttpClient cliente = new HttpClient();

var dataHoraAgendamento = new DateTime(
    DataAgendamento.Year, DataAgendamento.Month, DataAgendamento.Day,
    HoraAgendamento.Hours, HoraAgendamento.Minutes, HoraAgendamento.Seconds);

var json = JsonConvert.SerializeObject(new
{
    nome = Nome,
    fone = Fone,
    email = Email,
    carro = Veiculo.Nome,
    preco = Veiculo.Preco,
    dataAgendamento = dataHoraAgendamento
});

var conteudo = new StringContent(json, Encoding.UTF8, "application/json");

var resposta = await cliente.PostAsync(URL_POST_AGENDAMENTO, conteudo);

### Indicando Que A Aplicação Está Ocupada ###

<ActivityIndicator IsRunning="{Binding Aguarde}"
                    IsVisible="{Binding Aguarde}">            
</ActivityIndicator>

private bool aguarde;
public bool Aguarde
{
    get { return aguarde; }
    set
    {
        aguarde = value;
        OnPropertyChanged();
    }
}

Aguarde = true;
//chamada HTTP Get
Aguarde = false;

### Desabilitando Button Através de Validação ###

AgendarCommand = new Command(() =>
{
    MessagingCenter.Send<Agendamento>(this.Agendamento
        , "Agendamento");
}, ()=>
{
    return !string.IsNullOrEmpty(this.Nome)
        && !string.IsNullOrEmpty(this.Fone)
        && !string.IsNullOrEmpty(this.Email);
});
