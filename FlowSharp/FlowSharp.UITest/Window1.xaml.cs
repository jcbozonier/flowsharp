using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FlowSharp.Core;
using FlowSharp.Core.Components;

namespace FlowSharp.UITest
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void ClickButton_Click(object sender, RoutedEventArgs e)
        {
            AddComponent<AdderComponent>("Sum1");

            var network = new Network();
            network.AddComponent<AdderComponent>("Sum1");
            network.AddComponent<AutoInputComponent>("EvenNumberGenerator");
            network.AddComponent<AutoInputComponent>("OddNumberGenerator");
            network.AddComponent<OutputterComponent>("NetworkOutput");

            network.Connect("EvenNumberGenerator", "OUT", "Sum1", "Term1IN");
            network.Connect("OddNumberGenerator", "OUT", "Sum1", "Term2IN");
            network.Connect("Sum1", "OUT", "NetworkOutput", "IN");

            network.Start();
        }

        public void AddComponent<T>(string name)
            where T : class
        {
            var instance = (T)typeof(T).InvokeMember(typeof(T).Name, BindingFlags.CreateInstance, null, null, null);
        }
    }
}
