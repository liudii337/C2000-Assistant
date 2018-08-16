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
        public CollectionViewSource collectionRegs { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
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
        }

        private void gridView2_ItemClick(object sender, ItemClickEventArgs e)
        {
            var item = (Regs)e.ClickedItem;
            imagebox.Source = new BitmapImage(new Uri(item.ImageFile));
        }
    }
}
