using App1.Modles;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace App1
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Regs> AllRegs;
        private List<Regs> RegSuggestions;
        private bool chang_enable { get; set; }
        public CollectionViewSource collectionRegs { get; set; }


        public MainPage()
        {
            this.InitializeComponent();

            SetTheme();

            AllRegs = new ObservableCollection<Regs>();
            RegManager.GetAllRegs(AllRegs);

            Func<RegCategoly, string> SwitchCategoly = (time) =>
            {
                return time.ToString();
            };

            var temp = from t in AllRegs
                       orderby t.Categoly
                       group t by SwitchCategoly(t.Categoly);
            collectionRegs = new CollectionViewSource();
            collectionRegs.IsSourceGrouped = true;
            collectionRegs.Source = temp;
            this.gridView1.ItemsSource = collectionRegs.View.CollectionGroups;
            this.gridView2.ItemsSource = collectionRegs.View;

            imagebox.Source = new BitmapImage(new Uri(AllRegs[0].ImageFile));
        }

        private void gridView2_ItemClick(object sender, ItemClickEventArgs e)
        {
            var item = (Regs)e.ClickedItem;
            imagebox.Source = new BitmapImage(new Uri(item.ImageFile));
        }

        private void gridView2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(chang_enable)
            {
                var item = (Regs)gridView2.SelectedItem;
                imagebox.Source = new BitmapImage(new Uri(item.ImageFile));
            }
        }

        private void SearchAutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            chang_enable = false;

            RegSuggestions = AllRegs
                .Where(p => p.Name.StartsWith(sender.Text.ToUpper())).ToList();
            //SearchAutoSuggestBox.ItemsSource = RegSuggestions;

            Func<RegCategoly, string> SwitchCategoly = (time) =>
            {
                return time.ToString();
            };

            var temp = from t in RegSuggestions
                       orderby t.Categoly
                       group t by SwitchCategoly(t.Categoly);
            collectionRegs = new CollectionViewSource();
            collectionRegs.IsSourceGrouped = true;
            collectionRegs.Source = temp;
            this.gridView1.ItemsSource = collectionRegs.View.CollectionGroups;
            this.gridView2.ItemsSource = collectionRegs.View;

            if(RegSuggestions.Count()!=0)
            { imagebox.Source = new BitmapImage(new Uri(RegSuggestions[0].ImageFile)); }
            else
            { imagebox.Source = new BitmapImage(new Uri("ms-appx:///Assets/NoResult.png")); }

            chang_enable = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (RequestedTheme == ElementTheme.Light)
            {
                RequestedTheme = ElementTheme.Dark;
                InvertBorder.Visibility = Visibility.Visible;
                ThemeIcon.Glyph = "\uE708;";
            }
            else
            {
                RequestedTheme = ElementTheme.Light;
                InvertBorder.Visibility = Visibility.Collapsed;
                ThemeIcon.Glyph = "\uE706;";
            }
        }

        private void SetTheme()
        {
            //Check Theme
            if(IsLightTheme())
            {
                ThemeIcon.Glyph = "\uE706;";
                InvertBorder.Visibility = Visibility.Collapsed;
            }
            else
            {
                ThemeIcon.Glyph = "\uE708;";
                InvertBorder.Visibility = Visibility.Visible;
            }
            ViewIcon.Glyph = "\uE76B;";
        }


        private bool IsLightTheme()
        {
            //get system current theme color, not the app theme
            var DefaultTheme = new Windows.UI.ViewManagement.UISettings();
            var uiTheme = DefaultTheme.GetColorValue(Windows.UI.ViewManagement.UIColorType.Background).ToString();
            if (uiTheme == "#FF000000")
            {
                RequestedTheme = ElementTheme.Dark;
                return false;
            }
            else
            {
                RequestedTheme = ElementTheme.Light;
                return true;
            }
        }

        private void ViewChange_Click(object sender, RoutedEventArgs e)
        {
            if(SearchGrid.Visibility==Visibility.Visible)
            {
                SearchGrid.Visibility = Visibility.Collapsed;
                ViewIcon.Glyph = "\uE76C;";
            }
            else
            {
                SearchGrid.Visibility = Visibility.Visible;
                ViewIcon.Glyph = "\uE76B;";
            }
        }
    }
}
