using SyminUI.Core;
using SyminUI.Views.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SyminUI.Views
{
    public class Grid : PanelViewBase<System.Windows.Controls.Grid>
    {
        public Grid() : base()
        {

        }
        #region 定义网格划分
        public Grid Rows(params GridSize[] sizeList)
        {
            foreach (var rowSize in sizeList)
            {
                var rowDef = new System.Windows.Controls.RowDefinition
                {
                    Height = rowSize.Size
                };
                if (rowSize.Min is not null)
                {
                    rowDef.MinHeight = rowSize.Min.Value;
                }
                if (rowSize.Max is not null)
                {
                    rowDef.MaxHeight = rowSize.Max.Value;
                }
                Element.RowDefinitions.Add(rowDef);
            }


            return this;
        }
        public Grid Cols(params GridSize[] sizeList)
        {
            foreach (var colSize in sizeList)
            {
                var colDef = new System.Windows.Controls.ColumnDefinition
                {
                    Width = colSize.Size
                };
                if (colSize.Min is not null)
                {
                    colDef.MinWidth = colSize.Min.Value;
                }
                if (colSize.Max is not null)
                {
                    colDef.MaxWidth = colSize.Max.Value;
                }
                Element.ColumnDefinitions.Add(colDef);
            }
            return this;
        }
        #endregion

        public void Add(GridCell gridCell)
        {
            System.Windows.Controls.Grid.SetColumn(gridCell.View.Element, gridCell.Col);
            System.Windows.Controls.Grid.SetColumnSpan(gridCell.View.Element, gridCell.ColSpan);
            System.Windows.Controls.Grid.SetRow(gridCell.View.Element, gridCell.Row);
            System.Windows.Controls.Grid.SetRowSpan(gridCell.View.Element, gridCell.RowSpan);
            this.Add(gridCell.View);
        }
    }
    public static class GridExtern
    {
        /// <summary>
        /// Set the row and col of ViewElement in Grid
        /// 设置对象网格布局
        /// </summary>
        /// <param name="viewElement"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="rowSpan"></param>
        /// <param name="colSpan"></param>
        /// <returns></returns>
        public static GridCell GridLayout(this IView viewElement,
            int row = 0, int col = 0, int rowSpan = 1, int colSpan = 1)
        {
            var cell = new GridCell(viewElement)
            {
                Row = row,
                Col = col,
                RowSpan = rowSpan,
                ColSpan = colSpan
            };
            return cell;
        }
    }
    public class GridSize
    {
        public GridSize(GridLength value)
        {
            Size = value;
            Min = null;
            Max = null;
        }
        public GridLength Size { get; }
        public double? Min { get; private set; }
        public double? Max { get; private set; }

        public static GridSize Star(int value)
        {
            var gridLength = new GridLength(value, GridUnitType.Star);
            return new GridSize(gridLength);
        }
        public static GridSize Pixel(double value)
        {
            var gridLength = new GridLength(value, GridUnitType.Pixel);
            return new GridSize(gridLength);
        }
        public static GridSize Auto()
        {
            var gridLength = new GridLength(1, GridUnitType.Auto);
            return new GridSize(gridLength);
        }

        public static implicit operator GridSize((string size, double? min, double? max) sizePack)
        {
            GridSize gridSize = sizePack.size;
            gridSize.Min = sizePack.min;
            gridSize.Max = sizePack.max;
            return gridSize;

        }
        public static implicit operator GridSize((double size, double? min, double? max) sizePack)
        {
            GridSize gridSize = sizePack.size;
            gridSize.Min = sizePack.min;
            gridSize.Max = sizePack.max;
            return gridSize;
        }

        public static implicit operator GridSize(string size)
        {
            if (size.Equals("auto"))
            {
                return Auto();
            }
            else if (size.EndsWith('*'))
            {
                var sizeStr = size.TrimEnd('*');
                if (sizeStr.Length == 0)
                {
                    return Star(1);
                }
                else if (int.TryParse(sizeStr, out int sizeValue))
                {
                    return Star(sizeValue);
                }
                else
                {
                    throw new ArgumentException("Can not convert value into GridSize, you can only use strings like \"12.3\", \"3*\",\"auto\"");
                }
            }
            else
            {
                if (double.TryParse(size, out double sizeValue))
                {
                    return Pixel(sizeValue);
                }
                else
                {
                    throw new ArgumentException("Can not convert value into GridSize, you can only use strings like \"12.3\", \"3*\",\"auto\"");
                }
            }
        }

        public static implicit operator GridSize(double size)
        {
            return Pixel(size);
        }

    }
}
