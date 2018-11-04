using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Win.Editors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using System;

namespace Wendy.Module.Win.Editors
{
    [PropertyEditor(typeof(string), false)]
    public class StringSelector : StringPropertyEditor
    {
        public StringSelector(Type objectType, IModelMemberViewItem model) : base(objectType, model)
        {
        }

        protected override void SetupRepositoryItem(RepositoryItem item)
        {
            base.SetupRepositoryItem(item);
            if (item is RepositoryItemPredefinedValuesStringEdit)
            {
                ((RepositoryItemPredefinedValuesStringEdit)item).TextEditStyle = TextEditStyles.DisableTextEditor;
            }
        }
    }
}