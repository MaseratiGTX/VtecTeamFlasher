using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Web.ASPxEditors;
using WebAppCommons.Classes.Controls.ASPx.xComboBox.DataSources;
using WebAppCommons.Classes.Controls.ASPx.xComboBox.DataSources.Helpers;
using WebAppCommons.Classes.Controls.ASPx.xListBox.ListEditItems;

namespace WebAppCommons.Classes.Controls.ASPx.xComboBox
{
    public static class ASPxComboBoxExtension
    {
        public static ASPxComboBox ApplyCBDataSource<T>(this ASPxComboBox source, IEnumerable<T> dataSource) where T : class
        {
            source.SetComboBoxDataSource(dataSource);
            source.DataBindItems();

            return source;
        }

        public static ASPxComboBox ApplyDataSource(this ASPxComboBox source, IEnumerable dataSource)
        {
            source.DataSource = dataSource;
            source.DataBindItems();

            return source;
        }


        
        public static ASPxComboBox EnableCallbackMode(this ASPxComboBox source)
        {
            source.EnableCallbackMode = true;
            return source;
        }

        public static ASPxComboBox DisableCallbackMode(this ASPxComboBox source)
        {
            source.EnableCallbackMode = false;
            return source;
        }



        public static ASPxComboBox ClearValueIfNotActual(this ASPxComboBox source)
        {
            if (source.Value == null)
            {
                return source;
            }


            if (source.DataSource == null)
            {
                source.Value = null;

                return source;
            }


            var comboBoxDataSource = source.DataSource as IASPxComboBoxDataSource;

            if (comboBoxDataSource != null)
            {
                if (comboBoxDataSource.HasActual(source.ValueField, source.Value) == false)
                {
                    source.Value = null;

                    return source;
                }
            }


            return source;
        }



        public static ASPxComboBox MarkItemsAsDisabled<T>(this ASPxComboBox source, Func<T, bool> predicate)
        {
            var dataSource = source.DataSource as IEnumerable<T>;

            if (dataSource != null)
            {
                var filteredDataSource = dataSource.Where(predicate);

                source.JSProperties["cpDisabledItems"] = filteredDataSource
                    .ToDictionary(x => source.FetchInternalValue(x), x => true);
            }

            return source;
        }

        private static object FetchInternalValue(this ASPxComboBox sourceControl, object sourceObject)
        {
            return ListEditItemHelper.FetchLEIInternalValue(sourceObject, sourceControl.ValueField, sourceControl.TextField, sourceControl.DesignMode);
        }
    }
}