using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace InfoSearchApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static string _lastSearchText;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void SearchBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var selectedItem = (ComboBoxItem)WebsiteComboBox.SelectedItem;
            var site = GetWebsiteSearchUrl(selectedItem.Name, SearchBox.Text);

            if (SearchBox.Text != String.Empty)
            {
                Process.Start("chrome", site);
            }
        }

        public static string GetWebsiteSearchUrl(string website, string searchText)
        {
            if (website == "YoutubeCbi")
            {
                return $@"http://www.youtube.com/results?search_query={ToSearchQuery(searchText)}";
            }
            if (website == "WarframeCbi")
            {
                return $@"http://www.warframe.fandom.com/wiki/Special:Search?query={ToSearchQuery(searchText)}";
            }
            if (website == "GoogleCbi")
            {
                return $@"https://www.google.com/search?q={ToSearchQuery(searchText)}";
            }
            if (website == "WikiCbi")
            {
                return $@"https://en.wikipedia.org/wiki/Special:Search?search={ToSearchQuery(searchText)}&go=Go";
            }
            _lastSearchText = String.Empty; ;
            return _lastSearchText;
        }

        public static string ToSearchQuery(string text)
        {
            return text.Replace(' ', '+');
        }
    }
}
