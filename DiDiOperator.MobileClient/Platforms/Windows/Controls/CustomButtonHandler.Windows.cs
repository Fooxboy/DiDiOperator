using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiDiOperator.MobileClient.Controls
{
    public partial class CustomButtonHandler
    {
        protected override Microsoft.UI.Xaml.Controls.Button CreatePlatformView()
        {
            var button = new Microsoft.UI.Xaml.Controls.Button();
            button.PointerEntered += Button_PointerEntered;

            return button;
        }

        private void Button_PointerEntered(object sender, Microsoft.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            if(sender is Microsoft.UI.Xaml.Controls.Button button) 
            {
                
            }
        }
    }
}
