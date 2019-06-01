using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x411 を参照してください

namespace PatBrowser
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void ClaimsSelectAsync(object sender, TappedRoutedEventArgs e)
        {
            // DescriptionTextBox.Text = "test";
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
            picker.FileTypeFilter.Add(".txt");

            var file = await picker.PickSingleFileAsync();

            if (file != null)
            {
                var buff = await Windows.Storage.FileIO.ReadBufferAsync(file);
                try
                {
                    System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                    var enc = System.Text.Encoding.GetEncoding("Shift_JIS");
                    //textBox1.Text += enc.GetString(buff.ToArray());
                    DescriptionRichEditBox.Document.SetText(Windows.UI.Text.TextSetOptions.None, enc.GetString(buff.ToArray()));
                    DescriptionRichEditBox.IsReadOnly = true;

                }
                catch (Exception ex)
                {
                    var dlg = new MessageDialog(ex.ToString());
                    await dlg.ShowAsync();
                }
                //string text = await Windows.Storage.FileIO.ReadTextAsync(file);
                //DescriptionRichEditBox.Document.SetText(Windows.UI.Text.TextSetOptions.None, text);

                //textBlock.Text = text;
                //var buffer = await Windows.Storage.FileIO.ReadBufferAsync(file);
                //using (var dataReader = Windows.Storage.Streams.DataReader.FromBuffer(buffer))
                //{

                //    // string text = dataReader.ReadString(buffer.Length);
                //    Byte[] text = (Byte[])dataReader.ReadString(buffer.Length);
                //    DescriptionRichEditBox.Document.SetText(Windows.UI.Text.TextSetOptions.None, text);
                //}
                //var dlg = new MessageDialog(file.FileType);
                //await dlg.ShowAsync();

                //var buffer = await Windows.Storage.FileIO.ReadBufferAsync(file);
                //using (var dataReader = Windows.Storage.Streams.DataReader.FromBuffer(buffer))
                //{
                //string text = dataReader.ReadString(buffer.Length);
                //var dlg = new MessageDialog(text);
                //await dlg.ShowAsync();
                //}

                //var dlg = new MessageDialog(fileStream.CanWrite.ToString());
                //await dlg.ShowAsync();
            }
            else
            {
                var dlg = new MessageDialog("Operation cancelled.");
                await dlg.ShowAsync();
            }
        }


        private async void DescriptionSearchQuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            //var dlg = new MessageDialog(args.QueryText);
            //await dlg.ShowAsync();
            
        }
    }
}
