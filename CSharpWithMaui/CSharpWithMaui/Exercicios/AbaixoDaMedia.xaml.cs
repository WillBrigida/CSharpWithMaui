using System.Globalization;

namespace CSharpWithMaui.Exercicios;

public partial class AbaixoDaMedia : ContentPage
{
    const string TITLE = "Abaixo da m�dia";
    const string MESSAGE = "Quantos elementos vai ter o vetor? ";
    const string MESSAGE_ERROR = "Informe um valor v�lido e tente novamente";
    CultureInfo cultureInfo = CultureInfo.InvariantCulture;
    int n;
    double soma = 0, media;

    public AbaixoDaMedia()
    {
        InitializeComponent();
    }

    private async void btn_Clicked(object sender, EventArgs e)
    {
        /*
            "App.Current.MainPage.DisplayPromptAsync"  � um m�todo do Xamarin/Maui que mostra um alerta na tela com uma caixa de input; 

            Neste exemplo, est� sendo passado no argumento do m�todo (par�metros) uma constante string contendo
            o t�tulo da mensagem e uma constante string contendo a mensagem;

            Ao clicar no botao "OK" o valor digitado � atribuido � vari�vel "result".
        */
        var stringResult = await App.Current.MainPage.DisplayPromptAsync(TITLE, MESSAGE); //MESSAGE_ERROR 

        n = int.Parse(stringResult);

        if (n < 1)
            await App.Current.MainPage.DisplayAlert(TITLE, MESSAGE_ERROR, "Ok");
        /*
            "App.Current.MainPage.DisplayAlert" � um m�todo do Xamarin/Maui que mostra um alerta na tela.

            Neste exemplo, est� sendo passando no argumento do m�todo (par�metros) uma constante string contendo
            o t�tulo da mensagem, uma constante string contendo a mensagem de erro e uma string "OK";
        */

        double[] vetor = new double[n];

        for (int i = 0; i < n; i++)
        {
            var newStringResult = await App.Current.MainPage.DisplayPromptAsync($"Entrada {i + 1}", "Digite um n�mero:");
            double doubleResult = double.Parse(newStringResult);

            vetor[i] = double.Parse(newStringResult, cultureInfo);
        }

        for (int i = 0; i < n; i++)
        {
            soma += vetor[i];
        }

        media = soma / n;

        string resultMessage = ("\nMEDIA DO VETOR = " + media.ToString("F3", cultureInfo));
        resultMessage += "\nELEMENTOS ABAIXO DA MEDIA: ";

        for (int i = 0; i < n; i++)
        {
            if (vetor[i] < media)
            {
                resultMessage += $"{vetor[i].ToString("F1", cultureInfo)}, ";
            }
        }

        await App.Current.MainPage.DisplayAlert("Resultado", resultMessage, "Ok");
    }
}