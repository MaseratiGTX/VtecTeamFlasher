using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web.UI;
using Commons.Exceptions;
using Commons.Helpers.Collections;
using Commons.Helpers.Objects;
using DevExpress.Data.Filtering;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxGridView;
using WebAppCommons.Classes.Controls.ASPx.xSmartGridView;
using WebAppCommons.Classes.Controls.ASPx.xWebControlBase;
using WebAppCommons.Classes.Controls.IListServer.Implementation;

namespace WebAppCommons.Classes.Controls.ASPx.xGridView
{
    public static class ASPxGridViewExtensions
    {
        public static ASPxGridView SetPageSize(this ASPxGridView source, int value)
        {
            source.SettingsPager.PageSize = value;

            return source;
        }


        public static ASPxGridView SetFilterExpression(this ASPxGridView source, string value)
        {
            source.FilterExpression = value;

            return source;
        }
        
        public static ASPxGridView SetFilter(this ASPxGridView source, CriteriaOperator value)
        {
            return source.SetFilterExpression(value.ToString());
        }

        public static ASPxGridView SetFilter(this ASPxGridView source, string propertyName, BinaryOperatorType operatorType, object value)
        {
            return source.SetFilter(new BinaryOperator(propertyName, value, operatorType));
        }

        public static ASPxGridView SetMasterRowFilter(this ASPxGridView source, string propertyName)
        {
            return source.SetFilter(propertyName, BinaryOperatorType.Equal, source.GetMasterRowKeyValue());
        }
        

        public static ASPxGridView SetDataSource(this ASPxGridView source, object dataSource)
        {
            source.DataSource = dataSource;

            if (source is ASPxSmartGridView == false)
            {
                source.HtmlEditFormCreated += FIX_PROBLEM_TARGET_FOR_THE_CALLBACK_COULD_NOT_BE_FOUND;
            }

            return source;
        }
        
        private static void FIX_PROBLEM_TARGET_FOR_THE_CALLBACK_COULD_NOT_BE_FOUND(object sender, ASPxGridViewEditFormEventArgs e)
        {
            // Если в качестве способа редактирования грида используется EditForm, при этом для EditForm задан template, то на callback, 
            // приходящий из контрола EditForm'ы, для грида создается EditForm с ID отличным от присвоенного ранее ("efnew" вместо к примеру "ef1"):
            // по всей видимости отсутсвует возможность восстановить calbackstate у грида либо вообще либо в полном объеме, 
            // что приводит к "потере" DataProxy.EditingRowVisibleIndex у самого грида - как следствие происходит "потеря" значения 
            // VisibleIndex/ItemIndex у GridViewEditFormTemplateContainer (см.метод GetID в базовой имплементации данного класса)
            //
            // Таким образом, при попытке обработать данный callback возникает исключение:
            // [The target "ctl00$MainContent$gridView$DXPEForm$ef4$TC$pcEditFormPages$DXEditor3" for the callback could not be found 
            // or did not implement ICallbackEventHandler.]"
            //
            // При создании EditForm из шаблона имеем следующую иерархию контролов:
            // [инстанция шаблона EditForm] -> GridViewEditFormTemplateContainer -> ClientIDHelper.TemplateHierarchyContainer -> [ContentDiv у GridViewHtmlEditFormPopup]
            // ИЛИ
            // [инстанция шаблона EditForm] -> GridViewEditFormTemplateContainer -> ClientIDHelper.TemplateContainerHolder -> ClientIDHelper.TemplateHierarchyContainer -> [ContentDiv у GridViewHtmlEditFormPopup]
            // Иерархия контролов зависит от ClientIDMode у TemplateHierarchyContainer. При этом значение ID из GridViewEditFormTemplateContainer.GetID() 
            // получает контрол вложенный в ClientIDHelper.TemplateHierarchyContainer:
            // * в первом случае - GridViewEditFormTemplateContainer 
            // * во втором случае - ClientIDHelper.TemplateContainerHolder
            //
            // Учитывая, что с очень большой вероятностью конкретная инстанция шаблона EditForm всегда одна и отсутвует возможность перегрузить 
            // метод AddEditFormTemplateControl у ASPxGridViewRenderHelper, то мы постараемся недопустить появления описанного исключения 
            // просто изменив ID у соответствующего контрола с "efnew"/"ef[visibleindex]" на "ef" сразу после создания
            //
            // ВНИМАНИЕ! СТОИТ УЧИТЫВАТЬ, ЧТО СОБЫТИЯ Init У КОНТРОЛОВ ВХОДЯЩИХ В СОСТАВ TEMPLATE'А EDITFORM БУДУТ ВОЗНИКАТЬ ДО ВНЕСЕНИЯ 
            // ИЗМЕНЕНИЙ В ID СООТВЕТСТВУЮЩЕГО КОНТРОЛА

            var aspxGridView = (ASPxGridView) sender;

            if (aspxGridView.Templates.EditForm != null)
            {
                var requiredControl = e.EditForm.FindControlSmart(expression: @"\Aef(\d+|new)\z");
                
                if (requiredControl != null)
                {
                    requiredControl.SetID("ef")
                        .ResetChildControlsHierarchy<ASPxLabel>(); // Данная манипуляция необходима по причине того, что AssociatedControlID у ASPxLabel интерпритируются некорректно - фактически с учетом "efnew"/"ef[visibleindex]". Другого способа, кроме как "адресно" произвести ResetControlHierarchy найти не получилось.
                }
            }
        }


