using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using SkiaSharp;

namespace BENWinForms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            LiveCharts.Configure(config =>
           config
               // you can override the theme 
               // .AddDarkTheme()  


               .HasGlobalSKTypeface(SKFontManager.Default.MatchCharacter('Ác')) // <- Chinese

       // .HasMap<Foo>( .... ) 
       // .HasMap<Bar>( .... ) 
       );
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
            //Application.Run(new FormFiles());
            //Application.Run(new FormInternet());
            //Application.Run(new FormParking());
        }
    }
}