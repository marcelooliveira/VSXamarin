### Fazendo Uma Requisição HTTP Get ###

Você está desenvolvendo um aplicativo para uma imobiliária,
cujo objetivo é agendar visitas dos candidatos a compradores
aos imóveis disponíveis.

Ao iniciar a aplicação, você deve realizar uma requisição
HTTP Get a um serviço fictício na url fictícia "http://aluraimoveis.com.br/imoveis",
utilizando a biblioteca `Microsoft.Net.Http`.

Assinale a alternativa com o código C# correto para realizar
essa operação.

a. ERRADO
```
const string URL_GET_IMOVEIS = "http://aluraimoveis.com.br/imoveis";
HttpClient cliente = new HttpClient();
var resultado = cliente.Get(URL_GET_IMOVEIS);
```

b. CORRETO
```
const string URL_GET_IMOVEIS = "http://aluraimoveis.com.br/imoveis";
HttpClient cliente = new HttpClient();
var resultado = cliente.GetStringAsync(URL_GET_IMOVEIS);
```

c. ERRADO
```
const string URL_GET_IMOVEIS = "http://aluraimoveis.com.br/imoveis";
HttpClient cliente = new HttpClient();
var resultado = await cliente.Get(URL_GET_IMOVEIS);
```

d. CORRETO
```
const string URL_GET_IMOVEIS = "http://aluraimoveis.com.br/imoveis";
HttpClient cliente = new HttpClient();
var resultado = await cliente.GetStringAsync(URL_GET_IMOVEIS);
```

e. ERRADO
```
const string URL_GET_IMOVEIS = "http://aluraimoveis.com.br/imoveis";
var resultado = new HttpClient(URL_GET_IMOVEIS);
```

OPINIÃO DA ALURA:
=================

O método `GetStringAsync` da classe `System.Net.Http.HttpClient` 
envia uma requisição GET para a Uri especificada e retorna o
corpo da resposta como uma string numa operação assíncrona.

### Convertendo Json Para Objetos C# ###

[{"nome":"Apto 2 dorms Botafogo R Janeiro","preco":485000},
{"nome":"Casa 2 dorms Pituba Bahia","preco":735000},
{"nome":"Flat 2 dorms Moema S Paulo","preco":552000},
{"nome":"Casa 3 dorms Jaçanã S Paulo","preco":422000},
{"nome":"Apto 3 dorms Pampulha MG","preco":511000},
{"nome":"Apto 2 dorms Morumbi S Paulo","preco":453000},
{"nome":"Flat Vl Mariana S Paulo","preco":539000},
{"nome":"Apto 2 dorms Bela Vista Porto Alegre","preco":537000},
{"nome":"Sobrado 2 dorms Guarulhos S Paulo","preco":390000},
{"nome":"Casa 2 dorms Santana S Paulo","preco":457000},
{"nome":"Apto 2 dorms Leblon R Janeiro","preco":899000},
{"nome":"Flat Cruzeiro Belo Horizonte","preco":495000},
{"nome":"Casa 3 dorms Itaigara Salvador","preco":880000}]

class ImovelJson
{
    public string nome { get; set; }
    public int preco { get; set; }
}

var vmoveisJson = JsonConvert.DeserializeObject<ImovelJson[]>(resultado);

### Fazendo Uma Requisição HTTP Post ###

HttpClient cliente = new HttpClient();

var dataHoraVisita = new DateTime(
    DataVisita.Year, DataVisita.Month, DataVisita.Day,
    HoraVisita.Hours, HoraVisita.Minutes, HoraVisita.Seconds);

var json = JsonConvert.SerializeObject(new
{
    nome = Nome,
    fone = Fone,
    email = Email,
    imovel = Imovel.Nome,
    preco = Imovel.Preco,
    dataVisita = dataHoraVisita
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
    MessagingCenter.Send<Visita>(this.Visita
        , "Visita");
}, ()=>
{
    return !string.IsNullOrEmpty(this.Nome)
        && !string.IsNullOrEmpty(this.Fone)
        && !string.IsNullOrEmpty(this.Email);
});
