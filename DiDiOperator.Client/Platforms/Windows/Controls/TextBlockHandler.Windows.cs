using Microsoft.UI;
using Microsoft.UI.Xaml.Controls;

namespace DiDiOperator.Client.Controls
{
    public partial class TextBlockHandler
    {
        protected override TextBox CreatePlatformView()
        {
            //base.CreatePlatformView();
            var textbox = new TextBox();

            textbox.BorderBrush = new Microsoft.UI.Xaml.Media.SolidColorBrush(Microsoft.UI.Colors.Transparent);

            textbox.BorderThickness = new Microsoft.UI.Xaml.Thickness(0);
            textbox.GettingFocus += Textbox_GotFocus;

            return textbox;
        }

        private void Textbox_GotFocus(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            //throw new NotImplementedException();
        }
    }
}
