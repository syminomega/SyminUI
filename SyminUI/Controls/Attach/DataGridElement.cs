﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace SyminUI.Controls.Attach
{
    //https://stackoverflow.com/questions/2630292/why-cant-i-style-a-datagridtextcolumn
    //DataGrid样式注入
    public class DataGridElement : DependencyObject
    {

        public static bool GetApplyDefaultStyle(DependencyObject obj)
        {
            return (bool)obj.GetValue(ApplyDefaultStyleProperty);
        }

        public static void SetApplyDefaultStyle(DependencyObject obj, bool value)
        {
            obj.SetValue(ApplyDefaultStyleProperty, value);
        }

        // Using a DependencyProperty as the backing store for ApplyDefaultStyle.
        public static readonly DependencyProperty ApplyDefaultStyleProperty =
            DependencyProperty.RegisterAttached("ApplyDefaultStyle",
                typeof(bool), typeof(DataGridElement),
                new PropertyMetadata(false, OnApplyDefaultStyleChanged));

        private static void OnApplyDefaultStyleChanged(DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            var grid = (DataGrid)d;
            if ((bool)e.NewValue)
            {
                if (grid.AutoGenerateColumns)
                {
                    grid.AutoGeneratedColumns += Grid_AutoGeneratedColumns;
                    return;
                }

                UpdateTextColumnStyles(grid);
                UpdateEditingTextColumnStyles(grid);
                UpdateCheckBoxColumnStyles(grid);
                UpdateEditingCheckBoxColumnStyles(grid);
            }
            else
            {
                grid.AutoGeneratedColumns -= Grid_AutoGeneratedColumns;
            }
        }

        private static void Grid_AutoGeneratedColumns(object? sender, EventArgs e)
        {
            if (sender == null)
            {
                return;
            }
            var grid = (DataGrid)sender;
            UpdateTextColumnStyles(grid);
            UpdateEditingTextColumnStyles(grid);
            UpdateCheckBoxColumnStyles(grid);
            UpdateEditingCheckBoxColumnStyles(grid);
        }


        #region 文本列注入
        public static Style GetTextColumnStyle(DependencyObject obj)
        {
            return (Style)obj.GetValue(TextColumnStyleProperty);
        }

        public static void SetTextColumnStyle(DependencyObject obj, Style value)
        {
            obj.SetValue(TextColumnStyleProperty, value);
        }

        // Using a DependencyProperty as the backing store for TextColumnStyle.
        public static readonly DependencyProperty TextColumnStyleProperty =
            DependencyProperty.RegisterAttached("TextColumnStyle",
                typeof(Style), typeof(DataGridElement),
                new PropertyMetadata(default(Style), OnTextColumnStyleChanged));

        private static void OnTextColumnStyleChanged(DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            var grid = (DataGrid)d;
            if (e.OldValue == null && e.NewValue != null)
            {
                UpdateTextColumnStyles(grid);
            }
        }
        private static void UpdateTextColumnStyles(DataGrid grid)
        {
            var textColumnStyle = GetTextColumnStyle(grid);
            if (textColumnStyle != null)
            {
                foreach (var column in grid.Columns.OfType<DataGridTextColumn>())
                {
                    var elementStyle = new Style
                    {
                        BasedOn = column.ElementStyle,
                        TargetType = textColumnStyle.TargetType
                    };

                    foreach (var setter in textColumnStyle.Setters.OfType<Setter>())
                    {
                        elementStyle.Setters.Add(setter);
                    }

                    column.ElementStyle = elementStyle;
                }
            }
        }

        #endregion

        #region 编辑列注入
        public static Style GetEditingTextColumnStyle(DependencyObject obj)
        {
            return (Style)obj.GetValue(EditingTextColumnStyleProperty);
        }

        public static void SetEditingTextColumnStyle(DependencyObject obj, Style value)
        {
            obj.SetValue(EditingTextColumnStyleProperty, value);
        }

        // Using a DependencyProperty as the backing store for EditingTextColumnStyle.
        public static readonly DependencyProperty EditingTextColumnStyleProperty =
            DependencyProperty.RegisterAttached("EditingTextColumnStyle",
                typeof(Style), typeof(DataGridElement),
                new PropertyMetadata(default(Style), OnEditingTextColumnStyleChanged));

        private static void OnEditingTextColumnStyleChanged(DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            var grid = (DataGrid)d;
            if (e.OldValue == null && e.NewValue != null)
            {
                UpdateEditingTextColumnStyles(grid);
            }
        }

        private static void UpdateEditingTextColumnStyles(DataGrid grid)
        {
            var editingTextColumnStyle = GetEditingTextColumnStyle(grid);

            if (editingTextColumnStyle != null)
            {
                foreach (var column in grid.Columns.OfType<DataGridTextColumn>())
                {
                    var editingElementStyle = new Style
                    {
                        BasedOn = column.EditingElementStyle,
                        TargetType = editingTextColumnStyle.TargetType
                    };

                    foreach (var setter in editingTextColumnStyle.Setters.OfType<Setter>())
                    {
                        editingElementStyle.Setters.Add(setter);
                    }

                    column.EditingElementStyle = editingElementStyle;
                }
            }
        }
        #endregion

        #region 勾选框注入


        public static Style GetCheckBoxColumnStyle(DependencyObject obj)
        {
            return (Style)obj.GetValue(CheckBoxColumnStyleProperty);
        }

        public static void SetCheckBoxColumnStyle(DependencyObject obj, Style value)
        {
            obj.SetValue(CheckBoxColumnStyleProperty, value);
        }

        // Using a DependencyProperty as the backing store for CheckBoxColumnStyle.
        public static readonly DependencyProperty CheckBoxColumnStyleProperty =
            DependencyProperty.RegisterAttached("CheckBoxColumnStyle",
                typeof(Style), typeof(DataGridElement),
                new PropertyMetadata(default(Style),OnCheckBoxColumnStyleChanged));

        private static void OnCheckBoxColumnStyleChanged(DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            var grid = (DataGrid)d;
            if (e.OldValue == null && e.NewValue != null)
            {
                UpdateCheckBoxColumnStyles(grid);
            }
        }

        private static void UpdateCheckBoxColumnStyles(DataGrid grid)
        {
            var checkBoxColumnStyle = GetCheckBoxColumnStyle(grid);

            if (checkBoxColumnStyle != null)
            {
                foreach (var column in grid.Columns.OfType<DataGridCheckBoxColumn>())
                {
                    var checkBoxElementStyle = new Style
                    {
                        BasedOn = column.ElementStyle,
                        TargetType = checkBoxColumnStyle.TargetType
                    };

                    foreach (var setter in checkBoxColumnStyle.Setters.OfType<Setter>())
                    {
                        checkBoxElementStyle.Setters.Add(setter);
                    }

                    column.ElementStyle = checkBoxElementStyle;
                }
            }
        }

        #endregion

        #region 勾选框编辑


        public static Style GetEditingCheckBoxColumnStyle(DependencyObject obj)
        {
            return (Style)obj.GetValue(EditingCheckBoxColumnStyleProperty);
        }

        public static void SetEditingCheckBoxColumnStyle(DependencyObject obj, Style value)
        {
            obj.SetValue(EditingCheckBoxColumnStyleProperty, value);
        }

        // Using a DependencyProperty as the backing store for EditingCheckBoxColumnStyle.
        public static readonly DependencyProperty EditingCheckBoxColumnStyleProperty =
            DependencyProperty.RegisterAttached("EditingCheckBoxColumnStyle", 
                typeof(Style), typeof(DataGridElement),
                new PropertyMetadata(default(Style), OnEditingCheckBoxColumnStyleChanged));

        private static void OnEditingCheckBoxColumnStyleChanged(DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            var grid = (DataGrid)d;
            if (e.OldValue == null && e.NewValue != null)
            {
                UpdateEditingCheckBoxColumnStyles(grid);
            }
        }

        private static void UpdateEditingCheckBoxColumnStyles(DataGrid grid)
        {
            var editingCheckBoxColumnStyle = GetEditingCheckBoxColumnStyle(grid);

            if (editingCheckBoxColumnStyle != null)
            {
                foreach (var column in grid.Columns.OfType<DataGridCheckBoxColumn>())
                {
                    var checkBoxElementStyle = new Style
                    {
                        BasedOn = column.EditingElementStyle,
                        TargetType = editingCheckBoxColumnStyle.TargetType
                    };

                    foreach (var setter in editingCheckBoxColumnStyle.Setters.OfType<Setter>())
                    {
                        checkBoxElementStyle.Setters.Add(setter);
                    }

                    column.EditingElementStyle = checkBoxElementStyle;
                }
            }
        }
        #endregion

    }
}
