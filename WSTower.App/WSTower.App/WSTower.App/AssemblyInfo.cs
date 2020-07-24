using Android.App;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

#if DEBUG
[assembly: Application(Debuggable=true)]
#else
[assembly: Aplication(Debuggable=false)]
#endif