        public static bool HasVisibleRows(this ASPxGridView source)
        {
            return source.VisibleRowCount > 0;
        }


        public static bool IsGrouped(this ASPxGridView source)
        {
            return source.GroupCount > 0;
        }

        public static List<string> GroupFieldNames(this ASPxGridView source)
        {
            return source.GetGroupedColumns().Select(x => x.FieldName).ToList();
        }



        public static bool IsFiltered(this ASPxGridView source)
        {
            return source.FilterExpression.IsNotEmpty() && source.FilterEnabled;
        }



        public static IEnumerable<GridViewColumn> Columns(this ASPxGridView source)
        {
            return source.Columns.Cast<GridViewColumn>();
        }

        public static IEnumerable<T> Columns<T>(this ASPxGridView source) where T : GridViewColumn
        {
            return source.Columns.OfType<T>();
        }


        public static GridViewDataColumn Column(this ASPxGridView source, string columnName)
        {
            return source.Columns<GridViewDataColumn>().Where(x => x.Name == columnName).FirstOrDefault();
        }

        public static GridViewDataColumn ColumnOf(this ASPxGridView source, string fieldName)
        {
            return source.Columns<GridViewDataColumn>().Where(x => x.FieldName == fieldName).FirstOrDefault();
        }


        public static IEnumerable<GridViewColumn> VisibleColumns(this ASPxGridView source)
        {
            var visibleColumns = source.Columns().Where(x => x.Visible);

            if (source.Settings.ShowGroupedColumns == false)
            {
                visibleColumns = visibleColumns.Where(x => x.NotGrouped());
            }

            return visibleColumns.OrderBy(x => x.VisibleIndex);
        }



        public static T EditingItem<T>(this ASPxGridView source) where T : class
        {
            return (T) source.EditingItem();
        }

        public static object EditingItem(this ASPxGridView source)
        {
            return source.GetRow(source.EditingRowVisibleIndex);
        }


        public static T GetItem<T>(this ASPxGridView source, OrderedDictionary keys) where T : class
        {
            return (T) source.GetItem(keys);
        }

        public static object GetItem(this ASPxGridView source, OrderedDictionary keys)
        {
            return source.GetItem(keys[source.KeyFieldName]);
        }
        
        public static T GetItem<T>(this ASPxGridView source, object keyValue) where T : class
        {
            return (T) source.GetItem(keyValue);
        }

        public static object GetItem(this ASPxGridView source, object keyValue)
        {
            return source.GetItem(source.FindVisibleIndexByKeyValue(keyValue));
        }

        public static T GetItem<T>(this ASPxGridView source, int visibleIndex) where T : class
        {
            return (T) source.GetItem(visibleIndex);
        }

        public static object GetItem(this ASPxGridView source, int visibleIndex)
        {
            return visibleIndex != ASPxGridView.InvalidRowIndex ? source.GetRow(visibleIndex) : null;
        }


        public static int GetDataRowCount(this ASPxGridView source)
        {
            var smartDataSource = source.DataSource as ISmartDataSourse;

            if (smartDataSource != null)
            {
                return smartDataSource.Count;
            }


            if (source.IsGrouped())
            {
                var result = 0;

                for (var index = 0; index < source.VisibleRowCount; index++)
                {
                    if (source.IsGroupRow(index))
                    {
                        if (source.IsRowExpanded(index) == false)
                        {
                            var keys = (source.DataBoundProxy).GetChildKeysRecursive(index);

                            result += keys.Cast<object>().Count(x => x != null);
                        }
                    }
                    else
                    {
                        result++;
                    }
                }

                return result;
            }


            return source.VisibleRowCount;
        }



        public static Control EditForm(this ASPxGridView source, string path)
        {
            return source.EditForm<Control>(path, ".");
        }

        public static T EditForm<T>(this ASPxGridView source, string path) where T : Control
        {
            return source.EditForm<T>(path, ".");
        }

        public static T EditForm<T>(this ASPxGridView source, string path, string pathSeparator) where T : Control
        {
            var controlIds = path.Split(new[] { pathSeparator }, StringSplitOptions.RemoveEmptyEntries);


            var elementsEnumerator = controlIds.GetEnumerator();


            var result = source.FindEditFormTemplateControl(elementsEnumerator.FetchNext().As<string>());

            if (result == null)
            {
                throw new ElementNotFoundException();
            }

            while (elementsEnumerator.MoveNext())
            {
                result = result.FindControl(elementsEnumerator.Current.As<string>());

                if (result == null)
                {
                    throw new ElementNotFoundException();
                }
            }


            return (T)result;
        }
    }
}