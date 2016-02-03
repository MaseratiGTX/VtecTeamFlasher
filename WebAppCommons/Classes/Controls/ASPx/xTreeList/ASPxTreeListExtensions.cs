using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using DevExpress.Web.ASPxTreeList;

namespace WebAppCommons.Classes.Controls.ASPx.xTreeList
{
    public static class ASPxTreeListExtensions
    {
        public static TreeListNode GetParentNode(this ASPxTreeList source, string childNodeKey)
        {
            if (childNodeKey == null) return null;

            var childNode = source.FindNodeByKeyValue(childNodeKey);

            return childNode != null ? childNode.ParentNode : null;
        }
        
        public static T GetParentItem<T>(this ASPxTreeList source, string childNodeKey)
        {
            var parentNode = source.GetParentNode(childNodeKey);

            if (parentNode == source.RootNode) return default(T);

            return (T) (parentNode != null ? parentNode.DataItem : null);
        }


        public static T GetItem<T>(this ASPxTreeList source, OrderedDictionary nodeKey)
        {
            return source.GetItem<T>(nodeKey[source.KeyFieldName]);
        }

        public static T GetItem<T>(this ASPxTreeList source, string nodeKey)
        {
            return source.GetItem<T>((object) nodeKey);
        }

        public static T GetItem<T>(this ASPxTreeList source, object nodeKey)
        {
            if (nodeKey == null) return default(T);

            var node = source.FindNodeByKeyValue(nodeKey.ToString());

            if (node == source.RootNode) return default(T);

            return (T) (node != null ? node.DataItem : null);
        }


        public static TreeListNode NewNodeParentNode(this ASPxTreeList source)
        {
            return source.NewNodeParentKey != null ? source.FindNodeByKeyValue(source.NewNodeParentKey) : null;
        }
        
        public static T NewNodeParentItem<T>(this ASPxTreeList source)
        {
            return source.NewNodeParentKey != null ? source.GetItem<T>(source.NewNodeParentKey) : default(T);
        }


        public static T EditingItem<T>(this ASPxTreeList source)
        {
            return source.GetItem<T>(source.EditingNodeKey);
        }


        public static IEnumerable<TreeListColumn> Columns(this ASPxTreeList source)
        {
            return source.Columns.Cast<TreeListColumn>();
        }

        public static IEnumerable<T> Columns<T>(this ASPxTreeList source) where T : TreeListColumn
        {
            return source.Columns.OfType<T>();
        }


        public static TreeListDataColumn ColumnOf(this ASPxTreeList source, string fieldName)
        {
            return source.Columns<TreeListDataColumn>().FirstOrDefault(x => x.FieldName == fieldName);
        }

        public static T ColumnOf<T>(this ASPxTreeList source, string fieldName) where T : TreeListDataColumn
        {
            return (T) source.ColumnOf(fieldName);
        }
    }
}
