using BleBox_wlightbox_sampleAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WLightBoxGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ChangeColorButton_Click(object sender, RoutedEventArgs e)
        {
            string endpoint = EndpointTextBox.Text;
            var service = new WLightBoxService(endpoint);
            string color = ColorTextBox.Text;
            service.SetColor(color);
        }

        private void ChangeEffectButton_Click(object sender, RoutedEventArgs e)
        {
            string endpoint = EndpointTextBox.Text;
            var service = new WLightBoxService(endpoint);
            int effect = int.Parse(EffectTextBox.Text);
            service.SetEffect(effect);
        }

        private void UpdateCurrentStateButton_Click(object sender, RoutedEventArgs e)
        {
            string endpoint = EndpointTextBox.Text;
            var service = new WLightBoxService(endpoint);
            int effect= service.GetEffect().Result;
            string color = service.GetColor().Result;
            EffectTextBox.Text = effect.ToString();
            ColorTextBox.Text = color;
        }
    }
}
