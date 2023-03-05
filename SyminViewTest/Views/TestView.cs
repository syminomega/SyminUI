using SyminUI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyminUI;
using System.Windows;
using System.Windows.Media;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Globalization;
using System.ComponentModel.DataAnnotations;

namespace SyminViewTest.Views
{
    public class TestView : ViewProvider
    {
        /// <summary>
        /// 提供视图
        /// </summary>
        public override IView Body => MainView;

        //测试可切换控件
        readonly State<IView> dynamicView = new Label("Label A");
        readonly State<int> inputNum = 123;

        readonly ObservableCollection<string> textCollection = new()
        {
            "1111",
            "2222",
            "3333"
        };

        //主要视图
        private VStack MainView => new VStack
        {
            new HStack
            {
                new Label(inputNum),
                new Button("Change Value Button")
                    .OnClick(() => {
                        Console.WriteLine("Button Pressed!");
                    }),
                new Button("Close Window").OnClick(() =>
                {
                    //获取宿主窗口并关闭
                    HostWindow?.Close();
                }),
            },
            new HStack
            {
                new Button("Open Canvas")
                    .OnClick(() =>
                    {
                        CanvasTestWindow testWindow = new();
                        testWindow.Show();
                    }),
                new Label("Label In HStack"),
            }.HorizontalAlignment(HorizontalAlignment.Center),
            new Grid()
                {
                    new ContentView(dynamicView)
                        .GridLayout(0, 0),
                    new Button("Change Content")
                        .OnClick(() => { dynamicView.Value = new Label("Changed View"); })
                        .GridLayout(0, 1),
                    new InputField(inputNum)
                        .GridLayout(1, 0),
                    new Button("Show Input Value")
                        .OnClick(() => MessageBox.Show(inputNum.Value.ToString()))
                        .GridLayout(1, 1),
                }
                .Cols("2*", ("*", 200, 400))
                .Rows("auto", "auto"),
            new Button("Add List Item")
                .OnClick(TestCollection),
            new ItemsView()
                .Foreach(textCollection, x => new HStack
                {
                    new Label("List Items"),
                    new Button(x),
                })
        };

        private void TestCollection()
        {
            textCollection.Insert(1, "Inserted Item");
        }


    }
}