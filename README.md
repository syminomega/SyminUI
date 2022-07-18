# SyminUI
![SyminUI Icon](./Images/SyminUI.png)
SyminUI is a WPF UI kit. Build interface with Neomorphism style and **C#UI** in MVU pattern (WIP).\
SyminUI 是 WPF 的 UI 组件库，并使用称为 **C#UI** 的 MVU 设计模式进行 UI 搭建（画饼中），默认样式为新拟态风格。

[![build](https://github.com/syminomega/SyminUI/actions/workflows/dotnet-desktop.yml/badge.svg)](https://github.com/syminomega/SyminUI/actions/workflows/dotnet-desktop.yml)

## Preview 预览 (2022-07-13)
Currently is in early preview stage. **Pull requests are not available at this moment.**\
目前处于早期预览阶段，**Pull Request 暂未全面开放**。

![Styles Demo](./Images/StylesDemo.jpg)

## 🧰 Quick Start 快速使用
1. Add `SyminData` and `SyminUI` reference to your project.\
在项目中添加 `SyminData` 和 `SyminUI` 引用.
2. Add these code to `App.xaml`.\
将以下代码添加至 `App.xaml` 中。

``` xml
    <Application.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary Source="pack://application:,,,/SyminUI;component/Themes/SyminLight.xaml"/>
                <ResourceDictionary Source="pack://application:,,,/SyminUI;component/Themes/SyminBasic.xaml"/>
                <ResourceDictionary Source="pack://application:,,,/SyminUI;component/Themes/SyminStyle.xaml"/>
                <ResourceDictionary Source="pack://application:,,,/SyminUI;component/Themes/SyminExtra.xaml"/>
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Application.Resources>
```
## 📦 Styles For Buildin Controls 内置控件样式
| Control         | Status  | Comment
| ----            | ----    | ----
| Button          | ✔       | 
| Calendar        | ✔       | 
| CheckBox        | ✔       | 
| ComboBox        | ✔       | 
| DataGrid        |         | 
| DatePicker      | ✔       | 
| DocumentViewer  |         | No plan
| Expander        | ✔       | 
| Frame           |         | 
| GridSplitter    | ✔       | 
| GroupBox        | ✔       | 
| Image           |         | 
| Label           | ✔       | 
| ListBox         | ✔       | 
| ListView        |         | 
| Menu            | ✔       | 
| PasswordBox     | ✔       | 
| Progress Bar    | ⚠       | Vertical style not work
| RadioButton     | ✔       | 
| Repeat Button   |         | 
| RichTextBox     | ✔       | 
| ScrollBar       | ✔       | 
| ScrollViewer    | ✔       | 
| Separator       | ✔       | 
| Slider          | ✔       | Tick view not work
| StatusBar       | ✔       | 
| TabControl      | ✔       | Plan to add new styles
| TextBox         | ✔       | 
| Toggle Button   | ✔       | 
| ToolBar         | ✔       | No menu style for tool bar
| ToolBarPanel    | ✔       | 
| ToolBarTray     | ✔       | 
| TreeView        |         | 

## ⚠ Known Issues 已知问题
+ Progress bar vertical style does not show shader effect.\
进度条垂直样式不显示辉光效果。
+ Progress indeterminate style does not work correctly.\
进度条 indeterminate 状态不能正常显示。
+ Slider view tick placement does not work.\
滑条的指示器样式未设计。
+ MenuItem disabled style is not finished.\
菜单按钮禁用样式尚未完善。

## 📄 License 许可证
[The MIT License](./LICENSE)