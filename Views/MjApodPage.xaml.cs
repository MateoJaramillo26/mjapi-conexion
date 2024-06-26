namespace mjapi_conexion.Views;
using mjapi_conexion.ViewModels;

public partial class MjApodPage : ContentPage
{
    public MjApodPage()
    {
        InitializeComponent();
        BindingContext = new MjApodViewModel();
    }
}