using System.Collections.Generic;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxGridView.Rendering;
using WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Helpers.GridViewTableCells;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Rendering
{
    public class ASPxSmartGridViewBottomBorderRemovalHelper
    {
        private readonly TableRowCollection Rows;
        private readonly ASPxGridViewRenderHelper RenderHelper;
        
        private Dictionary<GridViewTableRow, int> LevelDeltas;



        public ASPxSmartGridViewBottomBorderRemovalHelper(TableRowCollection rows, ASPxSmartGridViewRenderHelper helper)
        {
            Rows = rows;
            RenderHelper = helper;
        }



        public void Run()
        {
            CalcLevelDeltas();
            
            foreach (var row in LevelDeltas.Keys)
            {
                if (LevelDeltas[row] != int.MinValue)
                {
                    RemoveBottomBorder(row.Cells, GetCellCountForBorderRemoval(row));
                }
            }
        }

        private void CalcLevelDeltas()
        {
            LevelDeltas = new Dictionary<GridViewTableRow, int>();
            
            var row = (GridViewTableRow) null;
            
            foreach (var nextRow in CreateGridRowsIterator())
            {
                if (row != null)
                {
                    LevelDeltas[row] = CalcLevelDelta(row, nextRow);
                }

                row = nextRow;
            }
            
            
            if (row == null) return;


            if (RenderHelper.ShowFooter || RenderHelper.ShowHorizontalScrolling)
            {
                LevelDeltas[row] = int.MinValue;
            }
            else
            {
                LevelDeltas[row] = int.MaxValue;
            }
        }

        private IEnumerable<GridViewTableRow> CreateGridRowsIterator()
        {
            foreach (TableRow tableRow in Rows)
            {
                var gridRow = tableRow as GridViewTableRow;
                
                if (gridRow != null)
                    yield return gridRow;
            }
        }

        private int CalcLevelDelta(GridViewTableRow row, GridViewTableRow nextRow)
        {
            if (row is GridViewTableDataRow && nextRow is GridViewTableDataRow && !RenderHelper.ShowHorizontalGridLine)
                return int.MaxValue;

            return GetRowLevel(nextRow) - GetRowLevel(row);
        }


        private int GetRowLevel(GridViewTableRow row)
        {
            return GetRowLevel(row.VisibleIndex);
        }

        private int GetRowLevel(int visibleIndex)
        {
            return RenderHelper.DataProxy.GetRowLevel(visibleIndex);
        }

        private int GetCellCountForBorderRemoval(GridViewTableRow row)
        {
            var num = LevelDeltas[row];
            
            if (num == int.MaxValue)
                return row.Cells.Count;
            
            var rowLevel = GetRowLevel(row);
            
            if (row.RemoveExtraIndentBottomBorder())
                ++rowLevel;
            
            if (num <= 0)
                rowLevel += num;
            
            return rowLevel;
        }

        private static void RemoveBottomBorder(TableCellCollection cells, int count)
        {
            if (count > cells.Count) return;
            
            for (var index = 0; index < count; ++index)
            {
                var gridViewTableCellEx = cells[index] as GridViewTableCellEx;

                if (gridViewTableCellEx != null)
                    gridViewTableCellEx._RemoveBottomBorder(true);
            }
        }
    }
}