namespace CSharpWithMaui.Exercicios;

public partial class URI_1071 : ContentPage
{
    public URI_1071()
    {
        InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {

        //int x = int.Parse(Console.ReadLine());
        int x = int.Parse(await App.Current.MainPage.DisplayPromptAsync("Entrada 1", "Informe o valor de 'X'"));

        //int y = int.Parse(Console.ReadLine());
        int y = int.Parse(await App.Current.MainPage.DisplayPromptAsync("Entrada 2", "Informe o valor de 'Y'"));

        int min, max;
        if (x < y)
        {
            min = x;
            max = y;
        }
        else
        {
            min = y;
            max = x;
        }

        int soma = 0;
        for (int i = min + 1; i < max; i++)
        {
            if (i % 2 != 0)
            {
                soma = soma + i;
            }
        }

        //Console.WriteLine(soma);
        await App.Current.MainPage.DisplayAlert("Saída:", $"{soma}", "Ok");
    }

    //beecrowd: https://www.beecrowd.com.br/judge/en/problems/view/1071
    //github Nelio: https://github.com/acenelio/curso-logica-de-programacao-csharp/blob/master/uri1071/uri1071/Program.cs
}