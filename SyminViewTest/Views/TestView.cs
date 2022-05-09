using SyminUI.Core;
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

namespace SyminViewTest.Views
{
    public class TestView : IView
    {
        readonly State<string> myText = "123";
        //测试可切换控件
        readonly State<IView> dynamicView = new Label("标签A");

        readonly State<string> inputText = "输入测试";
        ObservableCollection<string> textCollection = new()
        {
            "1111",
            "2222",
            "3333",
            "4444"
        };

        public VStack MainView => new VStack
        {
            new Label(myText)
                .Margin(new Thickness(5)),
            new HStack
            {
                new Text("左侧文本"),
                new Button("打开测试界面")
                    .OnClick(() =>
                    {
                        ControlTestWindow testWindow = new();
                        testWindow.Show();
                    })
                    .Margin(5,0,5,0),
                new Button("打开Canvas界面")
                    .OnClick(() =>
                    {
                        CanvasTestWindow testWindow = new CanvasTestWindow();
                        testWindow.SetEventTriggerTest(this);
                        testWindow.Show();
                    })
                    .Margin(5,0,5,0),
                new Label("右侧"),
            }
                .HorizontalAlignment(HorizontalAlignment.Center),
            new Button("测试按钮")
                .OnClick(() =>{myText.Value = "432";})
                .Margin(new Thickness(5)),
            new Label(myText)
                .Margin(new Thickness(5)),
            new Grid()
                {
                    new Button("网格按钮(事件销毁测试)")
                        .OnClick(OnEventTriggered)
                        .Margin(new Thickness(2))
                        .GridLayout(row:1,col:1,rowSpan:1,colSpan:1),
                    new ContentView(dynamicView)
                        .Margin(new Thickness(2))
                        .GridLayout(1,0),
                    new Button("切换控件内容")
                        .OnClick(()=>{dynamicView.Value = new Label("新的控件");})
                        .Margin(new Thickness(2))
                        .GridLayout(1,2),
                    new Button("切换集合内容")
                        .OnClick(TestCollection)
                        .Margin(new Thickness(2))
                        .GridLayout(2,0),
                    new InputField(inputText)
                        .Margin(new Thickness(2))
                        .GridLayout(2,1),
                    new Button("获取Input值")
                        .OnClick(()=>MessageBox.Show(inputText.Value))
                        .Margin(new Thickness(2))
                        .GridLayout(2,2),
                }
                .Cols("*",("2*",200, 400),"*")
                .Rows("*","auto","auto")
                .Height(90),
            new ItemsView()
                .Foreach(textCollection,x => new HStack
                {
                    new Label("列表项目")
                        .Margin(2,2,2,2),
                    new Button(x)
                        .Margin(2,2,2,2),
                })
        };

        private void TestCollection()
        {
            textCollection.Insert(1, "aaaa");
        }

        private void OnEventTriggered()
        {
            EventTrigger?.Invoke();
        }
        public event Action? EventTrigger;

        public FrameworkElement GetViewElement()
        {
            return MainView;
        }
    }
}
