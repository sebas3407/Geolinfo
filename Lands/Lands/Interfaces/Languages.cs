using Xamarin.Forms;
using Lands.Interfaces;

public static class Languages
{
    static Languages()
    {
        var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
       
        //SEBAS
        //Resource.Culture = ci;
        //DependencyService.Get<ILocalize>().SetLocale(ci);
    }
}
