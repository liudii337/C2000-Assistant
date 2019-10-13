using App1.ContentPopupEx;
using App1.Modles;
using App1.usercontrol;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
using Windows.System;
using Windows.UI;
using Windows.UI.ViewManagement;
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
        private Regs LastSelectedReg;
        private bool chang_enable { get; set; }
        public CollectionViewSource collectionRegs { get; set; }


        public MainPage()
        {
            this.InitializeComponent();
            SetStatusBar();

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
            LastSelectedReg = AllRegs[0];
        }

        private void gridView2_ItemClick(object sender, ItemClickEventArgs e)
        {

            var item = (Regs)e.ClickedItem;
            if(item!=LastSelectedReg)
            {
                //SetSelectEffect(LastSelectedReg, false);
                LastSelectedReg = item;
            }
            imagebox.Source = new BitmapImage(new Uri(item.ImageFile));


            //SetSelectEffect(item,true);
        }

        private void SetSelectEffect(Regs reg, bool b)
        {
            var ItemContainer = gridView2.ContainerFromItem(reg);
            var selectedItem = ItemContainer as ListViewItem;

            if (selectedItem != null)
            {
                var grid = selectedItem.ContentTemplateRoot as Grid;
                var block = (TextBlock)VisualTreeHelper.GetChild(grid, 0);
                block.Foreground = b ? new SolidColorBrush(Colors.Yellow) : (Application.Current.Resources["SystemColorWindowTextColor"] as SolidColorBrush);
                //(IsLightTheme() ? new SolidColorBrush(Colors.Black) : new SolidColorBrush(Colors.White))
            }
        }

        private void gridView2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(chang_enable)
            {
                //SetSelectEffect(LastSelectedReg, false);
                var item = (Regs)gridView2.SelectedItem;
                LastSelectedReg = item;
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
            var titleBar = ApplicationView.GetForCurrentView().TitleBar;

            if (RequestedTheme == ElementTheme.Light)
            {
                RequestedTheme = ElementTheme.Dark;
                InvertBorder.Visibility = Visibility.Visible;
                ThemeIcon.Glyph = "\uE708;";
                titleBar.ButtonForegroundColor = Colors.White;
            }
            else
            {
                RequestedTheme = ElementTheme.Light;
                InvertBorder.Visibility = Visibility.Collapsed;
                ThemeIcon.Glyph = "\uE706;";
                titleBar.ButtonForegroundColor = Colors.Black;
            }

        }

        private void SetTheme()
        {
            //Check Theme
            if (IsLightTheme())
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

        private void SetStatusBar()
        {
            if (ApiInformation.IsTypePresent("Windows.UI.ViewManagement.ApplicationView"))
            {
                var titleBar = ApplicationView.GetForCurrentView().TitleBar;
                var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
                if (titleBar != null)
                {
                    titleBar.ButtonBackgroundColor = Colors.Transparent;
                    titleBar.BackgroundColor = Colors.Transparent;
                    titleBar.InactiveBackgroundColor = Colors.Transparent;

                    titleBar.ButtonForegroundColor = IsLightTheme()? Colors.Black: Colors.White;


                    coreTitleBar.ExtendViewIntoTitleBar = true;
                }
            }

        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (DateTime.Now.Day % 13 == 0)
            {
                var uc = new RateDialog();
                await PopupService.Instance.ShowAsync(uc);
            }
        }
    }
}
